using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gaz.Domain.Entities
{
    public partial class RolesLaw
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int LawId { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        public virtual Law Law { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
