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
        [HttpGet(Name = "GetItAll2")]
        public IEnumerable<Person> Get()
        {
            return _personRepository.GetAll();
        }

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
