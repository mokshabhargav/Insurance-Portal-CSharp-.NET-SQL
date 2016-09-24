using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbmsProjBO
{
    public class UserLoginBO
    {
        private string ssn;

        public string Ssn
        {
            get { return ssn; }
            set { ssn = value; }
        }
        private string firstname;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private char gender;

        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private string emailId;

        public string EmailId
        {
            get { return emailId; }
            set { emailId = value; }
        }
        private string mobileNo;

        public string MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
