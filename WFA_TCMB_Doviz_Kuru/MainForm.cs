using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using WFA_TCMB_Doviz_Kuru.Languages;
using WFA_TCMB_Doviz_Kuru.Methods;
using WFA_TCMB_Doviz_Kuru.Models.Entities;
using WFA_TCMB_Doviz_Kuru.Properties;

namespace WFA_TCMB_Doviz_Kuru
{
    public partial class MainForm : Form
    {
        private string urlDownload = "https://www.tcmb.gov.tr/kurlar/today.xml";
        private string path = Path.GetTempPath() + @"today.xml";
        private int id = 0;
        private string from;
        private string to;
        private string selectedCellValue;
        private TarihDate tarihDate = new TarihDate();

        public MainForm()
        {
            InitializeComponent();
            GetLang();
        }

        private void GetLang()
        {
            this.Text = Localization.TCMB;
            fileToolStripMenuItem.Text = Localization.File;
            exitToolStripMenuItem.Text = Localization.Exit;

            toolsToolStripMenuItem.Text = Localization.Tools;
            optionsToolStripMenuItem.Text = Localization.Options + "...";

            helpToolStripMenuItem.Text = Localization.Help;
            openUpdateManagerToolStripMenuItem.Text = Localization.OpenUpdateManager;
            aboutToolStripMenuItem.Text = Localization.About;

            refreshToolStripMenuItem.Text = Localization.Refresh;
            btnRefresh.Text = Localization.Refresh;

            btnGo.Text = Localization.Go;
            btnConvert.Text = Localization.Convert;
            btnSwitchCurrency.Text = Localization.SwitchCurrency;

            lbAmount.Text = Localization.Amount;
            lbFrom.Text = Localization.From;
            lbTo.Text = Localization.To;
        }

