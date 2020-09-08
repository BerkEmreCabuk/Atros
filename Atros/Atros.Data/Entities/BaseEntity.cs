using Atros.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atros.Data.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public Status Status { get; set; } = Status.Active;
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
    }
}
