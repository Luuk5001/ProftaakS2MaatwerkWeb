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
    public enum Emotions
    {
        Anger,
        Happiness,
        Surprise,
        Disgust,
        Sadness,
        Fear
    }
    /// <summary>
    /// Handles API requests
    /// </summary>
    public class ClassifierController : ApiController
    {
        /// <summary>
        /// Get array of possible emotions
        /// </summary>
        public string[] Get()
        {
            return Enum.GetNames(typeof(Emotions));
        }

        /// <summary>
        /// Post one image file to get a response from the classifier
        /// </summary>
        public Result Post()
        {
            string uploadsDir = HttpContext.Current.Server.MapPath("~/Data");

            if (!Directory.Exists(uploadsDir))
            {
                Directory.CreateDirectory(uploadsDir);
            }

            if (HttpContext.Current.Request.Files.Count == 1)
            {
                HttpPostedFile httpPostedFile = HttpContext.Current.Request.Files.Get(0);
                string filename = Guid.NewGuid().ToString() + ".png";
                string fileSavePath = Path.Combine(uploadsDir, filename);
                try
                {
                    httpPostedFile.SaveAs(fileSavePath);

                    //Hier komt de classifier












                    return new Result(15, Emotions.Happiness.ToString());
                }
                catch(Exception e)
                {
                    return new Result(15, Emotions.Happiness.ToString());
                    //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, e.ToString()));
                }             
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "Please post one image file"));
            }
        }
    }
}
