using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaceDetector.Abstractions.Entities
{
    public abstract class CommonModel<T>
    {
        [Key]
        public T Id { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey("CreatedId")]
        public BaseUser CreatedBy { get; set; }

        public DateTime LastUpdated { get; set; }

        [ForeignKey("UpdatedId")]
        public BaseUser LastUpdatedBy { get; set; }
    }
}
