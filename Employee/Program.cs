using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.message();
            employee.collectDetails();
            employee.message(1);
            Console.ReadLine();
        }
    }
}
