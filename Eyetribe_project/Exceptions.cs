using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eyetribe_project {
    public class EyetribeException : Exception {
        public EyetribeException () { }
        public EyetribeException (string message) : base(message) { }
        public EyetribeException (string message, Exception inner) : base(message) { }
    }
    public class TestException : Exception {
    }
}
