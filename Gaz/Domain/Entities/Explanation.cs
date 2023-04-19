using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gaz.Domain.Entities
{
    public partial class Explanation
    {
        public int Id { get; set; }
        public string Explanation1 { get; set; } = null!;
        public int UserId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
