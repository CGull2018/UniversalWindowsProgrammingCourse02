using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class BL_PageContent
    {
        public static string CreatedBy { get; set; }
        public static string VarOutput1 { get; set; }

        //public ImageSource Source { get; set; }

        public static void Course1()
        {

            VarOutput1 = null;

            string[] names = new string[4] { "COP3488C", "UWP1", "This course is mobile app development.", "This Button Uses a method contacting the BL_PageContent Class" };
            for (int i = 0; i < names.Length; i++)
            {
                VarOutput1 = VarOutput1 + names[i] + "  ";

            }



        }
    }
    }
