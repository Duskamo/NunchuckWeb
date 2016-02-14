using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NunchuckWeb.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace NunchuckWeb.Controllers
{
    public class InfoController : Controller
    {
        //********************** public functions ***********************
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
    }
}