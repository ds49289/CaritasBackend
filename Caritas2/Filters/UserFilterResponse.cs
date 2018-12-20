using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caritas2
{
    public class UserFilterResponse
    {
        public IEnumerable UserData { get; set; }
        public int FilterCount { get; set; }
    }
}