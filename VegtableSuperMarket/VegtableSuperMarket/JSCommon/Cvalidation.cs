using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace VegtableSuperMarket.Common
{
    public class Cvalidation
    {
        bool result = true;
        public Cvalidation()
        {

        }

        public bool compare_password(string password, string cpassword)
        {
            if (password != cpassword)
            {
                result = false;
            }
            return result;
        }

        public bool RequiredField_validation(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                result = false;
            }
            return result;
        }

        public bool age_validation(int value)
        {
            if (value < 18)
            {
                result = false;
            }
            return result;
        }

        public bool phoneno_validation(string value)
        {
            if (value.Length != 10)
            {
                result = false;
            }
            return result;
        }

        public bool phoneno_numeric(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                char[] pno = value.ToCharArray();
                string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                var listnum = from x in numbers
                              where x == pno[i].ToString()
                              select x;
                if (listnum.Count() == 0)
                {
                    result = false;
                    return result;
                }
            }
            return result;
        }


        //string[] numbers = {"1","2","3","4","5","6","7","8","9","0"};
        //bool check = false;
        //foreach (char c in value)
        //{

        //}


        //string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        //foreach (var s in value)
        //{
        //    if (numbers.Contains(s) != false)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        result = true;
        //    }
        //}
        //return result;




        //string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        //List<string> stringList; // populate how you see fit
        //string P_no = numbers.Where(no => value.Contains(no)).ToString();



        public bool Email_validation(string value)
        {
            bool check = false;

            //if((check == value.Contains("@")) && (check == value.Contains(".")))
            if (check = value.Contains("@"))
            {
                if (check = value.Contains("."))
                {
                    return check;
                }
            }
            return check;

        }

        /// <summary>
        /// optional or default parameter
        /// </summary>
        /// <param name="value"> User email in textbox</param>
        /// <param name="emailvalidation1"> parameter one</param>
        /// <param name="emailvalidation2">parameter two</param>
        /// <returns></returns>
        public bool Email_validation1(string value, string emailvalidation1, string emailvalidation2)
        {
            if (value.Contains(emailvalidation1) && value.Contains(emailvalidation2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Email validation using  optional or default parameter
        /// </summary>
        /// <param name="value"> User email in textbox</param>
        /// <param name="emailvalidation1"> parameter one</param>
        /// <param name="emailvalidation2">parameter two</param>
        /// <returns></returns>

        public bool Email_validation2(string value, string emailvalidation1 = "@", string emailvalidation2 = ".")
        {
            if (value.Contains(emailvalidation1) && value.Contains(emailvalidation2))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Phone number is numeric or non-numeric
        /// </summary>
        /// <param name="value">user phonenumber</param>
        /// <param name="Phoneno_numbers"> numeric number 0-9</param>
        /// <returns></returns>

        public bool phoneno_numeric1(string value, params string[] Phoneno_numbers)
        {
            foreach (var x in Phoneno_numbers)
            {
                if (value.Contains(x))
                {
                    result = true;
                }
                else
                {
                    return false;
                }
            }
            return result;
        }

       

    }


}