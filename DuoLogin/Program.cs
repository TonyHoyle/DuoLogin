using System;
using System.Windows.Forms;
using CefSharp;

namespace DuoLogin
{
    static class Global
    {
        private static string _SigRequest;

        public static string ApiHostname { get { return Properties.Settings.Default.ApiHostname; } }
        public static string IntegrationKey { get { return Properties.Settings.Default.IntegrationKey; } }
        public static string SecretKey { get { return Properties.Settings.Default.SecretKey; } }
        public static string RandomKey { get { return Properties.Settings.Default.RandomKey; } }
        public static string SigRequest { get { return _SigRequest; } set { _SigRequest = value; } }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Cef.EnableHighDPISupport();
            var settings = new CefSettings() { CommandLineArgsDisabled = true, CachePath = "" };
            var factory = new LocalSchemeHandlerFactory();
            settings.RegisterScheme(new CefCustomScheme
            {
                SchemeName = LocalSchemeHandlerFactory.SchemeName,
                SchemeHandlerFactory = factory
            });
            Cef.Initialize(settings);
            var form = new LoginForm();
            factory.parentForm = form;
            Application.Run(form);
        }
    }
}
