using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apartments__MVC_Course.Models;
using Apartments__MVC_Course.ViewModels;

namespace Apartments__MVC_Course.Controllers
{
    public class ApartmentsController : Controller
    {
        // GET: /Apartments
        // האקשיין הזה אמור להציג דירות למכירה
        // כל דירה מוגדרת על איידי, איידי של הבעלים, עיר, רחוב, מספר בית, תיאור, מחיר, כתובת תמונה
        // הוויו מציג לכל דירה כרטיס עם התמונה ושם העיר
        // בלחיצה על הכרטיס עוברים לוויו הספציפי של אותה הדירה
        public ActionResult Index()
        {
            return View();
        }

        // בוויו הזה אמורים להיות מוצגים גל הפרטים של אותה דירה מסויימת 
        public ActionResult Details()
        {
            return View();
        }


        // /aprtments/stam/:id?sortBy=name
        [Route("apartments/theroute/best/{id:range(1,6)}/{sortBy:regex(^name|age$)}")]
        public ActionResult Stam(int? id, string sortBy)
        {
            //return Content("Stam action");
            //return HttpNotFound();
            //return RedirectToAction("Index", "Home");

            if (string.IsNullOrEmpty(sortBy))
                sortBy = "None";

            return Content("Stam action, Id: " + id + ", sortBy: " + sortBy);
        }

        public ActionResult RealStam()
        {
            //var model = new Stam(1, "Moshe", true);
            //return View(model);

            var stams = new List<Stam>()
            {
                //new Stam(1, "Moshe", true),
                //new Stam(2, "Moshit", false)
            };

            var viewModel = new RealStamViewModel()
            {
                Stams = stams
            };

            return View(viewModel);
        }
    }
}