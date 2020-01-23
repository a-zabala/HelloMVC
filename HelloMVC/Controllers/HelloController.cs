using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        static int counter;
        
        // GET: /Controllers
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method= 'post'>" +
                "<input type = 'text' name = 'name' />" +
                "<select name = 'lang' />" +
                "<option value = 'english'>English</option>" +
                "<option value = 'spanish'>Spanish</option>" +
                "<option value = 'japanese'>Japanese</option>" +
                "<option value = 'german'>German</option>" +
                "<option value = 'tagalog'>Tagalog</option>" +
                "</select>" +
                "<input type = 'submit' value = 'Greet Me!' />" +
                "</ form >";
            ;
            return Content(html, "text/html");
        }
        //CreateMessage(name, lang);

        // /Hello
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string lang, string name)
        {
            
            return Content(CreateMessage(name, lang), "text/html");
        }


        public static string CreateMessage(string name, string language)
        {
            
            string greet = "Hello";
            if (language == "spanish") { greet = "Hola"; }
            if (language == "german") { greet = "Hallo"; }
            if (language == "japanese") { greet = "Konnichiwa"; }
            if (language == "tagalog") { greet = "Kumusta"; }
            counter++;
            string message = string.Format("<h1 style = color:blue;>{0} {1}!You have been greeted {2} times</h1>", greet, name, counter);
            
            return message;
        }

        // /Hello/Goodbye
        // alter the path to be /Hello/Aloha

        //Handle Requests to /Hello/NAME  (URL segment)
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)

        {
            return Content(string.Format("<h1>Hello {0}</hi>", name), "text/html");

        }
        public IActionResult Goodbye()
        {
            return Content("Goodbye");
        }
    }

}