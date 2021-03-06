﻿using Highsoft.Web.Mvc.Charts;
using KrishnaFinance.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace KrishnaFinance.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult getfine(int SettingID = 1)
        //{
        //    try
        //    {


        //        FinanceDbContext _db = new FinanceDbContext();

        //        var result = _db.MasterSetting.SqlQuery(@"exec UspGetMasterSetting @SettingID",
        //        new SqlParameter("@SettingID", SettingID)
        //         ).ToList<MasterSetting>();
        //        var data = result.FirstOrDefault();
        //        return Request.IsAjaxRequest()
        //                ? (ActionResult)PartialView("MasterSetting", data)
        //                : View("MasterSetting", data);
        //    }
        //    catch (Exception ex)
        //    {
        //        var mgs = ex.Message;
        //        return View();

        //    }
        //    finally
        //    {

        //    }
        //}
        [HttpPost]
        public ActionResult InsertMasterSetting(MasterSetting MS)
        {
            try
            {
                FinanceDbContext _db = new FinanceDbContext();
                var result = _db.Database.ExecuteSqlCommand(@"exec UspUpdateMasterSetting 
@SettingID,
@Duration,
@EMIDuePenalty,
@EMIDueAmount,
@ProcessingFees,
@GSTOnDisbursement,
@CGST,
@SGST,
@ServiceCharges,
@PreClosingCharges,
@InterestAmount,
@InterestRate",
new SqlParameter("@SettingID", MS.SettingID),
new SqlParameter("@Duration", MS.Duration),
new SqlParameter("@EMIDuePenalty", MS.EMIDuePenalty),
new SqlParameter("@EMIDueAmount", MS.EMIDueAmount),
new SqlParameter("@ProcessingFees", MS.ProcessingFees),
new SqlParameter("@GSTOnDisbursement", MS.GSTOnDisbursement),
new SqlParameter("@CGST", MS.CGST),
new SqlParameter("@SGST", MS.SGST),
new SqlParameter("@ServiceCharges", MS.ServiceCharges),
new SqlParameter("@PreClosingCharges", MS.PreClosingCharges),
new SqlParameter("@InterestAmount", MS.InterestAmount),
new SqlParameter("@InterestRate", MS.InterestRate));

                return Json("   Setting Changes Sucessfullly");

            }
            catch (Exception ex)
            {
                string message = string.Format("<b>Message:</b> {0}<br /><br />", ex.Message);
                return Json(message);
            }
        }
        public ActionResult MasterSetting(int SettingID = 1)
        {
            try
            {


                FinanceDbContext _db = new FinanceDbContext();

                var result = _db.MasterSetting.SqlQuery(@"exec UspGetMasterSetting @SettingID",
                new SqlParameter("@SettingID", SettingID)
                 ).ToList<MasterSetting>();
                var data = result.FirstOrDefault();
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("MasterSetting", data)
                        : View("MasterSetting", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
        }
        public ActionResult PrintNOC(int ApplicantID = 1)
        {
            try
            {


                FinanceDbContext _db = new FinanceDbContext();

                var result = _db.PrintNOC.SqlQuery(@"exec UspGetPrintNOC @ApplicantID",
                new SqlParameter("@ApplicantID", ApplicantID)
                 ).ToList<PrintNOC>();
                var data = result.FirstOrDefault();
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("PrintNOC", data)
                        : View("PrintNOC", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
        }
        public ActionResult Settlement(int ApplicantID = 0)
        {
            try
            {              

                FinanceDbContext _db = new FinanceDbContext();
              
                var result = _db.FetchSettlement.SqlQuery(@"exec GetSettlementDetails @ApplicantID",
                new SqlParameter("@ApplicantID", ApplicantID)
                 ).ToList<FetchSettlement>();
                var data = result.FirstOrDefault();
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("Settlement", data)
                        : View("Settlement", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
        }
       
        [HttpPost]
        public ActionResult InsertSettlement(InsertSettlement IS)
        {
            try
            {
                FinanceDbContext _db = new FinanceDbContext();
                var result = _db.Database.ExecuteSqlCommand(@"exec UspInsertSettlement 
@SettlementID,
@ApplicantID,
@ServiceCharges,
@TotalAmount,
@PaymentMethod,
@ChequeNumber,
@BankTransactionID",
new SqlParameter("@SettlementID", IS.SettlementID),
new SqlParameter("@ApplicantID", IS.ApplicantID),
new SqlParameter("@ServiceCharges", IS.ServiceCharges),
new SqlParameter("@TotalAmount", IS.TotalAmount),
new SqlParameter("@PaymentMethod", IS.PaymentMethod),
new SqlParameter("@ChequeNumber", IS.ChequeNumber),
new SqlParameter("@BankTransactionID", IS.BankTransactionID));

                return Json("  Settlement Sucessfullly");

            }
            catch (Exception ex)
            {
                string message = string.Format("<b>Message:</b> {0}<br /><br />", ex.Message);
                return Json(message);
            }
        }
        public ActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Settings(int Duration=0)
        {
            try
            {
                FinanceDbContext _db = new FinanceDbContext();
                var result = _db.Database.ExecuteSqlCommand(@"exec UspSettings @value",
                         new SqlParameter("@value", Duration));
                return Json("Settings Changes Sucessfullly");
            }
            catch (Exception ex)
            {
                string message = string.Format("<b>Message:</b> {0}<br /><br />", ex.Message);
                return Json(message);
            }
        }
      
        //EMI Update
        [HttpPost]
        public ActionResult EMIUpdate(int TransectionID, string BankTransactionID,DateTime EMIPaidDate,int status ,decimal AdditionalCharges, decimal EMIDuePenalty, int ApplicantID=1)
        {
            try
            {
                FinanceDbContext _db = new FinanceDbContext();
                var result = _db.Database.ExecuteSqlCommand(@"exec UspEMIUpdate @TransectionID,@BankTransactionID, @EMIPaidDate, @status ,@AdditionalCharges,@EMIDuePenalty,@ApplicantID",
                       new SqlParameter("@TransectionID", TransectionID),
                         new SqlParameter("@BankTransactionID", BankTransactionID),
                         new SqlParameter("@EMIPaidDate", EMIPaidDate),
                         new SqlParameter("@status", status),
                          new SqlParameter("@AdditionalCharges", AdditionalCharges),
                            new SqlParameter("@EMIDuePenalty", EMIDuePenalty),
                           new SqlParameter("@ApplicantID", ApplicantID));
                       return Json("EMI Paid Sucessfullly");

            }
            catch (Exception ex)
            {
                string message = string.Format("<b>Message:</b> {0}<br /><br />", ex.Message);
                return Json(message);
            }
        }
      
     
        public ActionResult Collectiondata(int ApplicantID = 0, int TransectionID = 0)
        {
            try
            {
                if (TransectionID == 0)
                {
                    GetTransection d = new GetTransection();
                    d.ApplicantID = 0;
                    return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("Collectiondata", d)
                        : View("Collectiondata", d);
                }

                FinanceDbContext _db = new FinanceDbContext();
                ViewData["EMIStatus"] = binddropdown("EMIStatus", 0);
                var result = _db.GetTransection.SqlQuery(@"exec GetTransection @ApplicantID,@TransectionID",
                new SqlParameter("@ApplicantID", ApplicantID),
                new SqlParameter("@TransectionID", TransectionID)
                 ).ToList<GetTransection>();
                var data = result.FirstOrDefault();
                string EMIDate = data.EMIDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                ViewBag.EMIDate = EMIDate;               
                string DisbursementDate = data.DisbursementDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                ViewBag.DisbursementDate = DisbursementDate;
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("Collectiondata", data)
                        : View("Collectiondata", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
        }

        //save Application
        [HttpPost]
        public ActionResult SaveApplication(Application AP)
        {

            try
            {
                string AadharCardSavePath =  Session["UserID"] + @"/AadharCard"+ Path.GetExtension(AP.Adharcardpath);
                 
                string PancardSavePath =  Session["UserID"] + @"/Pancard" + Path.GetExtension(AP.Pancardpath);
                if (AP.Pancardpath != null && AP.Pancardpath!="View")
                {
                    string sourcePath =@"~\UserDocument\PanCard";
                    string targetPath =  @"~\UserDocument\PanCard\" +  Session["UserID"];

                    // Use Path class to manipulate file and directory paths.
                    string sourceFile = System.IO.Path.Combine(sourcePath, AP.Pancardpath);
                    string destFile = System.IO.Path.Combine(targetPath, "Pancard" + Path.GetExtension(AP.Pancardpath));
                     
                    System.IO.Directory.CreateDirectory(Server.MapPath(targetPath)); 
                    System.IO.File.Copy(Server.MapPath(sourceFile), Server.MapPath(destFile), true);
                }
                if (AP.Adharcardpath != null && AP.Adharcardpath!="View")
                {
                    string sourcePath = @"~\UserDocument\AadharCard";
                    string targetPath = @"~\UserDocument\AadharCard\" + Session["UserID"];

                    // Use Path class to manipulate file and directory paths.
                    string sourceFile = System.IO.Path.Combine(sourcePath, AP.Adharcardpath);
                    string destFile = System.IO.Path.Combine(targetPath, "Aadharcard" + Path.GetExtension(AP.Adharcardpath));

                    System.IO.Directory.CreateDirectory(Server.MapPath(targetPath));
                    System.IO.File.Copy(Server.MapPath(sourceFile), Server.MapPath(destFile), true);
                }
                FinanceDbContext _db = new FinanceDbContext();
                var result = _db.Database.ExecuteSqlCommand(@"exec UspInsertApplication 

                    @ApplicantFullName       ,
                    @ApplicantAge            ,
                    @ApplicantOccupation     ,
                    @MobileNo                ,
                    @PanNo            ,
                    @AdharCardNo             ,
                    @ApplicantMonthlyIncome  ,
                    @LoanRequest             ,
                    @LoanReason              ,
                    @CreatedBy               ,
                    @PresentAddress          ,
                    @OfficeAddress           ,
                    @PermanentAddress        ,
                    @BankName                ,
                    @BranchName              ,
                    @ChequesFrom             ,
                    @ChequesTo               ,
                    @CoAplicantFullName      ,
                    @CoAplicantAge           ,
                    @CoAplicantOccupation    ,
                    @MonthlyIncome           ,
                    @Pancardpath            ,
                    @Adharcardpath            ,
                    @UploadBy,
                    @ApplicantID",

                    new SqlParameter("@ApplicantFullName",AP.ApplicantFullName),
                    new SqlParameter("@ApplicantAge",AP.ApplicantAge),
                    new SqlParameter("@ApplicantOccupation",AP.ApplicantOccupation),
                    new SqlParameter("@MobileNo",AP.MobileNo),
                    new SqlParameter("@PanNo",AP.PanNo),
                    new SqlParameter("@AdharCardNo",AP.AdharCardNo),
                    new SqlParameter("@ApplicantMonthlyIncome",AP.ApplicantMonthlyIncome),
                    new SqlParameter("@LoanRequest",AP.LoanRequest),
                    new SqlParameter("@LoanReason",AP.LoanReason),
                    new SqlParameter("@CreatedBy",AP.CreatedBy),
                    new SqlParameter("@PresentAddress",AP.PresentAddress),
                    new SqlParameter("@OfficeAddress",AP.OfficeAddress),
                    new SqlParameter("@PermanentAddress",AP.PermanentAddress),
                    new SqlParameter("@BankName",AP.BankName),
                    new SqlParameter("@BranchName",AP.BranchName),
                    new SqlParameter("@ChequesFrom",AP.ChequesFrom),
                    new SqlParameter("@ChequesTo",AP.ChequesTo),
                    new SqlParameter("@CoAplicantFullName",AP.CoAplicantFullName),
                    new SqlParameter("@CoAplicantAge",AP.CoAplicantAge),
                    new SqlParameter("@CoAplicantOccupation",AP.CoAplicantOccupation),
                    new SqlParameter("@MonthlyIncome",AP.CoApplicantMonthlyIncome), 
                    new SqlParameter("@Pancardpath", PancardSavePath),
                    new SqlParameter("@Adharcardpath", AadharCardSavePath),
                    new SqlParameter("@UploadBy",AP.UploadBy),
                    new SqlParameter("@ApplicantID", AP.ApplicantID));


                return Json("Application Inserted Sucessfullly");

            }
            catch (Exception ex)
            {

                string message = string.Format("<b>Message:</b> {0}<br /><br />", ex.Message);
                return Json(message);

            }

        }


        //Upload AadharCard
         [HttpPost]
        public ActionResult UploadDocumentAdhar()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {

                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;

                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                      
                        string filePath = Server.MapPath("~/UserDocument/Aadharcard/");

                        bool isExists = System.IO.Directory.Exists(filePath);
                        if (!isExists) { System.IO.Directory.CreateDirectory(filePath); }


                        string extension = Path.GetExtension(file.FileName);
                        string fileName = fname;


                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(filePath, fileName);
                        file.SaveAs(fname);

                    }

                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");

                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        //Upload PenCard
        [HttpPost]
        public ActionResult UploadDocumentPan()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {

                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;

                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        string filePath = Server.MapPath("~/UserDocument/PanCard/");

                        bool isExists = System.IO.Directory.Exists(filePath);
                        if (!isExists) { System.IO.Directory.CreateDirectory(filePath); }


                        string extension = Path.GetExtension(file.FileName);
                        string fileName = fname;


                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(filePath, fileName);
                        file.SaveAs(fname);

                    }

                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");

                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        public ActionResult AddApplication(int ApplicantID = 0,String AppStatus = "")
        {
            try
            {
                if(ApplicantID == 0)
                {
                    Application d = new Application();
                    d.ApplicantID = 0;
                    return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("AddApplication", d)
                        : View("AddApplication", d);
                }

                FinanceDbContext _db = new FinanceDbContext();

                var result = _db.Application.SqlQuery(@"exec GetApplicationByID @ApplicantID",
                new SqlParameter("@ApplicantID", ApplicantID)
                 ).ToList<Application>();
                var data = result.FirstOrDefault();
                if(AppStatus == "")
                {
                    ViewBag.status = "NA";
                }
                else
                {
                    ViewBag.status = AppStatus;
                }               
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("AddApplication", data)
                        : View("AddApplication", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
        }
        #region changes Made by Sunil
        public ActionResult ReadFile(string FileName , int userid)
        {

            return View();

            
        }
        public ActionResult LoadApplicationGrid(int? page, String Name = null)
        {
            StaticPagedList<ApplicationList> itemsAsIPagedList;
            itemsAsIPagedList = AppicationGridList(page, Name);

            return Request.IsAjaxRequest()
                    ? (ActionResult)PartialView("ApplicationGrid", itemsAsIPagedList)
                    : View("ApplicationGrid", itemsAsIPagedList);
        }

        public ActionResult ApplicationList(int? page, String Name = null)
        {
            StaticPagedList<ApplicationList> itemsAsIPagedList;
            itemsAsIPagedList = AppicationGridList(page, Name);

            return Request.IsAjaxRequest()
                    ? (ActionResult)PartialView("ApplicationList", itemsAsIPagedList)
                    : View("ApplicationList", itemsAsIPagedList);
        }
        public StaticPagedList<ApplicationList> AppicationGridList(int? page, String Name = "")
        {
            FinanceDbContext _db = new FinanceDbContext();
            var pageIndex = (page ?? 1);
            const int pageSize = 10;
            int totalCount = 10;
            int RollID = Convert.ToInt32(Session["RoleID"].ToString());
            ApplicationList clist = new ApplicationList();

            IEnumerable<ApplicationList> result = _db.ApplicationList.SqlQuery(@"exec GetApplication
                   @pPageIndex, @pPageSize,@Name,@RollID",
               new SqlParameter("@pPageIndex", pageIndex),
               new SqlParameter("@pPageSize", pageSize),
               new SqlParameter("@Name", Name == null ? (object)DBNull.Value : Name),
                 new SqlParameter("@RollID", RollID)
               ).ToList<ApplicationList>();

            totalCount = 0;
            if (result.Count() > 0)
            {
                totalCount = Convert.ToInt32(result.FirstOrDefault().TotalRows);
            }
            var itemsAsIPagedList = new StaticPagedList<ApplicationList>(result, pageIndex, pageSize, totalCount);
            return itemsAsIPagedList;

        }

        public ActionResult SendToApproval(int ApplicantID , int CreatedBy)
        {

            try
            {
                FinanceDbContext _db = new FinanceDbContext();
                var result = _db.Database.ExecuteSqlCommand(@"exec LoanApprovalRequest @ApplicantID , @CreatedBy", 
                    new SqlParameter("@ApplicantID", ApplicantID),
                     new SqlParameter("@CreatedBy", CreatedBy)); 

                return Json("Application Sent for approval Sucessfullly");

            }
            catch (Exception ex)
            {

                string message = string.Format("<b>Message:</b> {0}<br /><br />", ex.Message);
                return Json(message);

            }
            
        }
        [HttpPost]
        public ActionResult ApprovalResponse(int ApplicantID, int CreatedBy , int status, decimal Amount ,decimal InterestRate , decimal PrincipalAmount , decimal TotalAmount , string Remark , String Duration, DateTime EMIDate ,DateTime DisbursementDate,decimal ProcessingFees, decimal GSTOnDisbursement,decimal DisburesdAmount,decimal InterestAmount)
        {
            try
            {
                FinanceDbContext _db = new FinanceDbContext();
                var result = _db.Database.ExecuteSqlCommand(@"exec uspLoanApprovalResponse @ApplicantID , @CreatedBy,@status,@Amount,@InterestRate,@PrincipalAmount,@TotalAmount,@Remark,@Duration,@EMIDate,@DisbursementDate,@ProcessingFees,@GSTOnDisbursement,@DisburesdAmount,@InterestAmount",
                     new SqlParameter("@ApplicantID", ApplicantID),
                     new SqlParameter("@CreatedBy", CreatedBy), 
                     new SqlParameter("@status", status),
                     new SqlParameter("@Amount", Amount),
                     new SqlParameter("@InterestRate", InterestRate), 
                     new SqlParameter("@PrincipalAmount", PrincipalAmount),
                     new SqlParameter("@TotalAmount", TotalAmount),
                     new SqlParameter("@Remark", Remark) ,
                     new SqlParameter("@Duration", Duration),
                       new SqlParameter("@EMIDate", EMIDate),
                      new SqlParameter("@DisbursementDate", DisbursementDate),
                       new SqlParameter("@ProcessingFees", ProcessingFees),
                        new SqlParameter("@GSTOnDisbursement", GSTOnDisbursement),
                          new SqlParameter("@DisburesdAmount", DisburesdAmount),
                           new SqlParameter("@InterestAmount", InterestAmount));

                return Json("Application Approved Sucessfullly");

            }
            catch (Exception ex)
            {
                string message = string.Format("<b>Message:</b> {0}<br /><br />", ex.Message);
                return Json(message);
            }
        }
        public ActionResult ApprovalResponse(int ApplicantID )
        {
            ViewData["ApprovalStatus"] = binddropdown("ApprovalStatus", 0);
            ViewData["Duration"] = binddropdown("Duration", 0);
            FinanceDbContext _db = new FinanceDbContext();
            ApplicationApproval data = new ApplicationApproval();
            var result = _db.ApplicationApproval.SqlQuery(@"exec GetApplicationApproval @ApplicantID",
            new SqlParameter("@ApplicantID", ApplicantID)
             ).ToList<ApplicationApproval>();
            data = result.FirstOrDefault();
            string EMI = data.EMIDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            ViewBag.EMI = EMI;
            string Disbursement = data.DisbursementDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            ViewBag.Disbursement = Disbursement;
            return Request.IsAjaxRequest()
                      ? (ActionResult)PartialView("ApprovalResponse", data)
                      : View("ApprovalResponse", data);
 
        }

        public List<SelectListItem> binddropdown(string action, int val = 0)
        {
            FinanceDbContext _db = new FinanceDbContext();

            var res = _db.Database.SqlQuery<SelectListItem>("exec USP_BindDropDown @action , @val",
                   new SqlParameter("@action", action),
                    new SqlParameter("@val", val))
                   .ToList()
                   .AsEnumerable()
                   .Select(r => new SelectListItem
                   {
                       Text = r.Text.ToString(),
                       Value = r.Value.ToString(),
                       Selected = r.Value.Equals(Convert.ToString(val))
                   }).ToList();

            return res;
        }
        public ActionResult PrintApplication(int ApplicantID = 1)
        {
            try
            {


                FinanceDbContext _db = new FinanceDbContext();

                var result = _db.PrintApplication.SqlQuery(@"exec GetApplicationForPrint @ApplicantID",
                new SqlParameter("@ApplicantID", ApplicantID)
                 ).ToList<PrintApplication>();
                var data = result.FirstOrDefault();
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("PrintApplication", data)
                        : View("PrintApplication", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
        }
        #endregion
        public ActionResult PrintDemandPromissory(int ApplicantID = 1)
        {
            try
            {


                FinanceDbContext _db = new FinanceDbContext();

                var result = _db.PrintDemandPromissory.SqlQuery(@"exec GetPrintDemandPromissory @ApplicantID",
                new SqlParameter("@ApplicantID", ApplicantID)
                 ).ToList<PrintDemandPromissory>();
                var data = result.FirstOrDefault();
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("PrintDemandPromissory", data)
                        : View("PrintDemandPromissory", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
        }
       
          public ActionResult LoadCollectionGrid(int? page, String Name = null,int Paid = 0)
        {
            StaticPagedList<CollectionList> itemsAsIPagedList;
            itemsAsIPagedList = CollectionGridList(page, Name, Paid);

            return Request.IsAjaxRequest()
                    ? (ActionResult)PartialView("CollectionGrid", itemsAsIPagedList)
                    : View("CollectionGrid", itemsAsIPagedList);
        }

        public ActionResult CollectionList(int? page, String Name = null,int Paid = 0)
        {
            StaticPagedList<CollectionList> itemsAsIPagedList;
            itemsAsIPagedList = CollectionGridList(page, Name, Paid);

            return Request.IsAjaxRequest()
                    ? (ActionResult)PartialView("CollectionList", itemsAsIPagedList)
                    : View("CollectionList", itemsAsIPagedList);
        }
        public StaticPagedList<CollectionList> CollectionGridList(int? page, String Name = "" , int Paid = 0)
        {
            FinanceDbContext _db = new FinanceDbContext();
            var pageIndex = (page ?? 1);
            const int pageSize = 10;
            
            int totalCount = 10;
            CollectionList clist = new CollectionList();

            IEnumerable<CollectionList> result = _db.CollectionList.SqlQuery(@"exec GetCollectionList
                   @pPageIndex, @pPageSize,@Name,@paidStatus",
               new SqlParameter("@pPageIndex", pageIndex),
               new SqlParameter("@pPageSize", pageSize),
               new SqlParameter("@Name", Name == null ? (object)DBNull.Value : Name),
                   new SqlParameter("@paidStatus", Paid)
               ).ToList<CollectionList>();

            totalCount = 0;
            if (result.Count() > 0)
            {
                totalCount = Convert.ToInt32(result.FirstOrDefault().TotalRows);
            }
            var itemsAsIPagedList = new StaticPagedList<CollectionList>(result, pageIndex, pageSize, totalCount);
            return itemsAsIPagedList;

        }

        public ActionResult GetClientEMIReport(int? ApplicantID)        {            ApplicantEmiReport data = new ApplicantEmiReport();            try            {                                   FinanceDbContext _db = new FinanceDbContext();                    var result = _db.ApplicantEmiReport.SqlQuery(@"exec GetApplicationDetailsForEMIReport                     @ApplicantID",                       new SqlParameter("@ApplicantID", ApplicantID)                       ).ToList<ApplicantEmiReport>();                    data = result.FirstOrDefault();                    IEnumerable<EMIList> result2 = _db.EMIList.SqlQuery(@"exec GetApplicationWaiseEMIDetails                     @ApplicantID",                        new SqlParameter("@ApplicantID", ApplicantID)                                                  ).ToList<EMIList>();                    data._objEMIList = result2;                                                }            catch (Exception e) { }            return View("ClientEMIReport", data);        }

        public ActionResult DashBoardChart()

        {
            FinanceDbContext _db = new FinanceDbContext();
            List<DashboardChart> result = _db.DashboardChart.SqlQuery(@"exec DashbordChartDetails").ToList<DashboardChart>();
            List<ColumnSeriesData> data = new List<ColumnSeriesData>();
            for (int i = 0; i < result.Count; i++)
            {
                data.Add(new ColumnSeriesData { Name = result[i].MonthNames, Y = Convert.ToDouble(result[i].LoanAmount), Drilldown = "FIRST" });
            }
            List<string> Categories = new List<string>();
            for (int i = 0; i < result.Count; i++)
            {
                Categories.Add(result[i].MonthNames);
            }

            List<DashboardData> result1 = _db.DashboardData.SqlQuery(@"exec GetDashboardData").ToList<DashboardData>();

            ViewData["Categories1"] = Categories;
            ViewData["data"] = data;
            return View(result1);
        }

        public ActionResult NotPaidReports( int Paid = 0)
        {
            try
            {
              

                FinanceDbContext _db = new FinanceDbContext();
                
                IEnumerable<CollectionList> result = _db.CollectionList.SqlQuery(@"exec GetCollectionList  @paidStatus",
                new SqlParameter("@paidStatus", Paid)
                 ).ToList<CollectionList>();
                var data = result;
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("NotPaidReports", data)
                        : View("NotPaidReports", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
        }
        public ActionResult EMIClearance(int? page, String Name = "", int Paid = 0)
        {
            try
            {


                FinanceDbContext _db = new FinanceDbContext();
                var pageIndex = (page ?? 1);
                const int pageSize = 10;
                IEnumerable<CollectionList> result = _db.CollectionList.SqlQuery(@"exec GetCollectionList    @pPageIndex, @pPageSize,@Name,@paidStatus",
                      new SqlParameter("@pPageIndex", pageIndex),
               new SqlParameter("@pPageSize", pageSize),
               new SqlParameter("@Name", Name == null ? (object)DBNull.Value : Name),
                new SqlParameter("@paidStatus", Paid)
                 ).ToList<CollectionList>();
                var data = result;
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("PaidReports", data)
                        : View("PaidReports", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
        }
        public ActionResult EMIDues(int? page, String Name = "", int Paid = 0)
        {
            try
            {


                FinanceDbContext _db = new FinanceDbContext();
                var pageIndex = (page ?? 1);
                const int pageSize = 10;
                IEnumerable<CollectionList> result = _db.CollectionList.SqlQuery(@"exec GetCollectionList    @pPageIndex, @pPageSize,@Name,@paidStatus",
                      new SqlParameter("@pPageIndex", pageIndex),
               new SqlParameter("@pPageSize", pageSize),
               new SqlParameter("@Name", Name == null ? (object)DBNull.Value : Name),
                new SqlParameter("@paidStatus", Paid)
                 ).ToList<CollectionList>();
                var data = result;
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("DuesReports", data)
                        : View("DuesReports", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }

       
        }
        public ActionResult TotalLoanReports(int? Status = 0)
        {
            try
            {


                FinanceDbContext _db = new FinanceDbContext();

                IEnumerable<TotalLoanReports> result = _db.TotalLoanReports.SqlQuery(@"exec UspTotalLoanReport  @Status",
                new SqlParameter("@Status", Status)
                 ).ToList<TotalLoanReports>();
                var data = result;
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("TotalLoanReports", data)
                        : View("TotalLoanReports", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
        }
        public ActionResult TotalServiceCharges(int? MonthID = 0,int type=4)
        {

            try
            {


                FinanceDbContext _db = new FinanceDbContext();

                IEnumerable<TotalServiceCharges> result = _db.TotalServiceCharges.SqlQuery(@"exec UspGetTotalServiceCharges  @MonthID,@type",
                new SqlParameter("@MonthID", MonthID),
                    new SqlParameter("@type", type)
                 ).ToList<TotalServiceCharges>();
                var data = result;
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("TotalServiceCharges", data)
                        : View("TotalServiceCharges", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
           
        }
        public ActionResult TotalServiceChargesGrid(int? MonthID = 0, int type = 4)
        {
          

           


                FinanceDbContext _db = new FinanceDbContext();

                IEnumerable<TotalServiceCharges> result = _db.TotalServiceCharges.SqlQuery(@"exec UspGetTotalServiceCharges  @MonthID,@type",
                new SqlParameter("@MonthID", MonthID),
                    new SqlParameter("@type", type)
                 ).ToList<TotalServiceCharges>();
                 var data = result;
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("TotalServiceChargesGrid", data)
                        : View("TotalServiceChargesGrid", data);
            
            
        }
        public ActionResult LoanStatusReport(int? MonthID = 0, int type = 4)
        {
            try
            {


                FinanceDbContext _db = new FinanceDbContext();

                IEnumerable<LoanStatusReport> result = _db.LoanStatusReport.SqlQuery(@"exec GetLoanStatus  @MonthID,@type",
                new SqlParameter("@MonthID", MonthID),
                  new SqlParameter("@type", type)
                 ).ToList<LoanStatusReport>();
                var data = result;
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("LoanStatusReport", data)
                        : View("LoanStatusReport", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
        }
        public ActionResult LoanStatusList(int? MonthID = 0, int type = 4)
        {
            try
            {


                FinanceDbContext _db = new FinanceDbContext();

                IEnumerable<LoanStatusReport> result = _db.LoanStatusReport.SqlQuery(@"exec GetLoanStatus  @MonthID,@type",
                new SqlParameter("@MonthID", MonthID),
                  new SqlParameter("@type", type)
                 ).ToList<LoanStatusReport>();
                var data = result;
                return Request.IsAjaxRequest()
                        ? (ActionResult)PartialView("LoanStatusList", data)
                        : View("LoanStatusList", data);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return View();

            }
            finally
            {

            }
        }
    }
}

