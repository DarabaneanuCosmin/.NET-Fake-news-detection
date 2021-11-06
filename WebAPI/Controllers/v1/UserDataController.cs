using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class UserDataController: BaseController
    {
        [HttpPost]
        public string Post()
        {
            return "hi";
        }

        [HttpGet]
        public IEnumerable<DataNews> Get(int id)
        {
            return Enumerable.Range(1, 1).Select(index => new DataNews
            {
                Title = "As U.S. budget fight looms, Republicans flip their fiscal script",
                Text = "WASHINGTON (Reuters) - The head of a conservative Republican faction in the U.S. Congress, who voted...",
                Subject = "politicsNews",
                Date = new DateTime(2017,12,31)
                    
            }).ToArray();
        }
    }
}