using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gaz.Domain.Entities
{
    public partial class Estimation
    {
        public Estimation()
        {
            EstimationsMarks = new HashSet<EstimationsMark>();
        }

        public int Id { get; set; }
        public string EstimationName { get; set; } = null!;
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual ICollection<EstimationsMark> EstimationsMarks { get; set; }
    }
}
