using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreetMe_DataAccess.Model;
using GreetMe_DataAccess.Repsitory;

namespace GreetMe_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PeopleController : Controller
    {
        private readonly PersonRepository _personRepository;

        [ActivatorUtilitiesConstructor]

        public PeopleController()
        {
            _personRepository = new PersonRepository();
        }

        //-----------------------------------------------------------------------------
        /* GetAll                                                                    */
        //-----------------------------------------------------------------------------

        //GetAll
        [HttpGet]
        public IActionResult GetAllPeople()
        {
            IEnumerable<Person> people = _personRepository.GetAll();
            //return Json(people);
            return View();
        }

        //GetAll Async
        [HttpGet]
        public async Task<IActionResult> GetAllPeopleAsync()
        {
            IEnumerable<Person> people = await _personRepository.GetAllAsync();
            //return Json(people);
            return View();
        }

        ////With Select
        //public IActionResult GetAllPeople()
        //{
        //    IEnumerable<Person> people = db.People.Select(p => p).ToList();
        //    return View(people);
        //}

        //-----------------------------------------------------------------------------
        /* Get / Read                                                                */
        //-----------------------------------------------------------------------------



        //-----------------------------------------------------------------------------
        /* Create / Post                                                              */
        //-----------------------------------------------------------------------------



        //-----------------------------------------------------------------------------
        /* Update                                                                    */
        //-----------------------------------------------------------------------------



        //-----------------------------------------------------------------------------
        /* Delete                                                                    */
        //-----------------------------------------------------------------------------
    }
}
