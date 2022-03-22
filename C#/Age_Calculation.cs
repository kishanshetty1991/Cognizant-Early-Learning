using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateEx1              //DO NOT CHANGE the namespace name
{
    public class Program       //DO NOT CHANGE the class name
    {
        public static void Main(string[] args)    //DO NOT CHANGE the 'Main' method signature
        {
            //Implement code here
            Console.WriteLine("Enter the date of birth (dd-mm-yyyy): ");
            string dob = Console.ReadLine();
            int age = calculateAge(dob);
            Console.WriteLine(age);
            Console.ReadLine();
        }

        public static int calculateAge(string dateOfBirth)
        {
            //Implement code here
            //if date of birth is 22/10/1984
            int birthyear = Int32.Parse(dateOfBirth.Substring(6, 4));//1984
            int birthmonth = Int32.Parse(dateOfBirth.Substring(3, 2));//10
            int birthdate = Int32.Parse(dateOfBirth.Substring(0, 2));//22
            var t = DateTime.Today;//  Todays date ---> 22/03/2022
            var a = (t.Year * 100 + t.Month) * 100 + t.Day;  //20220322
            var b = (birthyear * 100 + birthmonth) * 100 + birthdate; //19841022
            return (a - b - 400) / 10000; //36.0 or 36
        }


    }
}
