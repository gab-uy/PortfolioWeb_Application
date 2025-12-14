using PortfolioWebApplication.Models;
using PortfolioWebApplication.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioWebApplication.Controllers
{
    public class PortfolioWebApplicationController : Controller
    {
        // GET: PortfolioWebApplication
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Resume()
        {
            return View();
        }

        public ActionResult SecondPage()
        {
            return View();
        }

        public string ConcatenateFunc() {
            return "Gabriel";
        }

        public string ParameterConcatenate(string name) { 
                return name + " " + name;
            }

        public string CollectiveParameter(UserInformation userInfo)
        {
            return userInfo.name;
        }

        public JsonResult JsonFunction(UserInformation userInfo)
        {
            try
            {
                userInfo.name = $"The Name is (userInfo. name)";
                return Json(userInfo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"There is an error while processing ISON. Function");
            }
        }

        //database connection
        [HttpPost]
        public JsonResult Upsert(UserInformation userInfo)
            {
            try
                {
                     return Json(new { success = true, message = "Saved successfully" });
                using (var db = new ITDContext())
                    {
                        var newData = new tbl_messagesModel()
                        {
                            name = userInfo.name,
                            email = userInfo.email,
                            phone = userInfo.phone,
                            subject = userInfo.subject,
                            message = userInfo.message,
                            createdAt = DateTime.Now,
                            updateAt = DateTime.Now,
                            isArchived = 0
                        };
                        db.tbl_messages.Add(newData);
                        db.SaveChanges();
                    }

                    return Json(new { success = true, message = "Saved successfully" });
                }
                catch (Exception ex)
                {
                    Response.StatusCode = 500;
                    return Json(new { success = false, error = ex.Message });
                }
            }

        //editing data
        public void UpdateData()
        {
            try {
                using(var db = new ITDContext())
                {
                    var updateData = db.tbl_messages.Where(x => x.messageId.Equals(14)).FirstOrDefault();
                    updateData.name = "Updated";
                    updateData.phone = "12345678";
                    updateData.updateAt = DateTime.Now;
                    db.SaveChanges();

                }


            }
            catch (Exception ex) {
                throw new ArgumentException($"There is an error while processing ISON. Function");
            }
        }

        /*/archiving data
        public JsonResult GetRegistration()
        {
            try
            {
                using(var db = new ITDContext())
                {
                    var getData = db.tbl_messages.Where(x => x.isArchived == 0).ToList();
                    return Json(getData, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception ex)
            {
                throw new ArgumentException($"There is an error while upserting in the database");
            }
        }*/


        [HttpGet]
        public ActionResult TestRawConnection()
        {
            try
            {
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(
                    "Server=127.0.0.1;Port=3306;Database=portfoliowebapp_db;Uid=root;Pwd=;SslMode=none;"))
                {
                    conn.Open();
                }
                return Content("Connection OK");
            }
            catch (Exception ex)
            {
                return Content($"Connection failed: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult TestFreshEFConnection()
        {
            try
            {
                using (var db = new ITDContext())
                {
                    int count = db.tbl_messages.Count();
                    return Json(new { success = true, message = "EF Connection OK", count }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //temporary
        [HttpGet]
        public JsonResult TestDbConnection()
        {
            try
            {
                using (var db = new ITDContext())
                {
                    int count = db.tbl_messages.Count();
                    return Json(new { success = true, message = "Connection successful!", count }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}