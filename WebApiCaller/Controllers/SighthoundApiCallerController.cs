using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCaller.Controllers
{
    [Produces("application/json")]
    public class SighthoundApiCallerController : BaseController
    {
        [HttpPost]
        [Route("api/sighthond/uploadImage")]
        public void UploadImage([FromBody]string value)
        {
            var test = value;
        }
    }
}