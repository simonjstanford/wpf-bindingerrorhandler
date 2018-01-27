using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace BindingErrorCatcher
{
    public class BindingErrorTraceListener : TraceListener
    {
        private const string BindingErrorPattern = @"^BindingExpression path error(?:.+)'(.+)' property not found(?:.+)object[\s']+(.+?)'(?:.+)target element is '(.+?)'(?:.+)target property is '(.+?)'(?:.+)$";

        public override void Write(string message) { }

        public override void WriteLine(string message)
        {
#if DEBUG

            //output to the console
            Trace.WriteLine(string.Format("==[WriteLine]{0}==", message));

            //throw an error
            var xx = new BindingErrorException(message);

            var match = Regex.Match(message, BindingErrorPattern);
            if (match.Success)
            {
                xx.SourceObject = match.Groups[2].ToString();
                xx.SourceProperty = match.Groups[1].ToString();
                xx.TargetElement = match.Groups[3].ToString();
                xx.TargetProperty = match.Groups[4].ToString();
            }

            MessageBox.Show(xx.ToString());

            //throw xx;

#endif
        }
    }
}
