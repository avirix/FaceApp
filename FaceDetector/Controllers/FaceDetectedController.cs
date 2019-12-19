using System;
using System.Collections.Generic;
using System.Linq;

using FaceDetector.Dtos;
using FaceDetector.Services.Services.Abstract;

using Microsoft.AspNetCore.Mvc;

namespace FaceDetector.Controllers
{
    [Route("api/faceDetected")]
    [ApiController]
    public class FaceDetectedController : ControllerBase
    {
        private IFaceDetectedService _faceDetectedService;


        public FaceDetectedController(IFaceDetectedService faceDetectedService)
        {
            _faceDetectedService = faceDetectedService;
        }

        [HttpGet]
        public IEnumerable<FaceDetectedDto> GetAll()
        {
            var faceDetecteds = _faceDetectedService.GetAll();
            return faceDetecteds.ToList();
        }

        /// <summary>
        /// Get specific faceDetected by id
        /// </summary>
        /// <param name="id">FaceDetected identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public FaceDetectedDto Get(Guid id)
        {
            return _faceDetectedService.GetById(id);
        }
        /// <summary>
        /// Create a new faceDetected
        /// </summary>
        /// <param name="faceDetectedDto">FaceDetected object</param>
        /// <returns></returns>
        [HttpPost]
        public FaceDetectedDto Post([FromBody] FaceDetectedDto faceDetectedDto)
        {
            var faceDetected = _faceDetectedService.Create(faceDetectedDto);
            return faceDetected;
        }

        /// <summary>
        /// Delete specific faceDetected by id
        /// </summary>
        /// <param name="id">FaceDetected identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _faceDetectedService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Update specific faceDetected by id
        /// </summary>
        /// <param name="id">FaceDetected identifier</param>
        /// <param name="faceDetectedDto">FaceDetected object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]FaceDetectedDto faceDetectedDto)
        {
            var faceDetected = _faceDetectedService.Update(id, faceDetectedDto);
            return Ok(faceDetected);
        }
    }
}
