using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BUOTOnline.Web.API
{
    public class CategoryController : ApiController
    {
        [HttpGet, Route("api/test")]
        public string Test()
        {
            return "testAPI";
        }
    }
}
