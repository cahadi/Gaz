using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gaz.Domain.Entities
{
    public partial class Role
    {
        public Role()
        {
            RolesLaws = new HashSet<RolesLaw>();
            UsersRoles = new HashSet<UsersRole>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; } = null!;
        public int? TimeId { get; set; }
        public int? IndicatorId { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        public virtual Indicator? Indicator { get; set; }
        public virtual EditTime? Time { get; set; }
        [JsonIgnore]
        public virtual ICollection<RolesLaw> RolesLaws { get; set; }
        [JsonIgnore]
        public virtual ICollection<UsersRole> UsersRoles { get; set; }
    }
}
