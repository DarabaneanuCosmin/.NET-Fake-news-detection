using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Responses;

namespace WebAPI.Services
{
    [ServiceContract]
    public interface IGetArticlesService
    {
        [OperationContract]
        public GetArticlesResponse GetArticles(string token);
    }
}