        private void DownloadNews()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebClient webclient = new WebClient();
                WebRequest.DefaultWebProxy = null;
                webclient.Proxy = null;
                webclient.UseDefaultCredentials = true;
                webclient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0"); //403
                //Directory.CreateDirectory(Application.StartupPath + @"\Temp");
                webclient.DownloadFileCompleted += WebDownloadFileCompleted;
                webclient.DownloadFileAsync(new Uri(urlDownload), path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WebDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message + "\n\n" + Localization.DateAWeekend);
                }
                else
                {
                    TarihDate items = GetXML.DeserializeXML<TarihDate>(path);
                    this.Text = Localization.TCMB + " -- " + Localization.NewsletterNo + " " + items.BultenNo + " " + Localization.Date + " " + items.Date.ToString();

                    tarihDate = new TarihDate();
                    tarihDate.Tarih = items.Tarih;
                    tarihDate.BultenNo = items.BultenNo;
                    tarihDate.Date = items.Date;

                    if (Settings.Default.LanguageCode == Languages.AllLanguageCodes.TurkishCodeTR || Settings.Default.LanguageCode == Languages.AllLanguageCodes.JapaneseCodeJA_JP)
                    {
                        richTextBox1.Text = string.Format("{0} {1} {2}", tarihDate.Date, Localization.TCMB_Warning, Localization.TCMB_Warning2);
                    }
                    else if (Settings.Default.LanguageCode == Languages.AllLanguageCodes.EnglishCodeGB_UK || Settings.Default.LanguageCode == Languages.AllLanguageCodes.EnglishCodeUS || Settings.Default.LanguageCode == Languages.AllLanguageCodes.RussianCodeRU_RU || Settings.Default.LanguageCode == Languages.AllLanguageCodes.GermanCodeDE_DE || Settings.Default.LanguageCode == Languages.AllLanguageCodes.FranceCodeFR_FR)
                    {
                        richTextBox1.Text = string.Format("{1} {0} {2}", tarihDate.Date, Localization.TCMB_Warning, Localization.TCMB_Warning2);
                    }

                    foreach (var currency in items.Currencies)
                    {
                        if (currency.CrossOrder.ToString() == id.ToString())
                        {
                            Models.Entities.Currency usa = new Models.Entities.Currency();

                            usa.CrossOrder = currency.CrossOrder;
                            usa.CurrencyName = currency.CurrencyName;

                            usa.CurrencyCode = currency.CurrencyCode;
                            if (currency.CurrencyCode == "USD")
                            {
                                usa.Isim = Localization.USD;
                            }
                            else if (currency.CurrencyCode == "AUD")
                            {
                                usa.Isim = Localization.AUD;
                            }
                            else if (currency.CurrencyCode == "ATS") //OLD
                            {
                                usa.Isim = Localization.ATS;
                            }
                            else if (currency.CurrencyCode == "DKK")
                            {
                                usa.Isim = Localization.DKK;
                            }
                            else if (currency.CurrencyCode == "EUR")
                            {
                                usa.Isim = Localization.EUR;
                            }
                            else if (currency.CurrencyCode == "GBP")
                            {
                                usa.Isim = Localization.GBP;
                            }
                            else if (currency.CurrencyCode == "CHF")
                            {
                                usa.Isim = Localization.CHF;
                                usa.CurrencyName = "SWISS FRANC";
                            }
                            else if (currency.CurrencyCode == "SEK")
                            {
                                usa.Isim = Localization.SEK;
                            }
                            else if (currency.CurrencyCode == "CAD")
                            {
                                usa.Isim = Localization.CAD;
                            }
                            else if (currency.CurrencyCode == "KWD")
                            {
                                usa.Isim = Localization.KWD;
                            }
                            else if (currency.CurrencyCode == "NOK")
                            {
                                usa.Isim = Localization.NOK;
                            }
                            else if (currency.CurrencyCode == "SAR")
                            {
                                usa.Isim = Localization.SAR;
                            }
                            else if (currency.CurrencyCode == "JPY")
                            {
                                usa.Isim = Localization.JPY;
                                usa.CurrencyName = "JAPANESE YEN";
                            }
                            else if (currency.CurrencyCode == "BGN")
                            {
                                usa.Isim = Localization.BGN;
                            }
                            else if (currency.CurrencyCode == "BGL") //OLD
                            {
                                usa.Isim = Localization.BGL;
                            }
                            else if (currency.CurrencyCode == "RON")
                            {
                                usa.Isim = Localization.RON;
                                usa.CurrencyName = "ROMANIAN LEU";
                            }
                            else if (currency.CurrencyCode == "RUB")
                            {
                                usa.Isim = Localization.RUB;
                            }
                            else if (currency.CurrencyCode == "IRR")
                            {
                                usa.Isim = Localization.IRR;
                            }
                            else if (currency.CurrencyCode == "CNY")
                            {
                                usa.Isim = Localization.CNY;
                            }
                            else if (currency.CurrencyCode == "PKR")
                            {
                                usa.Isim = Localization.PKR;
                            }
                            else if (currency.CurrencyCode == "QAR")
                            {
                                usa.Isim = Localization.QAR;
                            }
                            else if (currency.CurrencyCode == "KRW")
                            {
                                usa.Isim = Localization.KRW;
                            }
                            else if (currency.CurrencyCode == "AZN")
                            {
                                usa.Isim = Localization.AZN;
                            }
                            else if (currency.CurrencyCode == "AED")
                            {
                                usa.Isim = Localization.AED;
                            }
                            else if (currency.CurrencyCode == "XDR")
                            {
                                usa.Isim = Localization.XDR;
                                usa.CurrencyName = "SPECIAL DRAWING RIGHT (SDR)";
                            }
                            else if (currency.CurrencyCode == "BEF") //OLD
                            {
                                usa.Isim = Localization.BEF;
                            }
                            else if (currency.CurrencyCode == "DEM") //OLD
                            {
                                usa.Isim = Localization.DEM;
                                usa.CurrencyName = "GERMAN MARK";
                            }
                            else if (currency.CurrencyCode == "FRF") //OLD 
                            {
                                usa.Isim = Localization.FRF;
                            }
                            else if (currency.CurrencyCode == "FYP")
                            {
                                usa.Isim = Localization.FYP;
                                usa.CurrencyName = "SYRIAN POUND (LIRA)";
                            }
                            else if (currency.CurrencyCode == "NLG") //OLD
                            {
                                usa.Isim = Localization.NLG;
                            }
                            else if (currency.CurrencyCode == "IEP") //OLD
                            {
                                usa.Isim = Localization.IEP;
                            }
                            else if (currency.CurrencyCode == "ITL") //OLD
                            {
                                usa.Isim = Localization.ITL;
                            }
                            else if (currency.CurrencyCode == "LUF") //OLD
                            {
                                usa.Isim = Localization.LUF;
                            }
                            else if (currency.CurrencyCode == "FIM") //OLD
                            {
                                usa.Isim = Localization.FIM;
                            }
                            else if (currency.CurrencyCode == "ESP") //OLD
                            {
                                usa.Isim = Localization.ESP;
                            }
                            else if (currency.CurrencyCode == "PTE") //OLD
                            {
                                usa.Isim = Localization.PTE;
                            }
                            else if (currency.CurrencyCode == "GRD") //OLD
                            {
                                usa.Isim = Localization.GRD;
                            }
                            else if (currency.CurrencyCode == "JOD") //OLD
                            {
                                usa.Isim = Localization.JOD;
                            }
                            else if (currency.CurrencyCode == "ROL") //OLD
                            {
                                usa.Isim = Localization.ROL;
                            }
                            else if (currency.CurrencyCode == "ILS")
                            {
                                usa.Isim = Localization.ILS;
                                usa.CurrencyName = "NEW ISRAELI SHEKEL";
                            }
                            else if (currency.CurrencyCode == "ECU") //OLD
                            {
                                usa.Isim = Localization.ECU;
                            }
                            else if (currency.CurrencyCode == "SYP")
                            {
                                usa.Isim = Localization.SYP;
                            }
                            //else
                            //{
                            //    usa.Isim = currency.Isim;
                            //}

                            usa.Unit = currency.Unit;
                            usa.ForexBuying = currency.ForexBuying;
                            usa.ForexSelling = currency.ForexSelling;
                            usa.BanknoteBuying = currency.BanknoteBuying;
                            usa.BanknoteSelling = currency.BanknoteSelling;
                            usa.CrossRateUSD = currency.CrossRateUSD;
                            usa.CrossRateOther = currency.CrossRateOther;
                            usa.Kod = currency.Kod;
                            tarihDate.Currencies.Add(usa);
                        }
                        else
                        {
                            Models.Entities.Currency usa = new Models.Entities.Currency();

                            usa.CrossOrder = currency.CrossOrder;
                            usa.CurrencyName = currency.CurrencyName;

                            usa.CurrencyCode = currency.CurrencyCode;
                            if (currency.CurrencyCode == "USD")
                            {
                                usa.Isim = Localization.USD;
                            }
                            else if (currency.CurrencyCode == "AUD")
                            {
                                usa.Isim = Localization.AUD;
                            }
                            else if (currency.CurrencyCode == "ATS") //OLD
                            {
                                usa.Isim = Localization.ATS;
                            }
                            else if (currency.CurrencyCode == "DKK")
                            {
                                usa.Isim = Localization.DKK;
                            }
                            else if (currency.CurrencyCode == "EUR")
                            {
                                usa.Isim = Localization.EUR;
                            }
                            else if (currency.CurrencyCode == "GBP")
                            {
                                usa.Isim = Localization.GBP;
                            }
                            else if (currency.CurrencyCode == "CHF")
                            {
                                usa.Isim = Localization.CHF;
                                usa.CurrencyName = "SWISS FRANC";
                            }
                            else if (currency.CurrencyCode == "SEK")
                            {
                                usa.Isim = Localization.SEK;
                            }
                            else if (currency.CurrencyCode == "CAD")
                            {
                                usa.Isim = Localization.CAD;
                            }
                            else if (currency.CurrencyCode == "KWD")
                            {
                                usa.Isim = Localization.KWD;
                            }
                            else if (currency.CurrencyCode == "NOK")
                            {
                                usa.Isim = Localization.NOK;
                            }
                            else if (currency.CurrencyCode == "SAR")
                            {
                                usa.Isim = Localization.SAR;
                            }
                            else if (currency.CurrencyCode == "JPY")
                            {
                                usa.Isim = Localization.JPY;
                                usa.CurrencyName = "JAPANESE YEN";
                            }
                            else if (currency.CurrencyCode == "BGN")
                            {
                                usa.Isim = Localization.BGN;
                            }
                            else if (currency.CurrencyCode == "BGL") //OLD
                            {
                                usa.Isim = Localization.BGL;
                            }
                            else if (currency.CurrencyCode == "RON")
                            {
                                usa.Isim = Localization.RON;
                                usa.CurrencyName = "ROMANIAN LEU";
                            }
                            else if (currency.CurrencyCode == "RUB")
                            {
                                usa.Isim = Localization.RUB;
                            }
                            else if (currency.CurrencyCode == "IRR")
                            {
                                usa.Isim = Localization.IRR;
                            }
                            else if (currency.CurrencyCode == "CNY")
                            {
                                usa.Isim = Localization.CNY;
                            }
                            else if (currency.CurrencyCode == "PKR")
                            {
                                usa.Isim = Localization.PKR;
                            }
                            else if (currency.CurrencyCode == "QAR")
                            {
                                usa.Isim = Localization.QAR;
                            }
                            else if (currency.CurrencyCode == "KRW")
                            {
                                usa.Isim = Localization.KRW;
                            }
                            else if (currency.CurrencyCode == "AZN")
                            {
                                usa.Isim = Localization.AZN;
                            }
                            else if (currency.CurrencyCode == "AED")
                            {
                                usa.Isim = Localization.AED;
                            }
                            else if (currency.CurrencyCode == "XDR")
                            {
                                usa.Isim = Localization.XDR;
                                usa.CurrencyName = "SPECIAL DRAWING RIGHT (SDR)";
                            }
                            else if (currency.CurrencyCode == "BEF") //OLD
                            {
                                usa.Isim = Localization.BEF;
                            }
                            else if (currency.CurrencyCode == "DEM") //OLD
                            {
                                usa.Isim = Localization.DEM;
                                usa.CurrencyName = "GERMAN MARK";
                            }
                            else if (currency.CurrencyCode == "FRF") //OLD 
                            {
                                usa.Isim = Localization.FRF;
                            }
                            else if (currency.CurrencyCode == "FYP")
                            {
                                usa.Isim = Localization.FYP;
                                usa.CurrencyName = "SYRIAN POUND (LIRA)";
                            }
                            else if (currency.CurrencyCode == "NLG") //OLD
                            {
                                usa.Isim = Localization.NLG;
                            }
                            else if (currency.CurrencyCode == "IEP") //OLD
                            {
                                usa.Isim = Localization.IEP;
                            }
                            else if (currency.CurrencyCode == "ITL") //OLD
                            {
                                usa.Isim = Localization.ITL;
                            }
                            else if (currency.CurrencyCode == "LUF") //OLD
                            {
                                usa.Isim = Localization.LUF;
                            }
                            else if (currency.CurrencyCode == "FIM") //OLD
                            {
                                usa.Isim = Localization.FIM;
                            }
                            else if (currency.CurrencyCode == "ESP") //OLD
                            {
                                usa.Isim = Localization.ESP;
                            }
                            else if (currency.CurrencyCode == "PTE") //OLD
                            {
                                usa.Isim = Localization.PTE;
                            }
                            else if (currency.CurrencyCode == "GRD") //OLD
                            {
                                usa.Isim = Localization.GRD;
                            }
                            else if (currency.CurrencyCode == "JOD") //OLD
                            {
                                usa.Isim = Localization.JOD;
                            }
                            else if (currency.CurrencyCode == "ROL") //OLD
                            {
                                usa.Isim = Localization.ROL;
                            }
                            else if (currency.CurrencyCode == "ILS")
                            {
                                usa.Isim = Localization.ILS;
                                usa.CurrencyName = "NEW ISRAELI SHEKEL";
                            }
                            else if (currency.CurrencyCode == "ECU") //OLD
                            {
                                usa.Isim = Localization.ECU;
                            }
                            else if (currency.CurrencyCode == "SYP")
                            {
                                usa.Isim = Localization.SYP;
                            }
                            //else
                            //{
                            //    usa.Isim = currency.Isim;
                            //}

                            usa.Unit = currency.Unit;
                            usa.ForexBuying = currency.ForexBuying;
                            usa.ForexSelling = currency.ForexSelling;
                            usa.BanknoteBuying = currency.BanknoteBuying;
                            usa.BanknoteSelling = currency.BanknoteSelling;
                            usa.CrossRateUSD = currency.CrossRateUSD;
                            usa.CrossRateOther = currency.CrossRateOther;
                            usa.Kod = currency.Kod;
                            tarihDate.Currencies.Add(usa);
                        }
                        id = id + 1;
                    }
                }
                dataGridView1.DataSource = tarihDate.Currencies;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetOldDateCurrencies(DateTime date)
        {
            string year = String.Format("{0:0000}", date.Year);
            string month = String.Format("{0:00}", date.Month);
            string day = String.Format("{0:00}", date.Day);

            if (DayOfWeek.Saturday == date.DayOfWeek || DayOfWeek.Sunday == date.DayOfWeek)
            {
                MessageBox.Show(Localization.SpecifiedAWeekend);
            }
            else
            {
                //urlDownload = string.Format("https://www.tcmb.gov.tr/kurlar/{0}/{1}.xml", "200001", "03012000");
                urlDownload = string.Format("https://www.tcmb.gov.tr/kurlar/{0}/{1}.xml", year + month, day + month + year);
                RefreshEvent();
            }

            //return tarihDate;
        }

