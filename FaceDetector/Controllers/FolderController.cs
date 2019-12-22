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
    [Authorize]
    public class FolderController : ControllerBase
    {
        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }


        /// <summary>
        /// Get all folders in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<FolderDto> GetAll()
        {
            var folders = _folderService.GetAll();
            return folders.ToList();
        }

        /// <summary>
        /// Get specific folder by id
        /// </summary>
        /// <param name="id">Folder identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public FolderDto Get(Guid id)
        {
            return _folderService.GetById(id);
        }
        /// <summary>
        /// Create a new folder
        /// </summary>
        /// <param name="folderDto">Folder object</param>
        /// <returns></returns>
        [HttpPost]
        public FolderDto Post([FromBody] FolderDto folderDto)
        {
            var folder = _folderService.Create(folderDto);
            return folder;
        }

        /// <summary>
        /// Delete specific folder by id
        /// </summary>
        /// <param name="id">Folder identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _folderService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Update specific folder by id
        /// </summary>
        /// <param name="id">Folder identifier</param>
        /// <param name="folderDto">Folder object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]FolderDto folderDto)
        {
            var folder = _folderService.Update(id, folderDto);
            return Ok(folder);
        }
    }
}
