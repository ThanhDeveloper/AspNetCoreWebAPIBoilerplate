using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.API.Filters;
using Project.Core.DTOs;
using Project.Core.DTOs.Customer;
using Project.Core.Entities;
using Project.Core.Services;

namespace Project.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomersController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        // GET api/customers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerService.GetAllAsync();
            var customerDtos = _mapper.Map<List<CustomerDto>>(customers.ToList());
            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customerDtos));
        }
        
        // GET api/customers/id
        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundIdFilter<Customer>))]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(200, customerDto));
        }
        
        // POST api/customers
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateDto customerCreateDto)
        {
            var customerCreated = await _customerService.AddAsync(_mapper.Map<Customer>(customerCreateDto));
            var newCustomer = _mapper.Map<CustomerDto>(customerCreated);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(201, newCustomer));
        }
        
        // PUT api/customers
        [HttpPut]
        [ServiceFilter(typeof(NotFoundUpdateFilter<Customer>))]
        public async Task<IActionResult> Update(CustomerUpdateDto customerUpdateDto)
        {
            await _customerService.UpdateAsync(_mapper.Map<Customer>(customerUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        
        // DELETE api/customers/id
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundIdFilter<Customer>))]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _customerService.GetByIdAsync(id);
            await _customerService.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}