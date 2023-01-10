﻿using AjaxDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext _context;
      

        public HomeController(ILogger<HomeController> logger, DemoContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Members()
        {         
            return View(_context.Members);
        }
        public IActionResult Index()
        {
                 
            return View();       
        }
        public IActionResult FirstAjax()
        {
            return View();
        }
        public IActionResult jQuery()
        {
            return View();
        }
        public IActionResult Partial()
        {
            ViewBag.data = "Hello!Partial";
            return PartialView(_context.Members);
        }
        public IActionResult Post()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
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

        public IActionResult FormData()
        {
            return View();
        }

    }
}