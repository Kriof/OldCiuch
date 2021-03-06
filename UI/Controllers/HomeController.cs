using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;
using UI.Models.View;
using UI.Services;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemsService _itemsService;

        public HomeController(ILogger<HomeController> logger, IItemsService itemsService)
        {
            _logger = logger;
            _itemsService = itemsService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _itemsService.GetItems().ConfigureAwait(false);
            
            return View(new HomeModel
            {
                Items = items
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
