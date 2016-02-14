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
    public class InstructorsController : Controller
    {
        //********************** data members ***********************
        private List<Instructors> instructors = new List<Instructors>();
        private MySqlConnection dbConnection = new MySqlConnection();
        private MySqlCommand cmd;

        //********************** public functions ***********************
        // GET: Index
        public ActionResult Index()
        {
            db_connect();

            string stm = "SELECT * FROM instructors;";
            cmd = new MySqlCommand(stm, dbConnection);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                instructors.Add(new Instructors()
                {
                    Id = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Email = rdr.GetString(2),
                    Address = rdr.GetString(3),
                    Level = rdr.GetString(4),
                });
            }

            ViewBag.instructors = instructors;

            return View();
        }

        // GET: Contact
        public ActionResult Instructor(int id)
        {
            db_connect();

            string stm = "SELECT * FROM instructors WHERE Id=" + id + ";";
            cmd = new MySqlCommand(stm, dbConnection);
            Instructors instructor = new Instructors();

            try
            {
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    instructor.Id = rdr.GetInt32(0);
                    instructor.Name = rdr.GetString(1);
                    instructor.Email = rdr.GetString(2);
                    instructor.Address = rdr.GetString(3);
                    instructor.Level = rdr.GetString(4);
                    instructor.Facebook = rdr.GetString(5);
                }

                ViewBag.instructor = instructor;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

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