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
        [HttpGet(Name = "GetAllPeople")]
        public IEnumerable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }


        //updatede get. only one get method per controller
        ////GetAll Async
        //[HttpGet(Name = "GetAllPeopleAsync")]
        //public async Task<IEnumerable<Person>> GetAllAsync()
        //{
        //    return await _personRepository.GetAllAsync();
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
