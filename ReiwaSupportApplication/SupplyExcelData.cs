using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;

namespace ReiwaSupportApplication
{
    public class Excel
    {
        public string WorkBookName { get; set; }
        public string SheetName { get; set; }

        public IWorkbook Book { get; private set; }


        public Excel(string wrkBookName, string sheetName)
        {
            try
            {
                this.WorkBookName = wrkBookName;
                this.SheetName = sheetName;

                IWorkbook book;
                using (var fs = File.OpenRead(wrkBookName))
                {
                    book = WorkbookFactory.Create(fs);
                }
                var sheet = book.GetSheet(this.SheetName) ?? book.CreateSheet(this.SheetName);
                this.Book = book;
                Save(FileMode.Create);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Save(FileMode mode)
        {
            if (this.Book == null) { return; }

            try
            {
                using (var fs = new FileStream(this.WorkBookName, mode))
                {
                    this.Book.Write(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
