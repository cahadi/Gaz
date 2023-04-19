using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gaz.Domain.Entities
{
    public partial class Mark
    {
        public Mark()
        {
            EstimationsMarks = new HashSet<EstimationsMark>();
        }

        public int Id { get; set; }
        public string? YesNo { get; set; }
        public float? LowMark { get; set; }
        public int? BigMark { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual ICollection<EstimationsMark> EstimationsMarks { get; set; }
    }
}
