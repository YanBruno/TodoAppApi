using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.Src.Commands.Contracts;
using TodoApp.Core.Src.Commands.In.CustomerCommands;
using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Handlers;
using TodoApp.Core.Src.Repositories;

namespace TodoApp.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        private readonly CustomerHandler customerHandler;

        public CustomerController(ICustomerRepository customerRepository, CustomerHandler customerHandler)
        {
            this.customerRepository = customerRepository;
            this.customerHandler = customerHandler;
        }

        [HttpGet]
        [Authorize]
        //[Authorize(Roles = "admin")]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await customerRepository.GetAll();
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<Customer> Get(Guid id)
        {
            return await customerRepository.GetByIdAsync(id);
        }

        [HttpPost("new")]
        [Authorize]
        public Task<ICommandResult> New(CreateCustomerCommand command)
        {
            return customerHandler.HandleAsync(command);
        }
    }
}
