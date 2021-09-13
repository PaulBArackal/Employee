using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleApp3

{
    class Employee : EmployeeDetails
    {

        public void message()
        {
            Console.WriteLine(getMessage());
        }

        public void collectDetails()
        {


            string usd;
            Console.WriteLine("Enter employee id");
            id = Console.ReadLine();

            String validemployeeid = validateEmployeeId();
            Console.WriteLine("Enter employeename");
            name = Console.ReadLine();

            String validemployeename = validateEmployeeName();

            Console.WriteLine("Enter employee phno");
            phno = Console.ReadLine();

            String validphoneNumber = validateNumber(phno);

            Console.WriteLine("Enter employee email");
            email = Console.ReadLine();


            String validemail = validateEmail(email);

            Console.WriteLine("Enter employee dob DD/MM/YYYY");
            DateTime dob = DateTime.Parse(Console.ReadLine());


            DateTime validdob = validateDateOfBirth(dob);


            Console.WriteLine("employee id :" + validemployeeid);
            Console.WriteLine("employee name :" + validemployeename);
            Console.WriteLine("employee Phoneno :" + validphoneNumber);
            Console.WriteLine("employee email :" + validemail);
            Console.WriteLine("employee dob :" + validdob);
            string validDOB = validdob.ToString("dd/MM/yyyy");
            string connString;
            connString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connString);
            string query = "INSERT INTO EmployeeDetails VALUES('" + validemployeeid + "','"+ validemployeename+"','"+ validphoneNumber+"','"+ validDOB+"','"+validemail+"')";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            Console.WriteLine("Connection Succesfull");
            cmd.ExecuteNonQuery();
            Console.WriteLine("Insertion Succesfull");
            sqlConnection.Close();
            Console.ReadLine();
        }

        public static string validateEmployeeId()
        {

            string str1 = "0000";
            int flag = 1;
            string employeeid = id;
            while (flag == 1)
            {

                int len = employeeid.Length;
                String str2 = employeeid.Substring(3);

                if (len == 7 && !String.IsNullOrEmpty(employeeid) && (employeeid.StartsWith("ace") || employeeid.StartsWith("ACE") == true))
                {
                    flag = 0;
                }
                else
                    flag = 1;

                if (flag == 0)
                {
                    for (int count = 3; count < 7; count++)
                    {
                        if (!Char.IsDigit(employeeid[count]))
                        {
                            flag = 1;
                            break;
                        }
                    }
                }
                if (flag == 1 || Equals(str1, str2) == true)
                {
                    Console.WriteLine("Invalid employee id");
                    Console.WriteLine("Enter employee id ACE....");
                    employeeid = Console.ReadLine();

                }
                else
                {
                    return employeeid;
                }

            }
            return employeeid;
        }

        public static string validateEmployeeName()
        {
            int flag = 0;


            String employeename = name;
            do
            {
                int length = employeename.Length;
                String nameasuppercase = employeename.ToUpper();
                char[] data = nameasuppercase.ToCharArray();
                for (int count = 0; count < length; count++)
                {
                    int asciinum = (int)data[count];
                    if (asciinum != 32)
                    {
                        if (asciinum < 65 || asciinum > 90)
                        {
                            flag = 0;
                            Console.WriteLine("invalid Employee name ");
                            Console.WriteLine("Enter employee name only alphabets");
                            employeename = Console.ReadLine();

                        }
                        else
                            flag = 1;
                    }

                }
                if (flag == 1)
                {

                    return employeename;
                }


            } while (flag == 0);
            return employeename;
        }


        public static string validateNumber(string phoneNumber)
        {
            int flag = 0;

            do
            {
                Regex rgx = new Regex("[5-9][0-9]{9}");

                if (rgx.IsMatch(phoneNumber))
                {

                    return phoneNumber;


                }
                else
                {
                    flag = 0;
                    Console.WriteLine("invalid Phone number the number should start with a number 5-9 and only 10 digits in total");
                    Console.WriteLine("Enter Phoneno");
                    phoneNumber = Console.ReadLine();

                }
            } while (flag == 0);
            return phoneNumber;
        }

        public static string validateEmail(string email)
        {
            int flag;

            do
            {

                Regex rgx = new Regex("^[A-Za-z0-9+_.-]+@[A-Za-z]+.+[A-za-z]+$");

                if (rgx.IsMatch(email))
                {

                    return email;
                }
                else
                {
                    flag = 0;
                    Console.WriteLine("invalid email, it should bein the format __@__.___");
                    Console.WriteLine("Enter the email :");
                    email = Console.ReadLine();
                }
            } while (flag == 0);
            return email;
        }
        public static DateTime validateDateOfBirth(DateTime dob)
        {

            int flag = 0;
            while (flag == 0)
            {

                DateTime now = DateTime.Today;
                TimeSpan a = DateTime.Today - dob;
                int age = (a.Days / 365);
                if (18 < age && age < 60)
                {

                    flag = 1;

                    return dob;
                }
                else
                {
                    flag = 0;
                    Console.WriteLine("invalid DateOfBirth Age shoud be between 18-60");
                    Console.WriteLine("Enter Date of Birth in format DD/MM/YYYY");
                    dob = DateTime.Parse(Console.ReadLine());
                }


            } while (flag == 0) ;
            return dob;
        }
        int flag = 0;

        public void message(int i)
        {
            Console.WriteLine("Details of Employee Submitted successfully");
        }
        public void database()
        {
          
        }
    }
}
