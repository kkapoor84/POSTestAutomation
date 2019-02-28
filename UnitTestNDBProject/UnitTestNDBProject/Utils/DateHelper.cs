using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestNDBProject.Utils
{
           public static class DateHelper
        {
            /// <summary>
            /// Gets the tomorrow date.
            /// </summary>
            /// <value>
            /// The tomorrow date.
            /// </value>
            public static string TomorrowDate
            {
                get
                {
                    return DateTime.Now.AddDays(1).ToString("ddMMyyyy", CultureInfo.CurrentCulture);
                }
            }

            /// <summary>
            /// Gets the current time stamp.
            /// </summary>
            /// <value>
            /// The current time stamp.
            /// </value>
            public static string CurrentTimeStamp
            {
                get
                {
                    return DateTime.Now.ToString("ddMMyyyyHHmmss", CultureInfo.CurrentCulture);
                }
            }

            /// <summary>
            /// Gets the current date.
            /// </summary>
            /// <value>
            /// The current date.
            /// </value>
            public static string CurrentDate
            {
                get
                {
                    return DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.CurrentCulture);
                }
            }

            /// <summary>
            /// Gets the future date.
            /// </summary>
            /// <param name="numberDaysToAddToNow">The number days to add from current date.</param>
            /// <returns>Date in future depends on parameter: numberDaysToAddToNow</returns>
            public static string GetFutureDate(int numberDaysToAddToNow)
            {
                return DateTime.Now.AddDays(numberDaysToAddToNow).ToString("ddMMyyyy", CultureInfo.CurrentCulture);
            }
        }
}
