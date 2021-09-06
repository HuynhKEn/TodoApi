using System;
using System.Linq;
using TodoApi.Core.Service;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TodoApi.Controller {
    [ApiController]
    [Route("api/departments")]
    public class DepartmentsController : ControllerBase {
        private readonly DepartmentService _service;
        public DepartmentsController(DepartmentService service) {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get() {
            await _service.AddAllEntitiesAsync();
            return Ok();
        }
    }
}
