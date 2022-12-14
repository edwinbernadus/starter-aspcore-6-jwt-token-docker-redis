using System;
using System.Collections.Generic;
using System.IO;
using ExploreIdentityServer6.Contract.RootListOne;
using Microsoft.AspNetCore.Mvc;

namespace ExploreIdentityServer6.Controllers
{
    public class DataController : Controller
    {
        private static List<Datum> _datums = new List<Datum>();
        
        // [HttpPost]
        // public string InsertData()
        // {
        //     HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
        //
        //     using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
        //     {
        //         string body = stream.ReadToEnd();
        //         // body = "param=somevalue&param2=someothervalue"
        //     }
        //     return "ok";
        // }
        
        
        // /data/insertData
        [HttpPost]
        public string InsertData([FromBody] Datum datum)
        {
            _datums.Add(datum);
            return "ok";
        }

        // /data/inquiry
        public RootListOne Inquiry()
        {
            var output = new RootListOne();
            output.data = new List<Datum>();

            {
                Datum datum = new Datum()
                {
                    id = 1,
                    title = "title1",
                    detail = "detail1",
                    category = "category1",
                    status = "status1",
                    label = "label1",
                    labelColor = "",
                    date = "",
                    questions = new List<Question>(),
                };
                output.data.Add(datum);
            }

            {
                Datum datum = new Datum()
                {
                    id = 2,
                    title = "title2",
                    detail = "detail2",
                    category = "category2",
                    status = "status2",
                    label = "label2",
                    labelColor = "",
                    date = "",
                    questions = new List<Question>(),
                };
                output.data.Add(datum);
            }

            output.status = true;

            output.data.AddRange(_datums);
            return output;
        }
    }
}