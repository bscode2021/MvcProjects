using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.Models;

namespace MyFirstMVC.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowPeople()
        {
            List<PersonViewModel> listOfPeople = new List<PersonViewModel>();

            PersonViewModel firstPerson = new PersonViewModel();
            firstPerson.FirstName = "Boban";
            firstPerson.LastName = "Srezovski";

            listOfPeople.Add(firstPerson);

            PersonViewModel secondPerson = new PersonViewModel();
            secondPerson.FirstName = "Goran";
            secondPerson.LastName = "Nikolovski";

            listOfPeople.Add(secondPerson);

            PersonViewModel thirdPerson = new PersonViewModel();
            thirdPerson.FirstName = "Angela";
            thirdPerson.LastName = "Atanasovska";

            listOfPeople.Add(thirdPerson);

            return View(listOfPeople);
        }
    }
}
