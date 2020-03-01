using System;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Games;
using Android.App;
using Android.Content;
using Android.Views;
using System.Threading.Tasks;
using Android.Gms.Games.Snapshot;
using Android;
using Android.Content.PM;
using Microsoft.AppCenter.Crashes;

namespace KillTeam.Droid
{
    /// <summary>
    /// Basic wrapper for interfacing with the GooglePlayServices Game API's
    /// </summary>
    public class GameHelper : Java.Lang.Object, GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        public static GameHelper Helper;

        GoogleApiClient client;
        Activity activity;
        bool signedOut = true;
        bool signingin = false;
        bool resolving = false;
        const int RC_RESOLVE = 9001;
        const int RESOLUTION_POLICY_MOST_RECENTLY_MODIFIED = 3;
        const int STATUS_OK = 0;
        const int STATUS_SNAPSHOT_CONTENTS_UNAVAILABLE = 4002;
        const int STATUS_SNAPSHOT_CONFLICT = 4004;

        public static string SavedGameFileName = "KTSave";

        public byte[] dataToSave = null;
        public byte[] dataToLoad = null;

        public async void Save(byte[] data)
        {
            var result = await GamesClass.Snapshots.Open(client, SavedGameFileName, true).AsAsync<ISnapshotsOpenSnapshotResult>();

            var code = result.Status.StatusCode;
            if (code == STATUS_SNAPSHOT_CONFLICT)
            {
                var conflictId = result.ConflictId;
                var serverSnapshot = result.Snapshot;
                var conflictedSnapshot = result.ConflictingSnapshot;

                result = await GamesClass.Snapshots.ResolveConflict(client, conflictId, conflictedSnapshot).AsAsync<ISnapshotsOpenSnapshotResult>();

            }
            //On sauve
            ISnapshotMetadataChange change = new SnapshotMetadataChangeBuilder()
                .SetDescription("KillTeamManager")
                .SetPlayedTimeMillis(DateTime.Now.Ticks)
                .Build();

            using (var settings = this.activity.GetSharedPreferences("googleplayservicessettings", FileCreationMode.Private))
            {
                using (var e = settings.Edit())
                {
                    e.PutLong("lastSave", change.PlayedTimeMillis.LongValue());
                    e.Commit();
                }
            }

            result.Snapshot.SnapshotContents.WriteBytes(dataToSave);
            await GamesClass.Snapshots.CommitAndClose(client, result.Snapshot, change);
        }

        public async Task<byte[]> Synchro(byte[] data)
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
                if (Android.App.Application.Context.CheckSelfPermission(Manifest.Permission.Internet) != (int)Permission.Granted
                    || Android.App.Application.Context.CheckSelfPermission(Manifest.Permission.GetAccounts) != (int)Permission.Granted)
            {
                    Android.Support.V4.App.ActivityCompat.RequestPermissions(this.activity, new string[] 
                    {
                        Manifest.Permission.Internet,
                        Manifest.Permission.GetAccounts,
                    }, 0);
                    return null;
            }
            long lastSave = 0;
            using (var settings = this.activity.GetSharedPreferences("googleplayservicessettings", FileCreationMode.Private))
            {
                lastSave = settings.GetLong("lastSave", 0);
            }

