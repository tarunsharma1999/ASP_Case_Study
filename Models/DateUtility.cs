using System;
using System.Globalization;

namespace TruYum_ASP.Controllers
{
    public class DateUtility
    {
        public DateTime ConvertToShortDateString(string inputDate)
        {
            DateTime dt = new DateTime(); 
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                dt = DateTime.ParseExact(inputDate, "dd-MM-yyyy", provider);
            }
            catch (Exception)
            {
                Console.WriteLine("Date not converted ! ");
            }
            return dt;
        }

        public bool checkDate(DateTime dt)
        {
            bool isStock;
            if (DateTime.Now.Year < dt.Year)
            {
                isStock = false;
            }
            else if (DateTime.Now.Year > dt.Year)
            {
                isStock = true;
            }
            else
            {
                if (DateTime.Now.Month < dt.Month)
                {
                    isStock = false;
                }
                else if (DateTime.Now.Month > dt.Month)
                {
                    isStock = true;
                }
                else
                {
                    if (dt.Day <= DateTime.Now.Day)
                    {
                        isStock = true;
                    }
                    else
                    {
                        isStock = false;
                    }
                }
            }

            if (isStock)
            {
                return true;
            }
            return false;
        }
    }
}
