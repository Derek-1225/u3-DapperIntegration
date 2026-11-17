using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Orders.Api.models;
using Orders.Api.models.dapper;
using Orders.Api.models.dtos;
using Orders.Api.repository;
using Orders.Api.services;

namespace Orders.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderController : ControllerBase
    {
        /* private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        } */

        /*[HttpPost]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
            var (HasError,orderId) = _orderService.CreateOrder(createOrderDto);
            return HasError ? StatusCode(500,new {Message="Ocurrio un Error Inesperado"}) : StatusCode(201,new {orderId});
        }

        [HttpGet("finishedOrders")]
        public IActionResult GetFinishedOrders()
        {
            var finishedOrders = _orderService.GetFinishedOrders();
            return StatusCode(200,new {finishedOrders});
        }

        //api/Order/total
        [HttpGet("total")]
        public IActionResult GetTotalOrder()
        {
            var totalOrders = _orderService.GetOrdersCount();
            return StatusCode(200,new {totalOrders});
        }

        [HttpPut("EditOrder")]
        public IActionResult EditOrder(EditOrderDto editOrderDto)
        {
            var (HasError,Message) = _orderService.EditOrder(editOrderDto);
            return HasError ? StatusCode(500,new {Message="Ocurrio un Error Inesperado"}) : StatusCode(200,new {editOrderDto.OrderId, Message});
        } */
        private readonly IDapperService _dapperService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ITransportOrderRepository _transportOrderRepository;

        public OrderController(ICustomerRepository customerRepository, IVehicleRepository vehicleRepository, ITransportOrderRepository transportOrderRepository)
        {
            _customerRepository = customerRepository;
            _vehicleRepository = vehicleRepository;
            _transportOrderRepository = transportOrderRepository;
        }

        //------Customers--------
        [HttpGet("Customers/GetAll")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerRepository.GetAll();

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);
        }


        [HttpGet("Customers/GetById")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var result = await _customerRepository.GetById(id);

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);

        }
        
        //Create
        [HttpPost("Customers/Create")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var result = await _customerRepository.CreateCustomer(createCustomerDto);

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);         
        }

        //Update
        [HttpPut("Customers/Update")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var result = await _customerRepository.UpdateCustomer(updateCustomerDto);

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);            
        }


        [HttpDelete("Customers/Delete")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerRepository.DeleteCustomer(id);

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);     
        }

        //------Vehicles--------
        [HttpGet("Vehicles/GetAll")]
        public async Task<IActionResult> GetAllVehicles()
        {
            var result = await _vehicleRepository.GetAll();

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);
        }


        [HttpGet("Vehicles/GetById")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var result = await _vehicleRepository.GetById(id);

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);
        }

        //Create
        [HttpPost("Vehicles/Create")]
        public async Task<IActionResult> CreateVehicle(CreateVehicleDto createVehicleDto)
        {
            var result = await _vehicleRepository.CreateVehicle(createVehicleDto);

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);         
        }

        //Update
        [HttpPut("Vehicles/Update")]
        public async Task<IActionResult> UpdateVehicle(UpdateVehicleDto updateVehicleDto)
        {
            var result = await _vehicleRepository.UpdateVehicle(updateVehicleDto);

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);            
        }


        [HttpDelete("Vehicles/Delete")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var result = await _vehicleRepository.DeleteVehicle(id);

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);     
        }


        //------TransportOrders--------
        [HttpGet("TransportOrders/GetAll")]
        public async Task<IActionResult> GetAllTransportOrders()
        {
            var result = await _transportOrderRepository.GetAll();

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);     
        }


        [HttpGet("TransportOrders/GetById")]
        public async Task<IActionResult> GetTransportOrderById(int id)
        {
            var result = await _transportOrderRepository.GetById(id);

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);     
        }



        //Create
        [HttpPost("TransportOrders/Create")]
        public async Task<IActionResult> CreateTransportOrder(CreateTransportOrderDto createTransportOrderDto)
        {
            var result = await _transportOrderRepository.CreateTransportOrder(createTransportOrderDto);

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);         
        }

        //Update
        [HttpPut("TransportOrders/Update")]
        public async Task<IActionResult> UpdateTransportOrder(UpdateTransportOrderDto updateTransportOrderDto)
        {
            var result = await _transportOrderRepository.UpdateTransportOrder(updateTransportOrderDto);

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);            
        }


        [HttpDelete("TransportOrders/Delete")]
        public async Task<IActionResult> DeleteTransportOrder(int id)
        {
            var result = await _transportOrderRepository.DeleteTransportOrder(id);

            if (!result.Success)
                return BadRequest(result.InnerException);

            return Ok(result.Result);     
        }
    }    
}