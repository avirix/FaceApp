using System;
using System.Collections.Generic;
using System.Linq;

using FaceDetector.Dtos;
using FaceDetector.Services.Services.Abstract;

using Microsoft.AspNetCore.Mvc;

namespace FaceDetector.Controllers
{
    [Route("api/imageFolder")]
    [ApiController]
    public class ImageFolderController : ControllerBase
    {
        private IImageFolderService _imageFolderService;


        public ImageFolderController(IImageFolderService imageFolderService)
        {
            _imageFolderService = imageFolderService;
        }

        [HttpGet]
        public IEnumerable<ImageFolderDto> GetAll()
        {
            var imageFolders = _imageFolderService.GetAll();
            return imageFolders.ToList();
        }

        /// <summary>
        /// Get specific imageFolder by id
        /// </summary>
        /// <param name="id">ImageFolder identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ImageFolderDto Get(Guid id)
        {
            return _imageFolderService.GetById(id);
        }
        /// <summary>
        /// Create a new imageFolder
        /// </summary>
        /// <param name="imageFolderDto">ImageFolder object</param>
        /// <returns></returns>
        [HttpPost]
        public ImageFolderDto Post([FromBody] ImageFolderDto imageFolderDto)
        {
            var imageFolder = _imageFolderService.Create(imageFolderDto);
            return imageFolder;
        }

        /// <summary>
        /// Delete specific imageFolder by id
        /// </summary>
        /// <param name="id">ImageFolder identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _imageFolderService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Update specific imageFolder by id
        /// </summary>
        /// <param name="id">ImageFolder identifier</param>
        /// <param name="imageFolderDto">ImageFolder object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]ImageFolderDto imageFolderDto)
        {
            var imageFolder = _imageFolderService.Update(id, imageFolderDto);
            return Ok(imageFolder);
        }
    }
}
