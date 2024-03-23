using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ReiwaSupportApplication
{
    internal class OccupationExcelData
    {
        private string _context = string.Empty;

        public string CompanyName { get; set; }
        public string FullNameKanji { get; set; }
        public string FullNameKana { get; set; }
        public string FullNameHiragana { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get;set; }
        public string EmailAddress { get; set; }
        public string ContactPersonAge { get; set; }
        public string ContactPersonDepartment { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string Subject { get; set; }
        public string Content {
            get
            {
                return this.Supply + " " + _context;
            }
            set
            {
                _context = value;
            }
        }
        public string Supply { get; set; }
        public EContentType ContentType { get; set; } = EContentType.Content;

        public enum EOccupation
        {
            Manufacturing,
            Construction,
            Transportation,
            Passenger,
            Etc,
            None
        }
        public enum EContentType
        {
            Content,
            ContentWithoutURL,
            ContentUnder500WithoutURL
        }
        public OccupationExcelData(EOccupation occupation, EContentType contentType) 
        {
            this.ContentType = contentType;
            ReadExcelData(occupation);
        }
        internal OccupationExcelData()
        {

        }
        private void ReadExcelData(EOccupation occupation)
        {
            //xmlファイルを指定する
            XElement xml = XElement.Load(@"./drs.xml");

            //メンバー情報のタグ内の情報を取得する
            IEnumerable<XElement> infos = from item in xml.Elements("COMMON")
                                          select item;

            //メンバー情報分ループして、コンソールに表示
            var info = infos.First();
            this.CompanyName = info.Element("CompanyName").Value;
            this.FullNameKanji = info.Element("FullNameKanji").Value;
            this.FullNameKana = info.Element("FullNameKana").Value;
            this.FullNameHiragana = info.Element("FullNameHiragana").Value;
            this.PhoneNumber = info.Element("PhoneNumber").Value;
            this.FaxNumber = info.Element("FaxNumber").Value;
            this.EmailAddress = info.Element("EmailAddress").Value;
            this.ContactPersonDepartment = info.Element("ContactPersonDepartment").Value;

            IEnumerable<XElement> occupInfos = from item in xml.Elements(occupation.ToString())
                                          select item;
            var occupInfo = occupInfos.First();
            this.ContactPersonAge = occupInfo.Element("ContactPersonAge").Value;
            this.PostalCode = occupInfo.Element("PostalCode").Value;
            this.Address = occupInfo.Element("Address").Value;
            this.Subject = occupInfo.Element("Subject").Value;
            var contentType = this.ContentType.ToString();
            this.Content = occupInfo.Element(contentType).Value.TrimStart('\n').Replace("\t", "");
        }
    }
    internal class OccupationExcelDataList
    {
        public Dictionary<string, string> Data { get; }
        public OccupationExcelDataList(OccupationExcelData excelData) 
        {
            var dictionary = new Dictionary<string, string> {};
            dictionary.Add("会社名", excelData.CompanyName);
            dictionary.Add("氏名", excelData.FullNameKanji);
            dictionary.Add("氏名(カナ)", excelData.FullNameKana);
            dictionary.Add("部署", excelData.ContactPersonDepartment);
            dictionary.Add("携帯電話", excelData.PhoneNumber);
            dictionary.Add("FAX", excelData.FaxNumber);
            dictionary.Add("Email", excelData.EmailAddress);
            dictionary.Add("年齢", excelData.ContactPersonAge);
            dictionary.Add("郵便", excelData.PostalCode);
            dictionary.Add("住所", excelData.Address);
            dictionary.Add("件名", excelData.Subject);
            Data = dictionary;
        }
    }
}
