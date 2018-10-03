using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace question_bank
{
    public class user
    {
        string name;
        string faculty_id;
        string subject;
        bool isAdmin;
        bool isCoordinator;

        public user(string faculty_id, string name,string subject,bool isAdmin,bool isCoordinator)
        {
            this.name = name;
            this.faculty_id = faculty_id;
            this.subject = subject;
            this.isAdmin = isAdmin;
            this.isCoordinator = isCoordinator;

        }
        
    }
}