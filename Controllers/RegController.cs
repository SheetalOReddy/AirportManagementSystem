using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using AirportManagementSystem.Models;
using System.Data.Entity;

namespace AirportManagementSystem.Controllers
{
    public class RegController : Controller
    {
        NewRegEntities db = new NewRegEntities();
        // GET: Reg
        public ActionResult Pilot_Details()
        {
            return View(db.Pilots.ToList());
        }
        public ActionResult Flight_Details()
        {
            return View(db.FlightBooks.ToList());
        }

        public ActionResult Flight()
        {
            return View();
        }

        // POST: Reg/Create
        [HttpPost]
        public ActionResult Flight(FlightBook p)
        {
            try
            {
                // TODO: Add insert logic here
                db.FlightBooks.Add(p);
                db.SaveChanges();
                return RedirectToAction("Flight_Details");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AdminRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminRegistration(Admin a)
        {
            db.Admins.Add(a);
            db.SaveChanges();
            return RedirectToAction("AdminLogin", "Reg");
        }


        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin ad)
        {
            var log = db.Admins.Where(a => a.AdminID.Equals(ad.AdminID) && a.Password.Equals(ad.Password)).FirstOrDefault();
            if (log != null)
            {
                return RedirectToAction("Pilot_Details", "Reg");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Reg");
            }
        }


        public ActionResult AdminButton()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminButton(string submit)
        {
            switch (submit)
            {
                case "Register":
                    return (Register());
                case "Login":
                    return (Logina());
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register()
        {
            return RedirectToAction("AdminRegistration");
        }

        [HttpPost]
        public ActionResult Logina()
        {
            return RedirectToAction("AdminLogin");
        }


        public ActionResult Homepage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Homepage(string submit)
        {
            switch (submit)
            {
                case "Admin":
                    return (Admin());
                case "Pilot":
                    return (Pilot());
                case "Manager":
                    return (Manager());
            }
            return View();
        }
        [HttpPost]
        public ActionResult Admin()
        {
            return RedirectToAction("AdminButton");
        }

        [HttpPost]
        public ActionResult Pilot()
        {
            return RedirectToAction("PilotButton");
        }
        [HttpPost]
        public ActionResult Manager()
        {
            return RedirectToAction("ManagerButton");
        }




        public ActionResult PilotRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PilotRegistration(Pilot p)
        {
            db.Pilots.Add(p);
            db.SaveChanges();
            return RedirectToAction("PilotLogin", "Reg");
        }

        public ActionResult PilotLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PilotLogin(Pilot pi)
        {
            var log = db.Pilots.Where(a => a.PilotID.Equals(pi.PilotID) && a.Password.Equals(pi.Password)).FirstOrDefault();
            if (log != null)
            {
                return RedirectToAction("Plane", "Reg");
            }
            else
            {
                return RedirectToAction("PilotLogin", "Reg");
            }
        }

        public ActionResult PilotButton()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PilotButton(string submit)
        {
            switch (submit)
            {
                case "Register":
                    return (Pregister());
                case "Login":
                    return (Loginp());
            }
            return View();
        }
        [HttpPost]
        public ActionResult Pregister()
        {
            return RedirectToAction("PilotRegistration");
        }

        [HttpPost]
        public ActionResult Loginp()
        {
            return RedirectToAction("PilotLogin");
        }


        public ActionResult ManagerRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ManagerRegistration(Manager m)
        {
            db.Managers.Add(m);
            db.SaveChanges();
            return RedirectToAction("ManagerLogin", "Reg");
        }


        public ActionResult ManagerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ManagerLogin(Manager ma)
        {
            var log = db.Managers.Where(a => a.ManagerID.Equals(ma.ManagerID) && a.Password.Equals(ma.Password)).FirstOrDefault();
            if (log != null)
            {
                return RedirectToAction("Flight_Details", "Reg");
            }
            else
            {
                return RedirectToAction("ManagerLogin", "Reg");
            }
        }

        public ActionResult ManagerButton()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ManagerButton(string submit)
        {
            switch (submit)
            {
                case "Register":
                    return (Mregister());
                case "Login":
                    return (Loginm());
            }
            return View();
        }
        [HttpPost]
        public ActionResult Mregister()
        {
            return RedirectToAction("ManagerRegistration");
        }

        [HttpPost]
        public ActionResult Loginm()
        {
            return RedirectToAction("ManagerLogin");
        }

        public ActionResult Thank_you()
        {
            return View();
        }


        public ActionResult Plane()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Plane(FlightBook b)
        {
            db.FlightBooks.Add(b);
            db.SaveChanges();
            return View();
        }

        public ActionResult Logout()
        {
            {
                Session.Clear();
                return RedirectToAction("Homepage", "Reg");
            }
        }

        // GET: Reg/Create
        public ActionResult PilotList()
        {
            return View();
        }

        // POST: Reg/Create
        [HttpPost]
        public ActionResult PilotList(Pilot p)
        {
            try
            {
                // TODO: Add insert logic here
                db.Pilots.Add(p);
                db.SaveChanges();
                return RedirectToAction("Pilot_Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reg/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.FlightBooks.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FlightBook e)
        {
            try
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Flight_Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.FlightBooks.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FlightBook f)
        {
            try
            {
                // TODO: Add delete logic here
                f= db.FlightBooks.Where(x => x.Id == id).FirstOrDefault();
                db.FlightBooks.Remove(f);
                db.SaveChanges();
                return RedirectToAction("Flight_Details");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details1(int id)
        {
            return View(db.FlightBooks.Where(x => x.Id == id).FirstOrDefault());
        }

        public ActionResult PilotDelete(int id)
        {
            return View(db.Pilots.Where(x => x.PilotID == id).FirstOrDefault());
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult PilotDelete(int id, Pilot p)
        {
            try
            {
                // TODO: Add delete logic here
                p = db.Pilots.Where(x => x.PilotID == id).FirstOrDefault();
                db.Pilots.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Pilot_Details");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult PilotDetails(int id)
        {
            return View(db.Pilots.Where(x => x.PilotID== id).FirstOrDefault());
        }
    }
}

