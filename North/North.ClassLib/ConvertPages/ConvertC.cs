using HtmlAgilityPack;
using PhantomJs.NetCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace North.ClassLib.ConvertPages
{
    public class ConvertC
    {
         /// <summary>
         /// görüntüde bozukluk var ise table width leri 700 e çekin.
         /// </summary>
         /// <param name="rawPath"></param>
         /// <returns></returns>
         
        public void GeneratePDF(string rawHtml ) // takes html for convert to pdf
        {

            var htmlToConvert = rawHtml;     
            var generator = new PdfGenerator();


            var currentDirectory = Directory.GetCurrentDirectory();
            var newCurrentDirectory = currentDirectory;
            if (System.IO.File.Exists("\\Users\\90545\\source\\repos\\North\\North.UserUI\\result.pdf"))
            {
                System.IO.File.Delete("\\Users\\90545\\source\\repos\\North\\North.UserUI\\result.pdf");
            }
            
            var pathOfGeneratedPdf = generator.GeneratePdf(htmlToConvert, currentDirectory)   ; //it will convert to pdf and and creat with random name in project path 

                System.IO.File.Move(pathOfGeneratedPdf  , "\\Users\\90545\\source\\repos\\North\\North.UserUI\\result.pdf");
           
        }

       
         public string RenderXMLData(string Xslt_Path, string Xml_Path)
        {
            string pathS = Xslt_Path;
                //"\\Users\\90545\\source\\repos\\MailDeneme\\MailCL\\DocS\\main.xslt";
            var xmlPath = Xml_Path;
                //"\\Users\\90545\\source\\repos\\MailDeneme\\MailCL\\DocS\\try.xml";
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.ValidationType = ValidationType.Schema;

            XmlReader reader = XmlReader.Create(xmlPath, xmlReaderSettings);
            
            XslCompiledTransform objXSLTransform = new XslCompiledTransform();
            objXSLTransform.Load(pathS);
            StringBuilder htmlOutput = new StringBuilder();
            TextWriter htmlWriter = new StringWriter(htmlOutput);

            objXSLTransform.Transform(reader, null, htmlWriter);

            return htmlOutput.ToString();

        }


    }
}
