using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [HttpGet("all")]
        [Authorize]
        //[Authorize(Roles = "admin")]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await customerRepository.GetAll();
        }

        [HttpGet]
        [Authorize]
        public async Task<Customer> GetCurrent()
        {
            return await customerRepository.GetByIdAsync(Guid.Parse(User.FindFirst(ClaimTypes.Sid)!.Value));
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<Customer> Get(Guid id)
        {
            return await customerRepository.GetByIdAsync(id);
        }

        [HttpPost("new")]
        [AllowAnonymous]
        public Task<ICommandResult> New(CreateCustomerCommand command)
        {
            return customerHandler.HandleAsync(command);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public Task<ICommandResult> Login(AuthenticateCustomerByEmailCommand command)
        {
            return customerHandler.HandleAsync(command);
        }
    }
}
