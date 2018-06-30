using Microsoft.AspNetCore.Mvc;
using PersonOfTheYear.Models;

namespace PersonOfTheYear.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Renders the homepage.
        /// </summary>
        /// <returns>View()</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets a list of people and renders them onto the page.
        /// </summary>
        /// <param name="start">The start year for the list.</param>
        /// <param name="end">The end year for the list.</param>
        /// <returns>View()</returns>
        [HttpGet]
        public IActionResult Search(int start, int end)
        {
            return start <= end ? View(Person.GetPeople(start, end)) 
                : View(Person.GetPeople(end, start));
        }
    }
}
