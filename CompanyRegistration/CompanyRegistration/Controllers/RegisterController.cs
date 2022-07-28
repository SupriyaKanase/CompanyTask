using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using CompanyRegistration.Models;

namespace CompanyRegistration.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public string EmailId;
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(ClS obj)
        {
            BAL objuser = new BAL();
            objuser.AddRegister(obj.FirstName, obj.LastName, obj.DateOfBirth, obj.EmailId, obj.Password, obj.ConfirmPassword);
            return View();
        }
       


        public ActionResult Login(ClS obj)
        {
            BAL objuser = new BAL();
            SqlDataReader dr;
            dr = objuser.Login(obj.EmailId, obj.Password);
            if (dr.Read())

            {


                Session["EmailId"] = obj.EmailId.ToString();

                return RedirectToAction("empty");


            }


            else
         
            {

               
                ViewData["Message"] = "XYZ";



            }

            return View();
        }
        public ActionResult empty()
        {
            
            return View();
        }
        
        [HttpGet]
        public ActionResult list()
        {
            BAL objuser = new BAL();
            DataSet ds = new DataSet();
            ds = objuser.ShowData();
            ClS ObjDetails = new ClS();
            List<ClS> lstclsDt1 = new List<ClS>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstclsDt1.Add(new ClS()
                {
                    RegisterId=Convert.ToInt32(dr["RegisterId"]),
                    FirstName= dr["FirstName"].ToString()
                    //LastName= dr["LastName"].ToString(),
                    //DateOfBirth=dr["DateOfBirth"].ToString(),
                    //EmailId= dr["DateOfBirth"].ToString(),

                });
            }
            ObjDetails.lstcls = lstclsDt1;


            return View(ObjDetails);

        }

        public ActionResult Details(int id)
        {
            BAL objuser = new BAL();
            SqlDataReader dr;
            dr = objuser.ShowSingleEmployee(id);
            ClS emp = new ClS();
            if (dr.Read())
            {
                emp.RegisterId= Convert.ToInt32(dr["RegisterId"].ToString());
                emp.FirstName = dr["FirstName"].ToString();
                emp.LastName = dr["LastName"].ToString();
                emp.DateOfBirth = dr["DateOfBirth"].ToString();
                emp.EmailId = dr["EmailId"].ToString();
            }


            return View(emp);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BAL objBAL = new BAL();
           
            SqlDataReader dr= objBAL.ShowSingleEmployee(id);
            ClS objCls = new ClS();
            if (dr.Read())
            {
                objCls.RegisterId =Convert.ToInt32(dr["RegisterId"].ToString());
                objCls.FirstName = dr["FirstName"].ToString();
                objCls.LastName = dr["LastName"].ToString();
                objCls.DateOfBirth = dr["DateOfBirth"].ToString();
            }


            return View(objCls);
        }

        [HttpPost]

        public ActionResult Edit(ClS objcls)
        {
            BAL objBAL = new BAL();
            objBAL.EditEmployee(objcls.RegisterId, objcls.FirstName, objcls.LastName, objcls.DateOfBirth);
            return RedirectToAction("list");
        }

        public ActionResult Delete(int id)
        {
            BAL objBAL = new BAL();

          objBAL.DeleteEmployee(id);
            
            return RedirectToAction("list");
        }

    }
    }

       