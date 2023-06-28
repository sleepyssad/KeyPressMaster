using KeyPressMaster.Model.Enums;

namespace KeyPressMaster
{
    public sealed partial class Storage : System.Configuration.ApplicationSettingsBase
    {
        private static Storage defaultInstance = ((Storage)(Synchronized(new Storage())));
        public static Storage Default { get { return defaultInstance; } }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("")]
        public AppTheme CurrentTheme
        {
            get => ((AppTheme)(this[nameof(CurrentTheme)]));
            set
            {
                this[nameof(CurrentTheme)] = value;
                Save();
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("")]
        public bool AutoRun
        {
            get => ((bool)(this[nameof(AutoRun)]));
            set
            {
                this[nameof(AutoRun)] = value;
                Save();
            }
        }
    }
}
