using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UsersPostsCommentsExcercises
{
    public class FileLogHelper
    {
        public string Get_Executing_Method_Name(Exception exception)
        {
            var trace = new StackTrace(exception);
            var frame = trace.GetFrame(3);
            var method = frame.GetMethod();

            return string.Concat(method.DeclaringType.FullName, ".", method.Name);
        }
        public string Get_Date_Now()
        {
            DateTime dtNow = DateTime.Now;
            string dateFormat = $"Date: {dtNow.Year}-{dtNow.Month}-{dtNow.Day} {dtNow.Hour}:{dtNow.Minute}:{dtNow.Second}";
            return dateFormat;
        }

        public void Save(AssertFailedException afe)
        {
            string methodName = Get_Executing_Method_Name(afe);
            string getDate = Get_Date_Now();
            string content = getDate + Environment.NewLine +
                "Where: " + methodName + Environment.NewLine +
                "What: " + afe.Message + Environment.NewLine + Environment.NewLine;
            //File.WriteAllText("failed_tests.txt", content);

            TextWriter tw = new StreamWriter("failed_tests.txt", true);
            tw.Write(content);
            tw.Close();
        }
    }
}
