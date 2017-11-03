using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LumenWorks.Framework.IO.Csv;
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
            viewModel.Verified = true;
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VarifyDatatable(HomeVerifyDatabaseViewModel viewModel)
        {
            if (viewModel.Verified == true)
            {
                foreach (DataRow row in viewModel.Database.Rows)
                {
                    Encryption.Encrytion.Encrypt(row[0].ToString());
                }
                
            }
            else if (viewModel.Verified == false)
            {
                
            }
            return View();
        }
    }
}