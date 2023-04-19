using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gaz.Domain.Entities
{
    public partial class Poll
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EstimationsMarksId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        public virtual EstimationsMark EstimationsMarks { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
