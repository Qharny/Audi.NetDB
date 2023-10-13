using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AuditNetProject.Models;

namespace AuditNetProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //return View();
        return Ok(new { success = true });
    }

    public IActionResult Privacy()
    {
        // return View();
        return Ok(new { success = true });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        // return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        return Ok( new { success = true });
    }
}

