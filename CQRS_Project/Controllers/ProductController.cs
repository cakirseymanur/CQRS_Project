using CQRS_Project.CQRS.Handlers.ProductHandlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly GetProductAccounterQueryHandler _getProductAccounterQueryHandler;

        public ProductController(GetProductAccounterQueryHandler getProductAccounterQueryHandler)
        {
            _getProductAccounterQueryHandler = getProductAccounterQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductAccounterQueryHandler.Handle();

            return View(values);
        }
    }
}
