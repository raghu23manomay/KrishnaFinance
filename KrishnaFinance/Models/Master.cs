using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KrishnaFinance.Models
{
    public class Application

    {
        [Key]
        public int ApplicantID { get; set; }
        public string ApplicantFullName { get; set; }
        public int ApplicantAge { get; set; }
        public string ApplicantOccupation { get; set; }
        public string MobileNo { get; set; }
        public string PanNo { get; set; }
        public string AdharCardNo { get; set; }
        public decimal ApplicantMonthlyIncome { get; set; }
        public decimal LoanRequest { get; set; }
        public string LoanReason { get; set; }
        public int CreatedBy { get; set; }
        public string PresentAddress { get; set; }
        public string OfficeAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string ChequesFrom { get; set; }
        public string ChequesTo { get; set; }
        public string CoAplicantFullName { get; set; }
        public int CoAplicantAge { get; set; }
        public string CoAplicantOccupation { get; set; }
        public decimal CoApplicantMonthlyIncome { get; set; }
  
        public string Pancardpath { get; set; }
        public string Adharcardpath { get; set; }
        public int UploadBy { get; set; }

    }
    public class ApplicationList
    {
        [Key]
        public int ApplicantID { get; set; }
        public string ApplicantName { get; set; }         
        public int ApplicantAge { get; set; }
        public string CoApplicantName { get; set; }
        public string ApplicantMobileNo { get; set; }
        public string PanNo { get; set; }
        public decimal LoanAmount { get; set; }
        public string ApprovalStatus { get; set; }
        public int? TotalRows { get; set; }
        
    }

    public class LoanApprovalResponse

    {
        [Key]
        public int ApplicantID { get; set; }
        public int ApprovalSendBy { get; set; } 
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Remark { get; set; }
        public DateTime? UpdateDate { get; set; }
         

    }
    public class ApplicationApproval

    {
        [Key]
        public int ApplicantID { get; set; }
        public string ApplicantFullName { get; set; }
        public int ApplicantAge { get; set; }
        public string ApplicantOccupation { get; set; }
        public string MobileNo { get; set; }
        public string PanNo { get; set; }
        public string AdharCardNo { get; set; }
        public decimal ApplicantMonthlyIncome { get; set; }
        public string LoanReason { get; set; }
        public int CreatedBy { get; set; }
        public string PresentAddress { get; set; }
        public string OfficeAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string ChequesFrom { get; set; }
        public string ChequesTo { get; set; }
        public string CoAplicantFullName { get; set; }
        public int CoAplicantAge { get; set; }
        public string CoAplicantOccupation { get; set; }
        public decimal CoApplicantMonthlyIncome { get; set; }
        public string Photograph { get; set; }
        public string Pancardpath { get; set; }
        public string Adharcardpath { get; set; }
        public int UploadBy { get; set; }
        public int status { get; set; }
        public decimal InterestRate { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remark { get; set; }
        public int Duration { get; set; }
        public DateTime EMIDate { get; set; }
        public DateTime DisbursementDate { get; set; }
         public decimal ProcessingFees { get; set; }
        public decimal  GSTOnDisbursement { get; set; }
        public decimal  DisburesdAmount { get; set; }
        public decimal InterestAmount { get; set; }
        

    }

    public class PrintApplication

    {
        [Key]
        public int ApplicantID { get; set; }
        public string ApplicantFullName { get; set; }
        public int ApplicantAge { get; set; }
        public string ApplicantOccupation { get; set; }
        public string MobileNo { get; set; }
        public string PanNo { get; set; }
        public string AdharCardNo { get; set; }
        public decimal ApplicantMonthlyIncome { get; set; }
        public decimal LoanRequest { get; set; }
        public string LoanReason { get; set; }
        public string PresentAddress { get; set; }
        public string OfficeAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string ChequesFrom { get; set; }
        public string ChequesTo { get; set; }
        public string CoAplicantFullName { get; set; }
        public int CoAplicantAge { get; set; }
        public string CoAplicantOccupation { get; set; }
        public decimal CoApplicantMonthlyIncome { get; set; }
        public string Photograph { get; set; }
        public string Pancardpath { get; set; }
        public string Adharcardpath { get; set; }
        public string CompanyAddress { get; set; }
        public string MoneyLenderLicenseNo { get; set; }
        public string CompanyMobileNo { get; set; }
        public decimal CompanyPrice { get; set; }


    }
    public class PrintDemandPromissory

    {
        [Key]
        public int ApplicantID { get; set; }
        public decimal CompanyPrice { get; set; }
        public string CompanyAddress { get; set; }
        public string ApplicantFullName { get; set; }
        public int ApplicantAge { get; set; }
        public string PermanentAddress { get; set; }
        public decimal LoanRequest { get; set; }
        public decimal InterestRate { get; set; }
    }
    public class CollectionList

    {
        [Key]
        public int TransectionID { get; set; }
        public int ApplicantID { get; set; }
        public string ApplicantFullName { get; set; }
        public string MobileNo { get; set; }
        public decimal LoanAmount { get; set; }
        public int Duration { get; set; }
        public decimal InterestRate { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string EMIDate { get; set; }       
        public string Status { get; set; }
        public int? TotalRows { get; set; }

    }
    public class Collectiondata

    {
        [Key]  
        public int ApplicantID { get; set; }
        public string ApplicantFullName { get; set; }
        public string MobileNo { get; set; }
        public int ApprovalID { get; set; }
        public DateTime ApprovalDate { get; set; }
        public decimal LoanAmount { get; set; }
        public int Duration { get; set; }
        public DateTime EMIDate { get; set; }
        public DateTime DisbursementDate { get; set; }
        public decimal TotalEMI { get; set; }
      
    }
    public class Transection

    {
        [Key] 
        public int TransectionID { get; set; }
        public int ApplicantID { get; set; }
        public decimal LoanAmount { get; set; }
        public int Duration { get; set; }
        public int EMICount { get; set; }
        public string BankTransactionID { get; set; }
        public DateTime EMIDate { get; set; }
        public DateTime EMIPaidDate { get; set; }
        public int status { get; set; }
      

    }
    public class GetTransection

    {
        [Key]
        public int TransectionID { get; set; }
        public int ApplicantID { get; set; }
        public string ApplicantFullName { get; set; }
        public string MobileNo { get; set; }
        public decimal LoanAmount { get; set; }
        public int Duration { get; set; }        
        public DateTime EMIDate { get; set; }
        public DateTime DisbursementDate { get; set; }
        public decimal TotalEMI { get; set; }
        public decimal EMIDuePenalty { get; set; }
        public decimal ServiceCharges { get; set; }

    }
    public class ReportsGrid

    {
        [Key]
        public int TransectionID { get; set; }
        public int ApplicantID { get; set; }
        public string ApplicantFullName { get; set; }
        public string MobileNo { get; set; }
        public decimal LoanAmount { get; set; }
        public int Duration { get; set; }
        public decimal InterestRate { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string EMIDate { get; set; }
        public string Status { get; set; }
        public int? TotalRows { get; set; }

    }

    public class ApplicantEmiReport
    {
        [Key]
        public int ApplicantID { get; set; }
        public string ApplicantName { get; set; }
        public int ApplicantAge { get; set; }
        public string CoApplicantName { get; set; }
        public string ApplicantMobileNo { get; set; }
        public string PanNo { get; set; }
        public decimal LoanAmount { get; set; }
        public string ApprovalStatus { get; set; }
        public int? TotalRows { get; set; }
        public int? Duration { get; set; }        

        public IEnumerable<EMIList> _objEMIList { get; set; }
        public IEnumerable<DashboardData> _objDashboardData { get; set; }
    }

    public class EMIList
    {
        [Key]
        public int TransectionID { get; set; }
        public int ApplicantID   { get; set; }
        public int Duration { get; set; }
        public string BankTransactionID { get; set; }
        public string EMIDate     { get; set; }
        public string EMIPaidDate { get; set; }
        public int? status      { get; set; }
        public string status1     { get; set; }
        public decimal TotalAmount { get; set; }

    }

    public class DashboardChart
    {
        [Key]
        public int? MonthID { get; set; }        
        public string MonthNames { get; set; }
        public decimal LoanAmount { get; set; }        

    }

    public class DashboardData
    {
        [Key]
        public string Status { get; set; }
        public Int64? count { get; set; }
               

    }
    //public class Settlement

    //{
    //    [Key]
    //    public int ApplicantID { get; set; }
    //    public string ApplicantFullName { get; set; }
    //    public decimal LoanAmount { get; set; }
    //    public int PaidEMINO { get; set; }
    //    public decimal PaidEMIAmount { get; set; }
    //    public int ReamingEMI { get; set; }
    //    public decimal ReamingEMIAmount { get; set; }
    //    public decimal ServiceCharges { get; set; }
    //    public decimal Total { get; set; }
    //    public decimal BankTransactionID { get; set; }
    //    public decimal Cash { get; set; }
    //    public decimal cheque { get; set; }
    //    public decimal Online { get; set; }

    //}

    public class FetchSettlement
    {
        [Key]
        public int ApplicantID { get; set; }
        public string FullName { get; set; }        
        public decimal Amount { get; set; }
        public int PaidEMICount { get; set; }
        public int RemaningEMICount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemaningAmount { get; set; }
        public decimal ServiceCharges { get; set; }

    }
    public class InsertSettlement
    {
        [Key]
        public int SettlementID                 {get;set;}
        public int ApplicantID                  {get;set;}
     
        public decimal ServiceCharges           {get;set;}
        public decimal TotalAmount              {get;set;}
        public string PaymentMethod             {get;set;}
        public string ChequeNumber              {get;set;}
        public string BankTransactionID { get; set; }
    }

    public class PrintNOC

    {
        [Key]
        public int ApplicantID { get; set; }
        public decimal CompanyPrice { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyMobileNo { get; set; }
        public string ApplicantFullName { get; set; }
        public int ApplicantAge { get; set; }
        public string PermanentAddress { get; set; }
        public decimal LoanRequest { get; set; }
      
    }
    public class MasterSetting

    {
        [Key]
        public int SettingID { get; set; }
        public int Duration { get; set; }
        public decimal EMIDuePenalty { get; set; }
        public decimal EMIDueAmount { get; set; }
        public decimal GSTOnDisbursement { get; set; }
        public decimal ProcessingFees { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal ServiceCharges { get; set; }
        public decimal PreClosingCharges { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal InterestRate { get; set; }


    }
    public class TotalLoanReports

    {
        [Key]
        public int ApplicantID { get; set; }
        public String ApplicantFullName { get; set; }
        public decimal TotalAmountSanctioned { get; set; }
        public decimal DisburesdAmount { get; set; }
        public string DateOfApproval { get; set; }
        public decimal TotalDisburesdAmount { get; set; }


    }

    public class TotalServiceCharges

    {
        [Key]
        public int ApplicantID { get; set; }
        public String ApplicantFullName { get; set; }
        public decimal BasicAmount { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal Total { get; set; }

    }
    public class LoanStatusReport

    {
        [Key]
        public int ApplicantID { get; set; }
        public String ApplicantFullName { get; set; }
        public decimal TotalLoanPaid { get; set; }
        public decimal Received { get; set; }
        public decimal OutStanding { get; set; }
        public decimal TotalPrincipalReceived { get; set; }
         public decimal TotalIntrestReceived { get; set; }
 

}
} 













