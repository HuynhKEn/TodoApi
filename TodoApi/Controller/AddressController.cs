using System;
using TodoApi.Core;
using TodoApi.Models;
using TodoApi.Core.Helpers;
using TodoApi.Core.Factory;
using TodoApi.Core.Context;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Core.Repositories;
using Microsoft.Extensions.Logging;
using TodoApi.Core.Repositories.Interface;

namespace TodoApi.Controller {
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase {

        private readonly ILogger _logger;
        private readonly IAddressRepository _addressRepository;

        public AddressController(ILogger<AddressController> logger, IAddressRepository addressRepository) {
            _logger = logger;
            _addressRepository = addressRepository;
        }

        [HttpPost]
        [Route("create-address")]
        public async Task<ActionResult<Address>> PostAddress(Address todoItem) {
            var task = await _addressRepository.Create(todoItem);
            _logger.LogInformation(3, $"Text");
            return CreatedAtAction(nameof(GetAddress), new { id = todoItem.Id }, task);
        }

        [HttpGet]
        [Route("get-address")]
        public async Task<ActionResult<Address>> GetAddress(Guid id) {
            var result = await _addressRepository.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-list-address")]
        public async Task<ActionResult<Address>> GetListAddress() {
            var result = await _addressRepository.GetTaskList();
            return Ok(result);
        }

    }
}
