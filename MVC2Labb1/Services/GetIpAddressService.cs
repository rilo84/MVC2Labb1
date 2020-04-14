using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2Labb1.Services
{
    public class GetIpAddressService : IGetIpAddressService
    {
        private readonly IHttpContextAccessor contextAccessor;

        public GetIpAddressService(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public string RemoteIP()
        {
            return contextAccessor.HttpContext.Connection.LocalIpAddress.ToString();
        }
    }
}
