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
    [Route("api/v1/teacher")]
    public class TeacherController : Controller
    {
        private readonly ITeacherAppService _teacherAppService;

        public TeacherController(ITeacherAppService teacherAppService)
        {
            _teacherAppService = teacherAppService;
        }

        // GET: api/Teacher
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<TeacherViewModel> Get()
        {
            return _teacherAppService.GetAll();
        }

        // POST: api/Teacher
        [HttpPost]
        [Authorize(Policy = "Teacher")]
        public void Post([FromBody]TeacherViewModel model)
        {
            _teacherAppService.Insert(model);
        }

        // PUT: api/Teacher
        [HttpPut]
        [Authorize(Policy = "Teacher")]
        public void Put([FromBody]TeacherViewModel model)
        {
            _teacherAppService.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Teacher")]
        public void Delete(int id)
        {
            _teacherAppService.Delete(id);
        }
    }
}
