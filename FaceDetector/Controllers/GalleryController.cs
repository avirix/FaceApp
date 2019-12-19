using System;
using System.Collections.Generic;
using System.Linq;

using FaceDetector.Dtos;
using FaceDetector.Services.Abstract;

using Microsoft.AspNetCore.Mvc;

namespace FaceDetector.Controllers
{
    [Route("api/gallery")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private IGalleryService _galleryService;


        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        [HttpGet]
        public IEnumerable<GalleryDto> GetAll()
        {
            var gallerys = _galleryService.GetAll();
            return gallerys.ToList();
        }

        /// <summary>
        /// Get specific gallery by id
        /// </summary>
        /// <param name="id">Gallery identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public GalleryDto Get(Guid id)
        {
            return _galleryService.GetById(id);
        }
        /// <summary>
        /// Create a new gallery
        /// </summary>
        /// <param name="galleryDto">Gallery object</param>
        /// <returns></returns>
        [HttpPost]
        public GalleryDto Post([FromBody] GalleryDto galleryDto)
        {
            var gallery = _galleryService.Create(galleryDto);
            return gallery;
        }

        /// <summary>
        /// Delete specific gallery by id
        /// </summary>
        /// <param name="id">Gallery identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _galleryService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Update specific gallery by id
        /// </summary>
        /// <param name="id">Gallery identifier</param>
        /// <param name="galleryDto">Gallery object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]GalleryDto galleryDto)
        {
            var gallery = _galleryService.Update(id, galleryDto);
            return Ok(gallery);
        }
    }
}
