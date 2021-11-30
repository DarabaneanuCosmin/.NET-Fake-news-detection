using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Features.Commands;

namespace WebAPI.Services
{
    public class UserDataService
    {
        InsertArticleCommandHandler handler;
        public UserDataService([FromServices] InsertArticleCommandHandler handler)
        {
            this.handler = handler;
        }
        public bool postData(InsertArticleCommand insert)
        {
            this.handler.InsertArticle(insert);
            return true;
        }
    }
}
