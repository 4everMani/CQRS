using Application.Features.Properties.Commands;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ISender _mediatrSender;

        public PropertiesController(ISender mediatrSender)
        {
            _mediatrSender = mediatrSender;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewProperty([FromBody] NewProperty newPropertyRequest)
        {
            var isSuccessful = await _mediatrSender.Send(new CreatePropertyRequest(newPropertyRequest));
            if (isSuccessful)
            {
                return Ok("Property created successfully");
            }
            return BadRequest("Failed to create property");

        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProperty([FromBody] UpdateProperty updateProperty)
        {
            var isSuccessful = await _mediatrSender.Send(new UpdatePropertyRequest(updateProperty));
            if (isSuccessful)
            {
                return Ok("Property updated successfully");
            }
            return NotFound("Failed to update property");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            var property = await _mediatrSender.Send(new GetPropertyRequest(id));
            if (property == null)
            {
                return NotFound("property doesn't exists");
            }
            return Ok(property);
        }
    }
}
