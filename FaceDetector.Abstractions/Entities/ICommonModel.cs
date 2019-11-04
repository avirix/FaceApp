using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaceDetector.Abstractions.Entities
{
    public interface ICommonModel<T>
    {
        [Key]
        public T Id { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey("CreatedId")]
        public IBaseUser CreatedBy { get; set; }

        public DateTime LastUpdated { get; set; }

        [ForeignKey("UpdatedId")]
        public IBaseUser LastUpdatedBy { get; set; }
    }
}