        private void RefreshEvent()
        {
            try
            {
                DownloadNews();
                dataGridView1.DataSource = tarihDate.Currencies;

                dataGridView1.Columns["CrossOrder"].HeaderText = "No";
                dataGridView1.Columns["CrossOrder"].DisplayIndex = 0;

                dataGridView1.Columns["CurrencyCode"].HeaderText = Localization.CurrencyCode;
                dataGridView1.Columns["CurrencyCode"].DisplayIndex = 1;

                dataGridView1.Columns["Isim"].HeaderText = Localization.CurrencyName;
                dataGridView1.Columns["Isim"].DisplayIndex = 2;

                dataGridView1.Columns["CurrencyName"].HeaderText = Localization.CurrencyNameEnglish;
                dataGridView1.Columns["CurrencyName"].DisplayIndex = 3;

                dataGridView1.Columns["Unit"].DisplayIndex = 4;
                dataGridView1.Columns["Unit"].HeaderText = Localization.Unit;

                dataGridView1.Columns["ForexBuying"].HeaderText = Localization.ForexBuying;
                dataGridView1.Columns["ForexBuying"].DisplayIndex = 5;

                dataGridView1.Columns["ForexSelling"].HeaderText = Localization.ForexSelling;
                dataGridView1.Columns["ForexSelling"].DisplayIndex = 6;

                dataGridView1.Columns["BanknoteBuying"].HeaderText = Localization.BanknoteBuying;
                dataGridView1.Columns["BanknoteBuying"].DisplayIndex = 7;

                dataGridView1.Columns["BanknoteSelling"].HeaderText = Localization.BanknoteSelling;
                dataGridView1.Columns["BanknoteSelling"].DisplayIndex = 8;

                dataGridView1.Columns["CrossRateUSD"].HeaderText = Localization.CrossRateUSD;
                dataGridView1.Columns["CrossRateUSD"].DisplayIndex = 9;

                dataGridView1.Columns["CrossRateOther"].HeaderText = Localization.CrossRateOther;
                dataGridView1.Columns["CrossRateOther"].DisplayIndex = 10;

                dataGridView1.Columns["Kod"].HeaderText = Localization.CurrencyCode;
                dataGridView1.Columns["Kod"].DisplayIndex = 11;
                dataGridView1.Columns["Kod"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            urlDownload = "https://www.tcmb.gov.tr/kurlar/today.xml";
            RefreshEvent();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urlDownload = "https://www.tcmb.gov.tr/kurlar/today.xml";
            RefreshEvent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openUpdateManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateManager.UpdateManagerForm updateManagerForm = new UpdateManager.UpdateManagerForm("WFA_TCMB_Doviz_Kuru", "https://raw.githubusercontent.com/firatlogoglu/TCMB_Doviz_Kuru/master/NEWVERSION", "https://github.com/firatlogoglu/TCMB_Doviz_Kuru/releases/", "https://raw.githubusercontent.com/firatlogoglu/TCMB_Doviz_Kuru/master/SHA256");
            updateManagerForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsFrm optionsFrm = new OptionsFrm();
            optionsFrm.ShowDialog();
        }

        public void ConvertCurrency()
        {
            try
            {
                foreach (var item in tarihDate.Currencies)
                {
                    if (item.CurrencyCode == selectedCellValue)
                    {
                        decimal adf;
                        int unit = Convert.ToInt32(item.Unit);
                        decimal forexBuy = Convert.ToDecimal(item.ForexBuying.Replace('.', ','));
                        decimal amount = Convert.ToDecimal(textBox1.Text);

                        if (from == selectedCellValue)
                        {
                            adf = amount / (unit / forexBuy);
                        }
                        else
                        {
                            adf = amount * (unit / forexBuy);
                        }

                        textBox2.Text = Math.Round(adf, 4).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                selectedCellValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                from = selectedCellValue;
                to = "TRY";
                lbFrom.Text = Localization.From + " " + from;
                lbTo.Text = Localization.To + " " + to;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            GetOldDateCurrencies(dateTimePicker.Value);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void btnSwitchCurrency_Click(object sender, EventArgs e)
        {
            if (from == selectedCellValue)
            {
                from = to;
                to = selectedCellValue;

                lbFrom.Text = Localization.From + " " + from;
                lbTo.Text = Localization.To + " " + to;
            }
            else
            {
                from = selectedCellValue;
                to = "TRY";

                lbFrom.Text = Localization.From + " " + from;
                lbTo.Text = Localization.To + " " + to;
            }
        }
    }
}