using System;
using System.Collections.Generic;

namespace Atros.Data.Entities
{
    public class User: BaseEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<MovieEvaluation> MovieEvaluationEntity { get; set; }
    }
}
