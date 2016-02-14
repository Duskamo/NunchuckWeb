using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NunchuckWeb.Models;

namespace NunchuckWeb.Controllers
{
    public class ExtraController : Controller
    {
        List<Instructors> instructors = new List<Instructors>();

        // GET: Extra
        public ActionResult Index()
        {
            return View();
        }

        // GET: All
        public PartialViewResult All()
        {
            db();
            List<Instructors> temp = instructors.OrderByDescending(x => x.Level).ToList();

            return PartialView("_Instructor", temp);
        }

        // GET: Top
        public PartialViewResult Top()
        {
            db();
            List<Instructors> temp = instructors.OrderByDescending(x => x.Level).Take(3).ToList();

            return PartialView("_Instructor", temp);
        }

        // GET: Bottom
        public PartialViewResult Bottom()
        {
            db();
            List<Instructors> temp = instructors.OrderBy(x => x.Level).Take(3).ToList();

            return PartialView("_Instructor", temp);
        }

        // GET: Bottom
        public PartialViewResult Ask(string name)
        {
            db();
            var patients = instructors.Where(x => x.Name.Contains(name));

            return PartialView("_Ask", patients);
        }

        //**********************************************************************
        private void db()
        {
            instructors.Add(new Instructors()
            {
                Name = "Dustin",
                Level = "10",
                Id = 0,
                Address = "",
                Email = "",
                Facebook = "",
                Phone = ""
            });

            instructors.Add(new Instructors()
            {
                Name = "Cat",
                Level = "6",
                Id = 0,
                Address = "",
                Email = "",
                Facebook = "",
                Phone = ""
            });

            instructors.Add(new Instructors()
            {
                Name = "Mom",
                Level = "7",
                Id = 0,
                Address = "",
                Email = "",
                Facebook = "",
                Phone = ""
            });

            instructors.Add(new Instructors()
            {
                Name = "Dad",
                Level = "8",
                Id = 0,
                Address = "",
                Email = "",
                Facebook = "",
                Phone = ""
            });

            instructors.Add(new Instructors()
            {
                Name = "Dean",
                Level = "9",
                Id = 0,
                Address = "",
                Email = "",
                Facebook = "",
                Phone = ""
            });
        }
    }
}