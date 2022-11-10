using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.Data;
using MyFirstMVC.Models;
using MyFirstMVC.Models.Entities;

namespace MyFirstMVC.Controllers
{
    public class PeopleController : Controller
    {
        private FirstContext dbCon;

        public PeopleController(FirstContext dbCon)
        {
            this.dbCon = dbCon;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowPeople()
        {
            IEnumerable<Person> listOfPeople = dbCon.People;

            return View(listOfPeople);
        }

        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public IActionResult CreatePerson(Person person)
        {
            dbCon.People.Add(person);
            dbCon.SaveChanges();

            return RedirectToAction(nameof(ShowPeople));
        }
    }
}
