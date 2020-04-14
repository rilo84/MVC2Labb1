using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC2Labb1.Services;
using MVC2Labb1.ViewModels;

namespace MVC2Labb1.Controllers
{
    public class IPController : Controller
    {
        private readonly IGetIpAddressService getIpAddress;

        public IPController(IGetIpAddressService getIpAddress)
        {
            this.getIpAddress = getIpAddress;
        }
        [HttpGet]
        public IActionResult ShowIP()
        {
            string remoteIP = getIpAddress.RemoteIP();

            var model = new IPViewModel { IPAddress = remoteIP };

            return View(model);
        }
    }
}