using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blend.IT.AppService.Interfaces;
using Blend.IT.AppService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blend.IT.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/student")]
    public class StudentController : Controller
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        // GET: api/Student
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<StudentViewModel> Get()
        {
            return _studentAppService.GetAll();
        }

        // POST: api/Student
        [HttpPost]
        [Authorize(Policy = "Student")]
        public void Post([FromBody]StudentViewModel model)
        {
            _studentAppService.Insert(model);
        }

        // PUT: api/Student
        [HttpPut]
        [Authorize(Policy = "Student")]
        public void Put([FromBody]StudentViewModel model)
        {
            _studentAppService.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Student")]
        public void Delete(int id)
        {
            _studentAppService.Delete(id);
        }
    }
}