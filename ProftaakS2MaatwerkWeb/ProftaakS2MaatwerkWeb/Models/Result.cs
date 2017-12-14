using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakS2MaatwerkWeb.Models
{
    public class Result
    {
        public Result(int age, string emotion)
        {
            Age = age;
            Emotion = emotion;
        }

        public int Age { get; set; }
        public string Emotion { get; set; }
    }
}