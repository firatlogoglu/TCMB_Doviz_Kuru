using System;
using System.Windows.Forms;
using WFA_TCMB_Doviz_Kuru.Methods;

namespace WFA_TCMB_Doviz_Kuru
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SettingsMethods.GetLanguageApplication();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ShowUpdateManagerFrm();

            Application.Run(new MainForm());
        }

        private static void ShowUpdateManagerFrm()
        {
            Application.Run(new UpdateManager.UpdateManagerForm("TCMB_Doviz_Kuru", "https://raw.githubusercontent.com/firatlogoglu/TCMB_Doviz_Kuru/master/NEWVERSION", "https://github.com/firatlogoglu/TCMB_Doviz_Kuru/releases/", "https://raw.githubusercontent.com/firatlogoglu/TCMB_Doviz_Kuru/master/SHA256"));
        }
    }
}