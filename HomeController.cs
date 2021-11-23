using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        schoolEntities obj = new schoolEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Registration(st_data st)
        {
            obj.st_data.Add(st);
            obj.SaveChanges();
            return View();
        }
        public ActionResult Show()
        {
            var data = obj.st_data.ToList();
            return View(data);
        }
        public ActionResult Delete(int id = 0)
        {
            var data = obj.st_data.Find(id);
            obj.st_data.Remove(data);
            obj.SaveChanges();
            return RedirectToAction("Show");
        }
        public ActionResult Details(int id = 0)
        {
            st_data st = new st_data();
            if (id > 0)
            {
                var data = (from a in obj.st_data where a.st_id == id select a).ToList();
                st.st_id = data[0].st_id;
                st.st_name = data[0].st_name;
                st.st_Fname = data[0].st_Fname;
                st.contact = data[0].contact;
                st.st_class = data[0].st_class;
                st.st_address = data[0].st_address;
                st.E_state = data[0].E_state;

            }
            return View(st);
        }
    }
}