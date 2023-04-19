using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gaz.Domain.Entities
{
    public partial class Score
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? MonthScore { get; set; }
        public int? FinalScore { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
