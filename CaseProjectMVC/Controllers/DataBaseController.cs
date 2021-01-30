using CaseProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseProjectMVC.Controllers
{
    public class DataBaseController : Controller
    {
        // GET: DataBase
        public ActionResult First()
        {
            Login L = new Login();
            return View(L);
        }
        public ActionResult SecondCheckLogin(Login L)
        {
            //Login L = new Login();
            //L.Username = Request["Username"].ToString();
            //L.Password = Request["Password"].ToString();
            //L.Usertype = Request["Usertype"].ToString();
            string s = DBOperations.loggin(L);
            if (s == "successad")
                return View("SecondAdmin");
            else if (s == "successap")
                return View("ThirdApplicant");
            else
            {
                ViewBag.s = s;
                return View("First");
            }
        }
        public ActionResult SecondAdmin()
        {
            return View();
        }
        public ActionResult ThirdApplicant()
        {
            return View();
        }
        public ActionResult FourthCreateApp()
        {
            return View();
        }
        public ActionResult FifthSearchApp()
        {
            return View();
        }
        public ActionResult SixthNextPage()
        {
            return View();
        }
        //public JsonResult SeventhAddMember(Member M)
        //{
        //    string s=DBOperations.AddMember(M);
        //    return Json(s,JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult SeventhAddMember(Member M)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //        string s = DBOperations.AddMember(M);
        //    if(s.Contains("added"))
        //        return View("FourthCreateApp");
        //    else
        //        return View("FourthCreateApp");
            
        //    //}
        //    //else
        //    //    return Json("Enter proper details");
        //}
        public JsonResult SeventhAddMember(Member M)
        {

            
            //if(M.FirstName==null)
            //{

            //}
            //else
            //    return Json("Enter proper details");

            ViewBag.s1 = M.FirstName;
            ViewBag.s2 = M.MiddleName;
            ViewBag.s3 = M.LastName;
            ViewBag.s4 = M.Suffix;
            ViewBag.s5 = M.DOB;
            ViewBag.s6 = M.Gender;
            if (Convert.ToDateTime(M.DOB) > DateTime.Now)
            {
                return Json("Enter Valid Date");
            }
            if (M.FirstName == null || M.MiddleName == null || M.LastName == null || M.Gender == null || M.Suffix == "-"  )
            {
                
                return Json("Enter Valid Details");
            }
            string s = DBOperations.AddMember(M);
                return Json(s);

        }

        public JsonResult EighthSaveList()
        {
            string s = DBOperations.SaveMember();
            return Json(s);
        }

        public JsonResult NinthGetMember(int ApplicationId)
        {
            List<Member> L = DBOperations.fetch(ApplicationId);
            ViewBag.msg="load";
            return Json(L, JsonRequestBehavior.AllowGet);
        }
    }
}
