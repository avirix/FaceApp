using System;
using System.Collections.Generic;
using System.Linq;

using FaceDetector.Dtos;
using FaceDetector.Services.Abstract;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaceDetector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private IFaceService _imageService;

        //Constructor
        public ImageController(IFaceService imageService)
        {
            _imageService = imageService;
        }

        /// <summary>
        /// Get all images in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ImageDto> GetAll()
        {
            var images = _imageService.GetAll();
            return images.ToList();
        }

        /// <summary>
        /// Get specific image by id
        /// </summary>
        /// <param name="id">Image identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ImageDto Get(Guid id)
        {
            return _imageService.GetById(id);
        }
        /// <summary>
        /// Create a new image
        /// </summary>
        /// <param name="imageDto">Image object</param>
        /// <returns></returns>
        [HttpPost]
        public ImageDto Post([FromBody] ImageDto imageDto)
        {
            var image = _imageService.Create(imageDto);
            return image;
        }

        /// <summary>
        /// Delete specific image by id
        /// </summary>
        /// <param name="id">Image identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _imageService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Update specific image by id
        /// </summary>
        /// <param name="id">Image identifier</param>
        /// <param name="imageDto">Image object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]ImageDto imageDto)
        {
            var image = _imageService.Update(id, imageDto);
            return Ok(image);
        }
    }
}
