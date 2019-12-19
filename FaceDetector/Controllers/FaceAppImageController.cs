using System;
using System.Collections.Generic;
using System.Linq;

using FaceDetector.Dtos;
using FaceDetector.Services.Abstract;

using Microsoft.AspNetCore.Mvc;

namespace FaceDetector.Controllers
{
    [Route("api/faceAppImage")]
    [ApiController]
    public class FaceAppImageController : ControllerBase
    {
        private IFaceService _faceAppImageService;


        public FaceAppImageController(IFaceService faceAppImageService)
        {
            _faceAppImageService = faceAppImageService;
        }

        [HttpGet]
        public IEnumerable<FaceAppImageDto> GetAll()
        {
            var faceAppImages = _faceAppImageService.GetAll();
            return faceAppImages.ToList();
        }

        /// <summary>
        /// Get specific faceAppImage by id
        /// </summary>
        /// <param name="id">FaceAppImage identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public FaceAppImageDto Get(Guid id)
        {
            return _faceAppImageService.GetById(id);
        }
        /// <summary>
        /// Create a new faceAppImage
        /// </summary>
        /// <param name="faceAppImageDto">FaceAppImage object</param>
        /// <returns></returns>
        [HttpPost]
        public FaceAppImageDto Post([FromBody] FaceAppImageDto faceAppImageDto)
        {
            var faceAppImage = _faceAppImageService.Create(faceAppImageDto);
            return faceAppImage;
        }

        /// <summary>
        /// Delete specific faceAppImage by id
        /// </summary>
        /// <param name="id">FaceAppImage identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _faceAppImageService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Update specific faceAppImage by id
        /// </summary>
        /// <param name="id">FaceAppImage identifier</param>
        /// <param name="faceAppImageDto">FaceAppImage object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]FaceAppImageDto faceAppImageDto)
        {
            var faceAppImage = _faceAppImageService.Update(id, faceAppImageDto);
            return Ok(faceAppImage);
        }
    }
}
