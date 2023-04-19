using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gaz.Domain.Entities
{
    public partial class EstimationsMark
    {
        public EstimationsMark()
        {
            Polls = new HashSet<Poll>();
        }

        public int Id { get; set; }
        public int EstimationId { get; set; }
        public int MarkId { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        public virtual Estimation Estimation { get; set; } = null!;
        public virtual Mark Mark { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Poll> Polls { get; set; }
    }
}
