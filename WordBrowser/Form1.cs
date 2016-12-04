using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using NotesFor.HtmlToOpenXml;
using System.Threading;
using System.Text;

namespace WordBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void SplashScreen()
        {
            System.Windows.Forms.Application.Run(new Form2());
        }

        string path;
        private object noEncodingDialog;
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private void fc_btn_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "word files  (*.docx)|*.docx|(*.doc)|*.doc";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                MessageBox.Show("File Choosed: " + path, "Done", 0, MessageBoxIcon.Information);
            }


            Thread t = new Thread(new ThreadStart(SplashScreen));

            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document document = application.Documents.Open(path);
            application.ActiveDocument.SaveAs(Path.Combine(desktop, "temp.html"), WdSaveFormat.wdFormatText, ref noEncodingDialog);
            ((_Application)application).Quit();
            t.Start();
            Thread.Sleep(3200);
            t.Abort();

        }

        private void rf_btn_Click(object sender, EventArgs e)
        {

            Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();

            string filename = Path.Combine(desktop, "converted.docx");
            string html = File.ReadAllText(Path.Combine(desktop, "temp.html"));

            if (File.Exists(filename)) File.Delete(filename);

            using (MemoryStream generatedDocument = new MemoryStream())
            {
                using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = package.MainDocumentPart;
                    if (mainPart == null)
                    {
                        mainPart = package.AddMainDocumentPart();
                        new DocumentFormat.OpenXml.Wordprocessing.Document(new Body()).Save(mainPart);
                    }
                    HtmlConverter converter = new HtmlConverter(mainPart);
                    Body body = mainPart.Document.Body;
                    var paragraphs = converter.Parse(html);
                    for (int i = 0; i < paragraphs.Count; i++)
                    {
                        body.Append(paragraphs[i]);
                    }
                    mainPart.Document.Save();
                }
                //string result = Encoding.UTF8.GetString(generatedDocument.ToArray());
                //File.WriteAllText(filename, result,Encoding.UTF8);

                File.WriteAllBytes(filename, generatedDocument.ToArray()); //asıl çalışan

                //byte[] utf8Bytes = Encoding.Convert(Encoding.Default,Encoding.UTF8, generatedDocument.ToArray());
                //File.WriteAllBytes(filename, utf8Bytes);


            }
            t.Abort();
            File.Delete(Path.Combine(desktop, "temp.html"));
            MessageBox.Show("File Created: " + filename, "Done", 0, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(filename);
            
        }

    }
}
