using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace KillTeam.Behaviors
{
    public class SwitchBehavior : Behavior<Switch>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(SwitchBehavior));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public Switch Bindable { get; private set; }

        protected override void OnAttachedTo(Switch bindable)
        {
            base.OnAttachedTo(bindable);
            Bindable = bindable;
            Bindable.BindingContextChanged += OnBindingContextChanged;
            Bindable.Toggled += OnSwitchToggled;
        }

        protected override void OnDetachingFrom(Switch bindable)
        {
            base.OnDetachingFrom(bindable);
            Bindable.BindingContextChanged -= OnBindingContextChanged;
            Bindable.Toggled -= OnSwitchToggled;
            Bindable = null;
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
            BindingContext = Bindable.BindingContext;
        }

        private void OnSwitchToggled(object sender, ToggledEventArgs e)
        {
            Command?.Execute(e.Value);
        }
    }
}