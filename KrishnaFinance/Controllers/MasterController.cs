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
        //Print DEMAND PROMISSORY 
       
        //Print PrintApplicantDemandPromissory 
        public ActionResult PrintApplicantDemandPromissory()
        {
            return View();
        }
        //save Application
        [HttpPost]
        public ActionResult SaveApplication(Application AP)
        {

            try
            {
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
                    @Photograph              ,
                    @DocumentName            ,
                    @DocumentPath            ,
                    @UploadBy,@ApplicantID",



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
                    new SqlParameter("@Photograph","Coapllicant"),
                    new SqlParameter("@DocumentName","DocumentName"),
                    new SqlParameter("@DocumentPath","DocumentPath"),
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

        public ActionResult AddApplication(int ApplicantID = 0)
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
            ApplicationList clist = new ApplicationList();

            IEnumerable<ApplicationList> result = _db.ApplicationList.SqlQuery(@"exec GetApplication
                   @pPageIndex, @pPageSize,@Name",
               new SqlParameter("@pPageIndex", pageIndex),
               new SqlParameter("@pPageSize", pageSize),
               new SqlParameter("@Name", Name == null ? (object)DBNull.Value : Name)
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
        public ActionResult ApprovalResponse(int ApplicantID, int CreatedBy , int status, decimal Amount ,decimal InterestRate , decimal PrincipalAmount , decimal TotalAmount , string Remark , String Duration)
        {
            try
            {
                FinanceDbContext _db = new FinanceDbContext();
                var result = _db.Database.ExecuteSqlCommand(@"exec uspLoanApprovalResponse @ApplicantID , @CreatedBy,@status,@Amount,@InterestRate,@PrincipalAmount,@TotalAmount,@Remark,@Duration",
                     new SqlParameter("@ApplicantID", ApplicantID),
                     new SqlParameter("@CreatedBy", CreatedBy), 
                     new SqlParameter("@status", status),
                     new SqlParameter("@Amount", Amount),
                     new SqlParameter("@InterestRate", InterestRate), 
                     new SqlParameter("@PrincipalAmount", PrincipalAmount),
                     new SqlParameter("@TotalAmount", TotalAmount),
                     new SqlParameter("@Remark", Remark) ,
                     new SqlParameter("@Duration", Duration));

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
            FinanceDbContext _db = new FinanceDbContext();
            ApplicationApproval data = new ApplicationApproval();
            var result = _db.ApplicationApproval.SqlQuery(@"exec GetApplicationApproval @ApplicantID",
            new SqlParameter("@ApplicantID", ApplicantID)
             ).ToList<ApplicationApproval>();
              data = result.FirstOrDefault();
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
    }
}

