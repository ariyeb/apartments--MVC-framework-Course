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
        private List<Apartment> apartments = new List<Apartment>
            {
            new Apartment(0,"1", "Tel-Aviv", "Shinkin", 32, "Bla bla bla bla bla", 4000000, "https://q-xx.bstatic.com/images/hotel/max1024x768/209/209808843.jpg"),
            new Apartment(1, "1", "Heifa", "Ahuza", 23, "Description Description Description Description", 20000000, "https://cf.bstatic.com/images/hotel/max1024x768/238/238695200.jpg")
            };


        // GET: /Apartments
        // האקשיין הזה אמור להציג דירות למכירה
        // כל דירה מוגדרת על איידי, איידי של הבעלים, עיר, רחוב, מספר בית, תיאור, מחיר, כתובת תמונה
        // הוויו מציג לכל דירה כרטיס עם התמונה ושם העיר
        // אם אין דירות יש הודעה בוויו שאין דירות
        // בלחיצה על הכרטיס עוברים לוויו הספציפי של אותה הדירה
        public ActionResult Index()
        {
            var viewModel = new ApartmentsViewModel()
            {
                Apartments = apartments
            };
            return View(viewModel);
        }

        // בוויו הזה אמורים להיות מוצגים גל הפרטים של אותה דירה מסויימת 
        public ActionResult Details(int id)
        {
            if (id >= apartments.Count)
                return HttpNotFound();


            var apartment = apartments[id];

            return View(apartment);
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