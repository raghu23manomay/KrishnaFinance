using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KrishnaFinance.Models
{
    

    public class mail
    {
        [Key]
        public int? User_ID { get; set; }
        public string emailFrom { get; set; }
        public string emailto { get; set; }
        public string Description { get; set; }
        public string subject { get; set; }
    }


    public class mailTemplate
    {
        [Key]
        public int TempId       { get; set; }
        public string Temptitle    { get; set; }
        public string Emailsubject { get; set; }
        public string EmailBody    { get; set; }
    }
     
    public class Login
    {
        [Key]
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string emailId { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }

    }

}