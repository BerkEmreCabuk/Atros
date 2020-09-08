using System;

namespace Atros.Data.Entities
{
    public class MovieEvaluation : BaseEntity
    {
        public long MovieId { get; set; }
        public Guid UserId { get; set; }
        public string Note { get; set; }
        public byte Score { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
