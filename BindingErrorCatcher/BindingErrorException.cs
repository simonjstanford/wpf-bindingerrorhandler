using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingErrorCatcher
{
    public class BindingErrorException : Exception
    {
        public string SourceObject { get; set; }
        public string SourceProperty { get; set; }
        public string TargetElement { get; set; }
        public string TargetProperty { get; set; }

        public BindingErrorException()
            : base() { }

        public BindingErrorException(string message)
            : base(message) { }

    }
}