            try
            {
                if (data != null)
                {
                    dataToSave = data;
                }

                if(!IsConnected())
                {
                    SignIn();
                }
                else
                {
                    var result = await GamesClass.Snapshots.Open(client, SavedGameFileName, true).AsAsync<ISnapshotsOpenSnapshotResult>();
                                        
                    var code = result.Status.StatusCode;
                    if (code == STATUS_SNAPSHOT_CONFLICT)
                    {
                        var conflictId = result.ConflictId;
                        var serverSnapshot = result.Snapshot;
                        var conflictedSnapshot = result.ConflictingSnapshot;

                        result = await GamesClass.Snapshots.ResolveConflict(client, conflictId, conflictedSnapshot).AsAsync<ISnapshotsOpenSnapshotResult>();

                    }
                    long savedTime = result.Snapshot.Metadata.PlayedTime;

                    if(savedTime>lastSave)
                    {
                        //On charge
                        using (var settings = this.activity.GetSharedPreferences("googleplayservicessettings", FileCreationMode.Private))
                        {
                            using (var e = settings.Edit())
                            {
                                e.PutLong("lastSave", savedTime);
                                e.Commit();
                            }
                        }

                        dataToLoad = result.Snapshot.SnapshotContents.ReadFully();
                        return dataToLoad;

                    }
                    else
                    {
                        dataToLoad = null;

                        //On sauve
                        ISnapshotMetadataChange change = new SnapshotMetadataChangeBuilder()
                            .SetDescription("KillTeamManager")
                            .SetPlayedTimeMillis(DateTime.Now.Ticks)
                            .Build();

                        using (var settings = this.activity.GetSharedPreferences("googleplayservicessettings", FileCreationMode.Private))
                        {
                            using (var e = settings.Edit())
                            {
                                e.PutLong("lastSave", change.PlayedTimeMillis.LongValue());
                                e.Commit();
                            }
                        }

                        result.Snapshot.SnapshotContents.WriteBytes(dataToSave);
                        await GamesClass.Snapshots.CommitAndClose(client, result.Snapshot, change);
                    }                    
                }                
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
            return null;
        }
        

