using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NunchuckWeb.Models;
using MySql.Data.MySqlClient;

namespace NunchuckWeb.Controllers
{
    public class ContactController : Controller
    {
        //********************** data members ***********************
        private Instructors instructor = new Instructors();
        private MySqlConnection dbConnection = new MySqlConnection();
        private MySqlCommand cmd;

        //********************** public functions ***********************
        // GET: Contact
        public ActionResult Index()
        {
            db_connect();

            string stm = "SELECT Name, Email, Facebook, Phone FROM instructors WHERE Name = 'Dustin Landry';";
            cmd = new MySqlCommand(stm, dbConnection);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                instructor.Name = rdr.GetString(0);
                instructor.Email = rdr.GetString(1);
                instructor.Facebook = rdr.GetString(2);
                instructor.Phone = rdr.GetString(3);
            }

            ViewBag.instructor = instructor;

            return View();
        }

        //********************** helper functions ***********************
        private void db_connect()
        {
            try
            {
                dbConnection.ConnectionString = "server=localhost; userId=root; password=lexmark1150; database=nunchuck;";
                dbConnection.Open();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}