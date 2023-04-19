using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gaz.Domain.Entities
{
    public partial class Onetype
    {
        public Onetype()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; } = null!;
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
