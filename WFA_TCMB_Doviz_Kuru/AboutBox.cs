using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using WFA_TCMB_Doviz_Kuru.Languages;

namespace WFA_TCMB_Doviz_Kuru
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            if (Thread.CurrentThread.CurrentUICulture.Name == AllLanguageCodes.TurkishCodeTR)
            {
                this.Text = String.Format("{0} {1}", AssemblyTitle, Localization.About);
            }
            else
            {
                this.Text = String.Format("{0} {1}", Localization.About, AssemblyTitle);
            }

            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("{0} {1}", Localization.Version, AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright + " - " + DateTime.Now.Year;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
            this.okButton.Text = Localization.OK;
        }

        #region Derleme Öznitelik Erişimcileri

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}