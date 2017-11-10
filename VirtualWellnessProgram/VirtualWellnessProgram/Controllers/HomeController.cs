using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LumenWorks.Framework.IO.Csv;
using VirtualWellnessProgram.Audit;
using VirtualWellnessProgram.Models;
using VirtualWellnessProgram.Models.ViewModels;

namespace VirtualWellnessProgram.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Upload()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    if (upload.FileName.EndsWith(".csv"))
                    {
                        Stream stream = upload.InputStream;
                        DataTable csvTable = new DataTable();
                        using (CsvReader csvReader = new CsvReader(new StreamReader(stream), true))
                        {
                            csvTable.Load(csvReader);
                        }
                        
                        TempData["myObj"] = csvTable;

                        return RedirectToAction("VarifyDatatable");
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }

        public ActionResult VarifyDatatable()
        {
            HomeVerifyDatabaseViewModel viewModel = new HomeVerifyDatabaseViewModel();
            viewModel.Database = TempData["myObj"] as DataTable;
            TempData.Keep("myObj");
            viewModel.Verified = true;
            
            return View(viewModel);
        }

        [Audit]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VarifyDatatable(HomeVerifyDatabaseViewModel viewModel)
        {
            if (viewModel.Verified == true)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                DataTable DataTable = TempData["myObj"] as DataTable;
                List<string>Result = new List<string>();

                foreach (DataRow row in DataTable.Rows)
                {
                    foreach (DataColumn col in DataTable.Columns)
                    {
                       var encryptedWords = Encryption.Encrytion.Encrypt(row[col.ColumnName].ToString());
                        Result.Add(encryptedWords);
                    }
                }
                for (int i = 0; i < Result.Count; i++)
                {
                    HealthInfo healthInfo = new HealthInfo();
                    healthInfo.UniqueCode = Encryption.Encrytion.Decrypt(Result[i]);
                    i++;
                    healthInfo.Age = Result[i];
                    i++;
                    healthInfo.Gender = Result[i];
                    i++;
                    healthInfo.Height = Result[i];
                    i++;
                    healthInfo.Weight = Result[i];
                    i++;
                    healthInfo.Smoker = Result[i];
                    i++;
                    healthInfo.BodyFatAmt = Result[i];
                    i++;
                    healthInfo.Hdl = Result[i];
                    i++;
                    healthInfo.Ldl = Result[i];
                    i++;
                    healthInfo.CholesterolTotal = Result[i];
                    i++;
                    healthInfo.Triglycerides = Result[i];

                    db.HealthInfoes.Add(healthInfo);
                    db.SaveChanges();
                }
    
                return RedirectToAction("UploadComplete");

            }
            else if (viewModel.Verified == false)
            {
                return RedirectToAction("Upload");
            }
            return View();
        }

        public ActionResult UploadComplete()
        {
            return View();
        }

        public ActionResult ViewAuditRecords()
        {
            var audits = new AuditingContext().AuditRecords;
            return View(audits);
        }

        public ActionResult AddFoodExercise()
        {
            return View();
        }

        public ActionResult Alert()
        {
            return View();
        }
    }
}