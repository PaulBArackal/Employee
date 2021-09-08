using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class EmployeeDetails
    {


        static string emp;
        public static string id, name, phno, email;


        static string message = "Enter the Employee details:";
        public static void setMessage(string msg)
        {
            message = msg;
        }



        public static string getMessage()
        {
            return message;
        }

    }

}