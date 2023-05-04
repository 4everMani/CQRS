using Application.Features.Properties.Commands;
using Application.Features.Properties.Queries;
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

        [HttpGet("all")]
        public async Task<IActionResult> GetAllProperties()
        {
            var properties = await _mediatrSender.Send(new GetAllPropertiesRequest());
            if (properties == null)
            {
                return NotFound("property doesn't exists");
            }
            return Ok(properties);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var properties = await _mediatrSender.Send(new DeletePropertyRequest(id));
            if (!properties)
            {
                return BadRequest("Unable to delete property");
            }
            return Ok("Property Deleted");
        }
    }
}
