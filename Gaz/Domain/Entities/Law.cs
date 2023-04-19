using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gaz.Domain.Entities
{
    public partial class Law
    {
        public Law()
        {
            RolesLaws = new HashSet<RolesLaw>();
        }

        public int Id { get; set; }
        public string LawName { get; set; } = null!;
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual ICollection<RolesLaw> RolesLaws { get; set; }
    }
}
