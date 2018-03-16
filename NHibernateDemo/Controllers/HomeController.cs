using Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Remoting;
using System.Web.Caching;
using Data.IBLL;

namespace NHibernateDemo.Controllers
{
    public class HomeController : Controller
    {
        private IStudent_BL _istudent_BL;
        public HomeController(IStudent_BL student_BL)
        {
            _istudent_BL = student_BL;
        }
        public ActionResult Index()
        {
            Cache cache = new Cache();
            
            var data = cache.Get("student2");
            List<Student> list=new List<Student>();
            if (data == null)
            {
                //data = _istudent_BL.GetList(p => p.Id < 300);
                //GetData getData = new GetData();
                list = _istudent_BL.GetList(p => p.Id < 300).ToList();
                cache.Insert("student2", list,null,DateTime.MaxValue,TimeSpan.FromHours(1));
            }
            else
            {
                list=data as List<Student>;
            }
            ViewBag.Data = list;
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
    }
}