        /// <summary>
        /// Gets or sets a value indicating whether the user is signed out or not.
        /// </summary>
        /// <value><c>true</c> if signed out; otherwise, <c>false</c>.</value>
        public bool SignedOut
        {
            get { return signedOut; }
            set
            {
                if (signedOut != value)
                {
                    signedOut = value;
                    // Store if we Signed Out so we don't bug the player next time.
                    using (var settings = this.activity.GetSharedPreferences("googleplayservicessettings", FileCreationMode.Private))
                    {
                        using (var e = settings.Edit())
                        {
                            e.PutBoolean("SignedOut", signedOut);
                            e.Commit();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the gravity for the GooglePlay Popups. 
        /// Defaults to Bottom|Center
        /// </summary>
        /// <value>The gravity for popups.</value>
        public GravityFlags GravityForPopups { get; set; }

        /// <summary>
        /// The View on which the Popups should show
        /// </summary>
        /// <value>The view for popups.</value>
        public View ViewForPopups { get; set; }

        /// <summary>
        /// This event is fired when a user successfully signs in
        /// </summary>
        public event EventHandler OnSignedIn;

        /// <summary>
        /// This event is fired when the Sign in fails for any reason
        /// </summary>
        public event EventHandler OnSignInFailed;

        /// <summary>
        /// This event is fired when the user Signs out
        /// </summary>
        public event EventHandler OnSignedOut;

     
        public GameHelper(Activity activity)
        {
            this.activity = activity;
            this.GravityForPopups = GravityFlags.Bottom | GravityFlags.Center;
        }

        public void Initialize()
        {         

            var settings = this.activity.GetSharedPreferences("googleplayservicessettings", FileCreationMode.Private);
            signedOut = settings.GetBoolean("SignedOut", true);

            if (!signedOut)
                CreateClient();
        }

        private void CreateClient()
        {

            // did we log in with a player id already? If so we don't want to ask which account to use
            var settings = this.activity.GetSharedPreferences("googleplayservicessettings", FileCreationMode.Private);
            var id = settings.GetString("playerid", String.Empty);

            var builder = new GoogleApiClient.Builder(activity, this, this);
            builder.AddApi(Android.Gms.Games.GamesClass.API);
            builder.AddScope(Android.Gms.Games.GamesClass.ScopeGames);
            builder.AddApi(Android.Gms.Drive.DriveClass.API);
            builder.AddScope(Android.Gms.Drive.DriveClass.ScopeAppfolder);
            builder.SetGravityForPopups((int)GravityForPopups);
            if (ViewForPopups != null)
                builder.SetViewForPopups(ViewForPopups);
            if (!string.IsNullOrEmpty(id))
            {
                builder.SetAccountName(id);
            }
            client = builder.Build();
        }

        public bool IsConnected()
        {            
            return client != null && client.IsConnected;
        }

        /// <summary>
        /// Start the GooglePlayClient. This should be called from your Activity Start
        /// </summary>
        public void Start()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
                if (Android.App.Application.Context.CheckSelfPermission(Manifest.Permission.Internet) != (int)Permission.Granted
                    || Android.App.Application.Context.CheckSelfPermission(Manifest.Permission.GetAccounts) != (int)Permission.Granted)
            {
                return;
            }
            if (SignedOut && !signingin)
                return;

            if (client != null && !client.IsConnected)
            {
                client.Connect();
            }
        }

        /// <summary>
        /// Disconnects from the GooglePlayClient. This should be called from your Activity Stop
        /// </summary>
        public void Stop()
        {

            if (client != null && client.IsConnected)
            {
                client.Disconnect();
            }
        }

        /// <summary>
        /// Reconnect to google play.
        /// </summary>
        public void Reconnect()
        {
            if (client != null)
                client.Reconnect();
        }

        /// <summary>
        /// Sign out of Google Play and make sure we don't try to auto sign in on the next startup
        /// </summary>
        public void SignOut()
        {
            
            SignedOut = true;
            if (client.IsConnected)
            {
                GamesClass.SignOut(client);
                Stop();
                using (var settings = this.activity.GetSharedPreferences("googleplayservicessettings", FileCreationMode.Private))
                {
                    using (var e = settings.Edit())
                    {
                        e.PutString("playerid", String.Empty);
                        e.Commit();
                    }
                }
                client.Dispose();
                client = null;
                if (OnSignedOut != null)
                    OnSignedOut(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Attempt to Sign in to Google Play
        /// </summary>
        public void SignIn()
        {
            signingin = true;
            if (client == null)
                CreateClient();

            if (client.IsConnected)
                return;

            if (client.IsConnecting)
                return;

            var result = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(activity);
            if (result != ConnectionResult.Success)
            {
                return;
            }

            Start();

        }



        #region IGoogleApiClientConnectionCallbacks implementation

        public async void OnConnected(Android.OS.Bundle connectionHint)
        {
            resolving = false;
            SignedOut = false;
            signingin = false;

            using (var settings = this.activity.GetSharedPreferences("googleplayservicessettings", FileCreationMode.Private))
            {
                using (var e = settings.Edit())
                {
                    e.PutString("playerid", GamesClass.GetCurrentAccountName(client));
                    e.Commit();
                }
            }

            if (OnSignedIn != null)
                OnSignedIn(this, EventArgs.Empty);
        }

        public void OnConnectionSuspended(int resultCode)
        {
            resolving = false;
            SignedOut = false;
            signingin = false;
            client.Disconnect();
            if (OnSignInFailed != null)
                OnSignInFailed(this, EventArgs.Empty);
        }

        public void OnConnectionFailed(ConnectionResult result)
        {

            if (resolving)
                return;

            if (result.HasResolution)
            {
                resolving = true;
                result.StartResolutionForResult(activity, RC_RESOLVE);
                return;
            }

            resolving = false;
            SignedOut = false;
            signingin = false;
            if (OnSignInFailed != null)
                OnSignInFailed(this, EventArgs.Empty);

        }
        #endregion

        /// <summary>
        /// Processes the Activity Results from the Signin process. MUST be called from your activity OnActivityResult override.
        /// </summary>
        /// <param name="requestCode">Request code.</param>
        /// <param name="resultCode">Result code.</param>
        /// <param name="data">Data.</param>
        public void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {

            if (requestCode == RC_RESOLVE)
            {
                if (resultCode == Result.Ok)
                {
                    Start();
                }
                else
                {
                    if (OnSignInFailed != null)
                        OnSignInFailed(this, EventArgs.Empty);
                }
            }
        }
    }
}

