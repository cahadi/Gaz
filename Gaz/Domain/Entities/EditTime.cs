using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gaz.Domain.Entities
{
    public partial class EditTime
    {
        public EditTime()
        {
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public int Date { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }
        [JsonIgnore]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
