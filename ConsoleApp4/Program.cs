using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastReport;
using FastReport.Export.Pdf;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Report report = new Report();

            report.Load(@"C:\Users\Dima\Desktop\FR\frx\1.frx");

            //report.InitialPageNumber = 1;

            RichObject rich = new RichObject();

            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\Dima\Desktop\Новый документ в формате RTF (3).RTF", Encoding.Default))
                {
                    rich.Text = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception)
            {

            }

            string simpleText = rich.Text;
            var simpleTextBytes = Encoding.UTF8.GetBytes(simpleText);
            string enText = Convert.ToBase64String(simpleTextBytes);
            var enTextBytes = Convert.FromBase64String(enText);
            string deText = Encoding.UTF8.GetString(enTextBytes);
            Console.WriteLine(rich.Text);

            report.SetParameterValue("Parameter.Parameter", deText);

            report.Prepare();

            PDFExport export = new PDFExport();

            report.Export(export, "result.pdf");

            report.Dispose();
            Console.ReadKey();
        }
    }
}
