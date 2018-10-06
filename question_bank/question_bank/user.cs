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
        public string get_faculty_id()
        {
            return faculty_id;
        }
        public string get_faculty_name()
        {
            return name;
        }
        public string get_subject()
        {
            return subject;

        }
        public string get_branch()
        {
            return branch;
        }
        public string get_semester()
        {
            return semester;

        }
        public string get_year()
        {
            return year;
        }
    }
}