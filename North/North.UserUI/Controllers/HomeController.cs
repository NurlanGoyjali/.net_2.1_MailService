using Microsoft.AspNetCore.Mvc;
using North.ClassLib;
using North.ClassLib.ConvertPages;
using North.UserUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace North.UserUI.Controllers
{
    public class HomeController : Controller
    {


        string title = "Sayın ";
        public IActionResult Index()
        {

           
            ConvertC convert = new ConvertC();
            convert.GeneratePDF(convert.RenderXMLData(
                "\\Users\\90545\\OneDrive\\Masaüstü\\fatura xslt\\irsaliye.xslt",
                "\\Users\\90545\\OneDrive\\Masaüstü\\fatura xml\\gelenirs.xml"

                ));

            string UserNameEX = title + "Nurlan";
            string UserMailEX = "nurlan.goyjali@gmail.com";
            string mailSubjectEX = "Konu yok";// konu
            string mailContainerEX = "Daha bi yazı üretemedik laf oldun fdiye bu burda asfa";


			 ConvertC convert = new ConvertC();
            convert.GeneratePDF(convert.RenderXMLData(
                "\\Users\\90545\\OneDrive\\Masaüstü\\fatura xslt\\irsaliye.xslt",
                "\\Users\\90545\\OneDrive\\Masaüstü\\fatura xml\\gelenirs.xml"

                ));

            MailC sendMail = new MailC();
            sendMail.sendMail("result.pdf", UserNameEX, UserMailEX, mailSubjectEX, mailContainerEX);



            return View();
        }

        public IActionResult About()
        {
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
