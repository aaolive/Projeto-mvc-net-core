using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_mvc_net_core.Controllers
{
    public class ContatoController :Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}