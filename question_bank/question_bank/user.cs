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
        int isAdmin;
        int isCoordinator;
        string semester;
        string year;
        string branch;

        public user(string faculty_id, string name,string subject,int isAdmin,int isCoordinator,string branch,string semester,string year)
        {
            this.name = name;
            this.faculty_id = faculty_id;
            this.subject = subject;
            this.isAdmin = isAdmin;
            this.isCoordinator = isCoordinator;
            this.branch = branch;
            this.semester = semester;
            this.year = year;
        }
        
    }
}