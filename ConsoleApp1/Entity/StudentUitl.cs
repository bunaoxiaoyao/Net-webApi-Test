using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entity
{
    public class StudentUitl
    {
        //学生

        private int id;//id
        private string name;//姓名
        private int student_id;//学号
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string NAME
        {
            get { return name; }
            set { name = value; }

        }
        public int STUDENT_ID 
        {
            get { return student_id; }
            set { student_id = value; }
        }

    }
}
