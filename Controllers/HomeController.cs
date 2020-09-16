using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TESTING.Models;

namespace TESTING.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            var inputs = new Inputs() { Field1 = 137, Field2 = "A", Field3 = "a", Field4 = -1};
            return View(inputs);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("Field1, Field2, Field3, Field4")] Inputs inputs)
        {
            if (ModelState.IsValid)
            {

                string field2 = inputs.Field2;
                for (int i = 0; i < field2.Length; i++)
                {
                    inputs.Sum += field2[i];
                }

                string field3 = inputs.Field3;
                for (int i = 0; i < field3.Length; i++)
                {
                    inputs.Sum += field3[i];
                }

                int myInt = inputs.Field1;
                string field1 = myInt.ToString("");

                for (int i = 0; i < field1.Length; i++)
                {
                    inputs.Sum += field1[i];
                }

                int myint2 = inputs.Field4;
                string field4 = myint2.ToString("");

                for (int i = 0; i < field4.Length; i++)
                {
                    inputs.Sum += field4[i];
                }
                inputs.SumTotal = Math.Round(inputs.Sum / 121);
                inputs.SumPvn = inputs.SumTotal * 21 / 100;
                inputs.Test = string.Format("{0:#,#.00}", inputs.SumTotal);
                inputs.TestPvn = string.Format("{0:0.00}", inputs.SumPvn);
                


                return View(inputs);
            }

            return View(inputs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
