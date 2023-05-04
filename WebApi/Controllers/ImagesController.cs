using Application.Features.Images.Commands;
using Application.Features.Images.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ISender _mediatrSender;

        public ImagesController(ISender mediatrSender)
        {
            _mediatrSender = mediatrSender;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewImage([FromBody] NewImage newImage)
        {
            var isSuccessful = await _mediatrSender.Send(new CreateImageRequest(newImage));
            if (isSuccessful)
            {
                return Ok("Image created successfully");
            }
            return BadRequest("Failed to add image");

        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateImage([FromBody] UpdateImage updateImage)
        {
            var isSuccessful = await _mediatrSender.Send(new UpdateImageRequest(updateImage));
            if (isSuccessful)
            {
                return Ok("Image updated successfully");
            }
            return NotFound("Failed to update Image");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var image = await _mediatrSender.Send(new GetImageRequest(id));
            if (image == null)
            {
                return NotFound("property doesn't exists");
            }
            return Ok(image);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllImages()
        {
            var images = await _mediatrSender.Send(new GetAllImagesRequest());
            if (images == null)
            {
                return NotFound("images doesn't exists");
            }
            return Ok(images);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Deleteimage(int id)
        {
            var image = await _mediatrSender.Send(new DeleteImageRequest(id));
            if (!image)
            {
                return BadRequest("Unable to delete image");
            }
            return Ok("Image Deleted");
        }
    }
}
