namespace KillTeam.Services
{
    public interface IEnvironment
    {
        Theme GetOperatingSystemTheme();
    }

    public enum Theme { Light, Dark }
}