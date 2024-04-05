using EnumsNET;
using NPOI.SS.Formula.PTG;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V120.Page;
using OpenQA.Selenium.Support.UI;
using Org.BouncyCastle.Asn1.X509.Qualified;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReiwaSupportApplication
{
    internal class TypingBrouserControll
    {
        private ChromeDriver driver;
        private XPathData xPathData;

        internal OccupationExcelData OccupationExcelData { get; private set; }
        internal Url Url { get; private set; }
        internal Dictionary<string, ReadOnlyCollection<IWebElement>> XPathElements;
        internal Dictionary<string, string> MatchedXPath = new Dictionary<string, string>();

        internal TypingBrouserControll(OccupationExcelData occupationExcelData, Url url) 
        { 
            this.OccupationExcelData = occupationExcelData;
            this.Url= url;
        }
        internal enum ETargetControll
        {
            company = 0,
            name,
            nameKana,
            nameKata,
            address,
            post,
            tel,
            fax,
            email,
            confirmEmail,
            subtitle,
            content,
            checkBoxPrivacy,
            submitButton,
        }

        internal void TypedBrouserControll()
        {
            try
            {

                driver = new ChromeDriver();

                // サイトを表示する
                driver.Navigate().GoToUrl(Url.Value);

                ReadXPathSetting();
                SetXPathElements();
                IndexedXPathElements();

                if (XPathElements.Count <= 0 || XPathElements.Values.Count <= 0) { return; }

                foreach(var element in XPathElements)
                {
                    if(element.Value.Count <= 0) { continue; }
                    var targetElement = element.Value.First();
                    var valueClear = false;
                    var elementClick = false;
                    var sendKey = string.Empty;
                    var jsMode = true;

                    if (element.Key == ETargetControll.company.ToString())
                    {
                        valueClear = true;
                        sendKey = this.OccupationExcelData.CompanyName;
                    }
                    if (element.Key == ETargetControll.name.ToString())
                    {
                        sendKey = this.OccupationExcelData.FullNameKanji;
                    }
                    if (element.Key == ETargetControll.nameKana.ToString())
                    {
                        sendKey = this.OccupationExcelData.FullNameHiragana;
                    }
                    if (element.Key == ETargetControll.nameKata.ToString())
                    {
                        sendKey = this.OccupationExcelData.FullNameKata;
                    }
                    if (element.Key == ETargetControll.address.ToString())
                    {
                        valueClear = true;
                        sendKey = this.OccupationExcelData.Address;
                    }
                    if (element.Key == ETargetControll.post.ToString())
                    {
                        sendKey = this.OccupationExcelData.PostalCode;
                    }
                    if (element.Key == ETargetControll.tel.ToString())
                    {
                        sendKey = this.OccupationExcelData.PhoneNumber;
                    }
                    if (element.Key == ETargetControll.fax.ToString())
                    {
                        sendKey = this.OccupationExcelData.FaxNumber;
                    }
                    if (element.Key == ETargetControll.email.ToString())
                    {
                        sendKey = this.OccupationExcelData.EmailAddress;
                    }
                    if (element.Key == ETargetControll.confirmEmail.ToString())
                    {
                        sendKey = this.OccupationExcelData.EmailAddress;
                    }
                    if (element.Key == ETargetControll.subtitle.ToString())
                    {
                        sendKey = this.OccupationExcelData.Subtitle;
                    }
                    if (element.Key == ETargetControll.content.ToString())
                    {
                        sendKey = this.OccupationExcelData.Content;
                        //jsMode = true;
                    }
                    if (element.Key == ETargetControll.checkBoxPrivacy.ToString())
                    {
                        elementClick = true;
                    }
                    if (element.Key == ETargetControll.submitButton.ToString())
                    {
                        elementClick = true;
                    }

                    if (valueClear)
                    {
                        targetElement.Clear();
                    }

                    if (jsMode)
                    {
                        var xPath = MatchedXPath.Where(x=>x.Key == element.Key).First();
                        var script = $"document.evaluate(\"{xPath.Value}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.value=arguments[0]";
                        ((IJavaScriptExecutor)driver).ExecuteScript(script, sendKey);
                    }
                    else
                    {
                        targetElement.SendKeys(sendKey);
                    }

                    if (elementClick)
                    {
                        targetElement.Click();
                    }
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
                if (elements.Count <= 0)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            return elements;
        }
        private ReadOnlyCollection<IWebElement> GetElements(List<string> xPathList, out string matchedXPath)
        {
            ReadOnlyCollection<IWebElement> elements = null;
            var matchXPath = string.Empty;
            foreach (var xpath in xPathList)
            {
                elements = driver.FindElements(By.XPath(xpath));
                if (elements.Count <= 0)
                {
                    continue;
                }
                else
                {
                    matchXPath = xpath;
                    break;
                }
            }
            matchedXPath = matchXPath;
            return elements;
        }
        private void ReadXPathSetting()
        {
            var xpathInfo = new XPathInfo();
            xpathInfo.ReadXPathJson();
            xPathData = xpathInfo.GetXPathData();
        }
        private void SetXPathElements()
        {
            var xPathElements = new Dictionary<string, ReadOnlyCollection<IWebElement>>();
            var distinctJsonItemList = xPathData.XPathJsonItem.Select(x => x.ItemName).Distinct().ToList();

            foreach (var jsonItem in distinctJsonItemList)
            {
                var nameItem = xPathData.XPathJsonItem.Where(x => x.ItemName == jsonItem);
                var xpathList = nameItem.Select(x => x.XPath).ToList();
                var webElements = GetElements(xpathList, out string matchedXPath);
                var itemName = nameItem.FirstOrDefault().ItemName;
                MatchedXPath.Add(itemName, matchedXPath);
                xPathElements.Add(itemName, webElements);
            }
            XPathElements = xPathElements;
        }
        private void IndexedXPathElements()
        {
            // シーケンス番号はETargetControllに合わせる
            var indexedXPathElements = new Dictionary<string, ReadOnlyCollection<IWebElement>>();
            var indexList = new List<string>();

            var valList = Enum.GetValues(typeof(ETargetControll)).OfType<ETargetControll>();
            foreach (var val in valList)
            {
                indexList.Insert((int)val, val.ToString());
            }
            foreach(var val in indexList)
            {
                var nameItem = XPathElements.Where(x => x.Key == val);
                indexedXPathElements.Add(nameItem.First().Key, nameItem.First().Value);
            }
            // シーケンス番号順に挿入したDictionaryを作成して返す
            XPathElements = indexedXPathElements;
        }
    }
}
