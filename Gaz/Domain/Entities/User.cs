using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gaz.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Explanations = new HashSet<Explanation>();
            Polls = new HashSet<Poll>();
            Scores = new HashSet<Score>();
            UsersRoles = new HashSet<UsersRole>();
        }

        public int Id { get; set; }
        public string Fio { get; set; } = null!;
        public string? ServiceNumber { get; set; }
        public string? Division { get; set; }
        public string? Position { get; set; }
        public int? TypeId { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        public virtual Onetype? Type { get; set; }
        public virtual ICollection<Explanation> Explanations { get; set; }
        public virtual ICollection<Poll> Polls { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
        public virtual ICollection<UsersRole> UsersRoles { get; set; } = null!;
    }
}
