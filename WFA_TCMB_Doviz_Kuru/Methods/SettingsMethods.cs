using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA_TCMB_Doviz_Kuru.Languages;
using WFA_TCMB_Doviz_Kuru.Properties;

namespace WFA_TCMB_Doviz_Kuru.Methods
{
    internal class SettingsMethods
    {
        internal static string[] GetAllLanguageCodes()
        {
            string[] alllangcodes = new string[7];
            alllangcodes[0] = AllLanguageCodes.TurkishCodeTR;
            alllangcodes[1] = AllLanguageCodes.EnglishCodeUS;
            alllangcodes[2] = AllLanguageCodes.EnglishCodeGB_UK;
            alllangcodes[3] = AllLanguageCodes.RussianCodeRU_RU;
            alllangcodes[4] = AllLanguageCodes.GermanCodeDE_DE;
            alllangcodes[5] = AllLanguageCodes.FranceCodeFR_FR;
            alllangcodes[6] = AllLanguageCodes.JapaneseCodeJA_JP;

            return alllangcodes;
        }

        internal static string[] GetAllLanguageDisplayNames()
        {
            string[] alllangcodes = new string[7];
            alllangcodes[0] = GetLanguageDisplayName(AllLanguageCodes.TurkishCodeTR);
            alllangcodes[1] = GetLanguageDisplayName(AllLanguageCodes.EnglishCodeUS);
            alllangcodes[2] = GetLanguageDisplayName(AllLanguageCodes.EnglishCodeGB_UK);
            alllangcodes[3] = GetLanguageDisplayName(AllLanguageCodes.RussianCodeRU_RU);
            alllangcodes[4] = GetLanguageDisplayName(AllLanguageCodes.GermanCodeDE_DE);
            alllangcodes[5] = GetLanguageDisplayName(AllLanguageCodes.FranceCodeFR_FR);
            alllangcodes[6] = GetLanguageDisplayName(AllLanguageCodes.JapaneseCodeJA_JP);

            return alllangcodes;
        }

        internal static void SetLanguage(string languageCode)
        {
            Localization.Culture = new CultureInfo(languageCode);
            Settings.Default.Language = GetLanguageDisplayName(languageCode);
            Settings.Default.LanguageCode = languageCode;
            Settings.Default.Save();
            Application.Restart();
        }

        internal static void SetLanguage2(string languageCode)
        {
            Localization.Culture = new CultureInfo(languageCode);
            Settings.Default.Language = GetLanguageDisplayName(languageCode);
            Settings.Default.LanguageCode = languageCode;
            Settings.Default.Save();
            Application.Exit();
        }


        internal static void SetCurrentUILanguage()
        {
            string getuilangcode = GetCurrentUILanguageCode();

            if (AllLanguageCodes.EnglishCodeGB_UK == getuilangcode)
            {
                SetLanguage2(getuilangcode);
            }

            if (AllLanguageCodes.EnglishCodeUS == getuilangcode)
            {
                SetLanguage2(getuilangcode);
            }

            if (AllLanguageCodes.TurkishCodeTR == getuilangcode)
            {
                SetLanguage2(getuilangcode);
            }

            if (AllLanguageCodes.RussianCodeRU_RU == getuilangcode)
            {
                SetLanguage2(getuilangcode);
            }

            if (AllLanguageCodes.GermanCodeDE_DE == getuilangcode)
            {
                SetLanguage2(getuilangcode);
            }

            if (AllLanguageCodes.FranceCodeFR_FR == getuilangcode)
            {
                SetLanguage2(getuilangcode);
            }

            if (AllLanguageCodes.JapaneseCodeJA_JP == getuilangcode)
            {
                SetLanguage2(getuilangcode);
            }

            if (AllLanguageCodes.EnglishCodeGB_UK != getuilangcode && AllLanguageCodes.EnglishCodeUS != getuilangcode && AllLanguageCodes.TurkishCodeTR != getuilangcode && AllLanguageCodes.RussianCodeRU_RU != getuilangcode && AllLanguageCodes.GermanCodeDE_DE != getuilangcode && AllLanguageCodes.FranceCodeFR_FR != getuilangcode && AllLanguageCodes.JapaneseCodeJA_JP != getuilangcode)
            {
                MessageBox.Show("There is no " + GetLanguageDisplayName(getuilangcode) + " language support in this software.");

                SetLanguage2(AllLanguageCodes.EnglishCodeGB_UK);
            }
        }

        internal static void GetLanguageApplication()
        {
            string defaultLanguage = Settings.Default.Language;
            string defaultLanguagecode = Settings.Default.LanguageCode;

            if (defaultLanguage == GetLanguageDisplayName(AllLanguageCodes.TurkishCodeTR) || defaultLanguagecode == AllLanguageCodes.TurkishCodeTR)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(AllLanguageCodes.TurkishCodeTR);
            }
            else if (defaultLanguage == GetLanguageDisplayName(AllLanguageCodes.EnglishCodeUS) || defaultLanguagecode == AllLanguageCodes.EnglishCodeUS)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(AllLanguageCodes.EnglishCodeUS);
            }
            else if (defaultLanguage == GetLanguageDisplayName(AllLanguageCodes.EnglishCodeGB_UK) || defaultLanguagecode == AllLanguageCodes.EnglishCodeGB_UK)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(AllLanguageCodes.EnglishCodeGB_UK);
            }
            else if (defaultLanguage == GetLanguageDisplayName(AllLanguageCodes.RussianCodeRU_RU) || defaultLanguagecode == AllLanguageCodes.RussianCodeRU_RU)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(AllLanguageCodes.RussianCodeRU_RU);
            }
            else if (defaultLanguage == GetLanguageDisplayName(AllLanguageCodes.GermanCodeDE_DE) || defaultLanguagecode == AllLanguageCodes.GermanCodeDE_DE)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(AllLanguageCodes.GermanCodeDE_DE);
            }
            else if (defaultLanguage == GetLanguageDisplayName(AllLanguageCodes.FranceCodeFR_FR) || defaultLanguagecode == AllLanguageCodes.FranceCodeFR_FR)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(AllLanguageCodes.FranceCodeFR_FR);
            }
            else if (defaultLanguage == GetLanguageDisplayName(AllLanguageCodes.JapaneseCodeJA_JP) || defaultLanguagecode == AllLanguageCodes.JapaneseCodeJA_JP)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(AllLanguageCodes.JapaneseCodeJA_JP);
            }
            else
            {
                SetCurrentUILanguage();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        internal static string GetLanguageDisplayName(string languageCode = null)
        {
            if (languageCode == "" || languageCode == null)
            {
                return new CultureInfo(GetCurrentUILanguageCode()).DisplayName;
            }
            else
            {
                return new CultureInfo(languageCode).DisplayName;
            }
        }

        internal static string GetCurrentUILanguageCode()
        {
            return CultureInfo.CurrentUICulture.Name;
        }
    }
}
