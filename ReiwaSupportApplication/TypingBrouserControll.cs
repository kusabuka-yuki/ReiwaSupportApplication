using NPOI.SS.Formula.PTG;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ReiwaSupportApplication
{
    internal class TypingBrouserControll
    {
        private ChromeDriver driver;

        internal OccupationExcelData OccupationExcelData { get; private set; }
        internal Url Url { get; private set; }

        internal TypingBrouserControll(OccupationExcelData occupationExcelData, Url url) 
        { 
            this.OccupationExcelData = occupationExcelData;
            this.Url= url;
        }
        internal void TypedBrouserControll()
        {
            try
            {

                driver = new ChromeDriver();

                // サイトを表示する
                driver.Navigate().GoToUrl(Url.Value);

                // コントロールの取得
                var companyXpaths = new List<string>()
                {
                    "//p[contains(text(), '会社名')]/parent::dt/parent::dl//input",
                    "//input[@name='会社名']",
                    "//input[@name='yourcompany']",
                    "//input[@name='company']",
                    "//input[@name='companyname']",
                    "//span[contains(text(), '会社名')]/parent::label/parent::li//input",
                };
                var nameXpths = new List<string>()
                {
                    "//label[contains(text(), '名前')]/parent::div/parent::div//input",
                    "//th[contains(text(), '名前')]/parent::tr//input",
                    "//label[contains(text(), '名前')]//input",
                    "//div[contains(text(), '名前')]/parent::td/parent::tr//input",
                    "//input[@name='お名前']",
                    "//p[contains(text(), '名前')]/parent::th/parent::tr//input",
                    "//input[@name='name']",
                    "//input[@name='your-name']",
                    "//input[@name='username']",
                    "//div[contains(text(), '名前')]/parent::div//input",
                    "//dt[contains(text(), '名前')]/parent::dl//input",
                    "//span[contains(text(), '名前')]/parent::label/parent::li//input",
                };
                var nameKanaXpaths = new List<string>()
                {
                    "//th[contains(text(), 'ふりがな')]/parent::tr//input",
                    "//dt[contains(text(), 'ふりがな')]/parent::dl//input",
                    "//input[@name='kana']",
                    "//input[@name='furigana']",
                    "//input[@name='kana-name']",
                    "//input[@name='userkana']",
                };
                var nameKataXpaths = new List<string>()
                {
                    "//p[contains(text(), 'ガナ')]/parent::dt/parent::dl//input",
                    "//div[contains(text(), 'ガナ')]/parent::td/parent::tr//input",
                    "//div[contains(text(), 'ガナ')]/parent::div//input",
                    "//dt[contains(text(), 'ガナ')]/parent::dl//input"
                };
                var addressXpths = new List<string>()
                {
                    "//th[contains(text(), '住所')]/parent::tr//input",
                    "//label[contains(text(), '住所')]/parent::div/parent::div//input",
                    "//p[contains(text(), '住所')]/parent::th/parent::tr//input",
                    "//input[@name='address']",
                    "//input[@name='addr']",
                    "//input[@name='jyusho']",
                    "//input[@name='useraddress2']",
                    "//span[contains(text(), '住所')]/parent::label/parent::li//input",
                };
                var postXpths = new List<string>()
                {
                    "//label[contains(text(), '郵便')]/parent::div/parent::div//input",
                    "//th[contains(text(), '郵便')]/parent::tr//input",
                    "//input[contains(@placeholder, '〒')]",
                    "//p[contains(text(), '郵便')]/parent::th/parent::tr//input",
                    "//input[@name='youbin']",
                    "//dt[contains(text(), '郵便')]/parent::dl//input",
                    "//span[contains(text(), '郵便')]/parent::label/parent::li//input",
                };
                var telXpath = new List<string>()
                {
                    "//input[@type='tel']",
                    "//th[contains(text(), '電話')]/parent::tr//input",
                    "//p[contains(text(), '電話')]/parent::dt/parent::dl//input",
                    "//div[contains(text(), '電話')]/parent::td/parent::tr//input",
                    "//input[@name='phone']",
                    "//input[@name='tel']",
                    "//input[@name='usertel']",
                    "//div[contains(text(), '電話')]/parent::div//input",
                    "//dt[contains(text(), '電話')]/parent::dl//input",
                    "//span[contains(text(), '電話')]/parent::label/parent::li//input",

                };
                var faxXpath = new List<string>()
                {
                    "//input[@type='fax']",
                    "//th[contains(text(), 'FAX')]/parent::tr//input",
                    "//p[contains(text(), 'FAX')]/parent::dt/parent::dl//input",
                    "//div[contains(text(), 'FAX')]/parent::td/parent::tr//input",
                    "//input[@name='fax']",
                    "//dt[contains(text(), 'FAX')]/parent::dl//input",
                };
                var emailXpaths = new List<string>()
                {
                    "//input[@type='email']",
                    "//th[contains(text(), 'メールアドレス')]/parent::tr//input",
                    "//div[contains(text(), 'メールアドレス')]/parent::td/parent::tr//input",
                    "//input[@name='メールアドレス']",
                    "//input[@name='email']",
                    "//input[@name='email1']",
                    "//input[@name='yourmail']",
                    "//input[@name='usermail']",
                    "//span[contains(text(), 'メール')]/parent::label/parent::li//input",
                };
                var confirmEmailXpaths = new List<string>()
                {
                    "//th[contains(text(), '確認')]/parent::tr//input",
                    "//div[contains(text(), '確認')]/parent::td/parent::tr//input",
                    "//input[@name='確認']",
                };
                var subtitleXpaths = new List<string>()
                {
                    "//input[@name='your-subject']",
                    "//label[contains(text(), '件名')]/parent::div//input",
                };
                var textBoxCompanyElements = GetElements(companyXpaths);
                var textBoxNameElements = GetElements(nameXpths);
                var textBoxNameKanaElements = GetElements(nameKanaXpaths);
                var textBoxNameKataElements = GetElements(nameKataXpaths);
                var textBoxPostElements = GetElements(postXpths);
                var textBoxAddressElements = GetElements(addressXpths);
                var textBoxTelElements = GetElements(telXpath);
                var textBoxfaxElements = GetElements(faxXpath);
                var textBoxEmailElements = GetElements(emailXpaths);
                var textBoxConfirmEmailElements = GetElements(confirmEmailXpaths);
                var textBoxSubtitleElements = GetElements(subtitleXpaths);
                var textBoxContentElements = driver.FindElements(By.TagName("textarea"));

                // 値を入力
                if (textBoxCompanyElements.Count > 0)
                {
                    textBoxCompanyElements.First().Clear();
                    textBoxCompanyElements.First().SendKeys(this.OccupationExcelData.CompanyName);
                }
                if (textBoxNameElements.Count > 0)
                {
                    textBoxNameElements.First().SendKeys(this.OccupationExcelData.FullNameKanji);
                }
                if (textBoxNameKanaElements.Count > 0)
                {
                    textBoxNameKanaElements.First().SendKeys(this.OccupationExcelData.FullNameHiragana);
                }
                if (textBoxNameKataElements.Count > 0)
                {
                    textBoxNameKataElements.First().SendKeys(this.OccupationExcelData.FullNameKana);
                }
                if (textBoxPostElements.Count > 0)
                {
                    textBoxPostElements.First().SendKeys(this.OccupationExcelData.PostalCode);
                }
                if (textBoxTelElements.Count > 0)
                {
                    textBoxTelElements.First().SendKeys(this.OccupationExcelData.PhoneNumber);
                }
                if (textBoxfaxElements.Count > 0)
                {
                    textBoxfaxElements.First().SendKeys(this.OccupationExcelData.FaxNumber);
                }
                if (textBoxEmailElements.Count > 0)
                {
                    textBoxEmailElements.First().SendKeys(this.OccupationExcelData.EmailAddress);
                }
                if (textBoxConfirmEmailElements.Count > 0)
                {
                    textBoxConfirmEmailElements.First().SendKeys(this.OccupationExcelData.EmailAddress);
                }
                if (textBoxAddressElements.Count > 0)
                {
                    // 住所は自動入力されることがあるからクリアする
                    textBoxAddressElements.First().Clear();
                    textBoxAddressElements.First().SendKeys(this.OccupationExcelData.Address);
                }
                if (textBoxSubtitleElements.Count > 0)
                {
                    textBoxSubtitleElements.First().SendKeys(this.OccupationExcelData.Subject);
                }
                if (textBoxContentElements.Count > 0)
                {
                    textBoxContentElements.First().SendKeys(this.OccupationExcelData.Content);
                }

                // 編集したいのでブラウザは閉じない
                //driver.Quit();
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        private ReadOnlyCollection<IWebElement> GetElements(List<string> xpthList)
        {
            ReadOnlyCollection<IWebElement> elements = null;
            foreach (var xpath in xpthList)
            {
                elements = driver.FindElements(By.XPath(xpath));
                if (elements.Count > 0)
                {
                    break;
                }
            }
            return elements;
        }
    }
}
