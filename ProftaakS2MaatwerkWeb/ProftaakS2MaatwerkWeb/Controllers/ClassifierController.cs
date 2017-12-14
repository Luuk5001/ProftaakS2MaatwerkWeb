using ProftaakS2MaatwerkWeb.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Results;

namespace ProftaakS2MaatwerkWeb.Controllers
{
    /// <summary>
    /// Handles API requests
    /// </summary>
    public class ClassifierController : ApiController
    {
        /// <summary>
        /// Post one image file to get a response from the classifier
        /// </summary>
        public JsonResult<Result> Post()
        {
            string uploadsDir = HttpContext.Current.Server.MapPath("~/App_Data/uploads");

            if (!Directory.Exists(uploadsDir))
            {
                Directory.CreateDirectory(uploadsDir);
            }

            if (HttpContext.Current.Request.Files.Count == 1)
            {
                HttpPostedFile httpPostedFile = HttpContext.Current.Request.Files.Get(0);
                string filename = Guid.NewGuid().ToString() + ".png";
                string fileSavePath = Path.Combine(uploadsDir, filename);           
                httpPostedFile.SaveAs(fileSavePath);

                //TODO

                Result result = new Result(15, "Happy");
                return Json(result);
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "Please post one image file"));
            }
        }
    }
}
