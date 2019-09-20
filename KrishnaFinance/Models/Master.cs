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
        public int ApplicantID { get; set; }
        public string ApplicantFullName { get; set; }
        public string MobileNo { get; set; }
        public decimal LoanAmount { get; set; }
        public int Duration { get; set; }
        public decimal InterestRate { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string EMIDate { get; set; }
        //public string TransactionID { get; set; }
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
} 













