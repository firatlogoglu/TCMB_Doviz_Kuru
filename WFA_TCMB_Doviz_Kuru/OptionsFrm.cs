using System;
using System.Windows.Forms;
using WFA_TCMB_Doviz_Kuru.Languages;
using WFA_TCMB_Doviz_Kuru.Methods;
using WFA_TCMB_Doviz_Kuru.Properties;

namespace WFA_TCMB_Doviz_Kuru
{
    public partial class OptionsFrm : Form
    {
        private bool cmbBoxLangsec;
        public OptionsFrm()
        {
            InitializeComponent();
            GetLanguagesList();
            GetSettings();
            GetLang();
        }

        private void GetLang()
        {
            this.Text = Localization.Options;

            lbLang.Text = Localization.Language;

            tabPageGeneral.Text = Localization.General;
        }

        private void GetSettings()
        {
            cmbBoxLang.SelectedItem = SettingsMethods.GetLanguageDisplayName(Settings.Default.LanguageCode);
            cmbBoxLangsec = true;
        }

        private void GetLanguagesList()
        {
            object[] ob = SettingsMethods.GetAllLanguageDisplayNames();
            cmbBoxLang.Items.AddRange(ob);
        }

        private void cmbBoxLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxLangsec)
            {
                if (cmbBoxLang.Text == SettingsMethods.GetLanguageDisplayName(AllLanguageCodes.TurkishCodeTR))
                {
                    SettingsMethods.SetLanguage(AllLanguageCodes.TurkishCodeTR);
                }
                else if (cmbBoxLang.Text == SettingsMethods.GetLanguageDisplayName(AllLanguageCodes.EnglishCodeUS))
                {
                    SettingsMethods.SetLanguage(AllLanguageCodes.EnglishCodeUS);
                }
                else if (cmbBoxLang.Text == SettingsMethods.GetLanguageDisplayName(AllLanguageCodes.EnglishCodeGB_UK))
                {
                    SettingsMethods.SetLanguage(AllLanguageCodes.EnglishCodeGB_UK);
                }
                else if (cmbBoxLang.Text == SettingsMethods.GetLanguageDisplayName(AllLanguageCodes.RussianCodeRU_RU))
                {
                    SettingsMethods.SetLanguage(AllLanguageCodes.RussianCodeRU_RU);
                }
                else if (cmbBoxLang.Text == SettingsMethods.GetLanguageDisplayName(AllLanguageCodes.GermanCodeDE_DE))
                {
                    SettingsMethods.SetLanguage(AllLanguageCodes.GermanCodeDE_DE);
                }
                else if (cmbBoxLang.Text == SettingsMethods.GetLanguageDisplayName(AllLanguageCodes.FranceCodeFR_FR))
                {
                    SettingsMethods.SetLanguage(AllLanguageCodes.FranceCodeFR_FR);
                }
                else if (cmbBoxLang.Text == SettingsMethods.GetLanguageDisplayName(AllLanguageCodes.JapaneseCodeJA_JP))
                {
                    SettingsMethods.SetLanguage(AllLanguageCodes.JapaneseCodeJA_JP);
                }
                else
                {
                    SettingsMethods.SetLanguage(AllLanguageCodes.EnglishCodeGB_UK);
                }
            }
        }
    }
}