using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.OtherClases
{
    public class User
    {
        public PersonDTO Person { get; set; }
        public ICallback Callback { get; set; }
    }
}