using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apartments__MVC_Course.Models;
using Apartments__MVC_Course.Dtos;
using Apartments__MVC_Course.ViewModels;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace Apartments__MVC_Course.Controllers
{
    //[Authorize]
    public class ApartmentsController : Controller
    {
        //private List<Apartment> apartments = new List<Apartment>
        //    {
        //    new Apartment(0,"1", "Tel-Aviv", "Shinkin", 32, "Bla bla bla bla bla", 4000000, "https://q-xx.bstatic.com/images/hotel/max1024x768/209/209808843.jpg"),
        //    new Apartment(1, "1", "Heifa", "Ahuza", 23, "Description Description Description Description", 20000000, "https://cf.bstatic.com/images/hotel/max1024x768/238/238695200.jpg")
        //    };
        private ApplicationDbContext _context;

        public ApartmentsController()
        {
            _context = new ApplicationDbContext();
        }

        //        צרו חנות מחשבים – 
        //לכל מחשב יש: שם חברה; שם דגם; מעבד; זיכרון פנימי; וזיכרון חיצוני
        //צרו אתר שמציג את כל המחשבים;
        //וכאשר לוחצים על מחשב הוא מציג עמוד עם פרטי המחשב עם כפתור מחיקה שמוחק את המחשב מבסיס הנתונים.
        //צרו עמוד להוספת מחשב ועמוד לעריכת פרטי מחשב קיים.
        //        במקביל צרו API ש
        //        מאפשר את הפעולות הבאות: 
        //קבלת כל המחשבים – עם אפשרות לחיתוך על פי מאפייני המחשב
        //קבלת פרטים של מחשב מסויים
        //הוספת מחשב
        //עריכת פרטי מחשב קיים
        //מחיקת מחשב קיים

        // להוסיף שם משתמש בוויו של פרטי הדירה
        // הכפתור של העריכה מופיעה אך ורק אם הדירה שייכת למשתמש הרשום באפליקציה
        // לאקשיין של העריכה אין גישה למשתמש שהדירה איננה שייכת לו


        // GET: /Apartments
        [AllowAnonymous]
        public ActionResult Index(string city)
        {
            List<Apartment> apartments;
            if (string.IsNullOrEmpty(city))
            {
                apartments = _context.Apartments.ToList();
            }
            else
            {
                city = city.ToLower();
                apartments = _context.Apartments.Where(a => a.City.ToLower().Contains(city)).ToList();
            }

            var aparmentsDtos = apartments.Select(Mapper.Map<Apartment, ApartmentDto>).ToList();
            var viewModel = new ApartmentsViewModel()
            {
                Apartments = aparmentsDtos
            };
            return View(viewModel);
        }

        //[Authorize]
        public ActionResult Details(int id)
        {
            //if (id >= apartments.Count)
            //    return HttpNotFound();
            //var apartment = apartments[id];
            var apartment = _context.Apartments.SingleOrDefault(a => a.Id == id);
            if (apartment == null)
                return HttpNotFound();

            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var owner = _context.Users.Single(u => u.Id == apartment.OwnerId);
            var apartmentDto = Mapper.Map<Apartment, ApartmentDto>(apartment);

            var viewModel = new ApartmentDetailsViewModel()
            {
                Apartment = apartmentDto,
                OwnerName = owner.UserName,
                CanEditApartment = owner.Id == userId
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var apartment = new ApartmentDto();

            return View("ApartmentForm", apartment);
        }

        public ActionResult Edit(int id)
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var apartment = _context.Apartments.SingleOrDefault(a => a.Id == id);
            if (apartment == null || userId != apartment.OwnerId)
                return HttpNotFound();

            var apartmentDto = Mapper.Map<Apartment, ApartmentDto>(apartment);

            return View("ApartmentForm", apartmentDto);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Save(ApartmentDto apartmentDto)
        {
            if (!ModelState.IsValid)
                return View("ApartmentForm", apartmentDto);

            if (apartmentDto.Id == 0)
            {
                var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                var apartment = Mapper.Map<ApartmentDto, Apartment>(apartmentDto);
                //apartment.OwnerId = "Moshe";
                apartment.OwnerId = userId;
                _context.Apartments.Add(apartment);
            }
            else
            {
                var apartmentInDb = _context.Apartments.Single(a => a.Id == apartmentDto.Id);
                Mapper.Map(apartmentDto, apartmentInDb);
            }

            _context.SaveChanges();

            return RedirectToAction("", "Apartments");
            //return Content(apartmentDto.City);
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