using Microsoft.AspNetCore.Mvc;
using Rehnuma.Models;
using Rehnuma.Service.Quran;
using System.Diagnostics;

namespace Rehnuma.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuranService _quranService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetNextWord(string currentWord, int verseIndex)
        {
            string nextWord = _quranService.GetNextWord(currentWord, verseIndex);
            if (nextWord != null)
            {
                return Ok(new { correctWord = nextWord });
            }
            return BadRequest("Word not found");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
