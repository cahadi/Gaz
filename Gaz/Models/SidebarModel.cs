using Gaz.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gaz.Models
{
    public class SidebarModel
    {
        public bool Admin { get; set; }
        public bool Discipline { get; set; }
        public bool Side { get; set; }
        public bool Dis { get; set; }
        public bool Stop { get; set; }
        public bool Rac { get; set; }
        public bool Ber { get; set; }
        public bool Ruk { get; set; }
        public bool Pol { get; set; }
        public bool Nast { get; set; }
        public bool Prof { get; set; }
        public bool Ecolog { get; set; }
        public bool Sport { get; set; }
        public bool Kult { get; set; }
        public bool Blag { get; set; }

        public List<Role> Roles { get; set; }
        [Required]
        public User User { get; set; }

        [Required]
        public string OldPass { get; set; }
        [Required]
        public string NewPass { get; set; }

        [Required]
        public int? TypeId { get; set; }
        [Required]
        public List<Onetype> Types { get; set; }

        [Required]
        public List<User> Users { get; set; }
        [Required]
        public List<Explanation> Explanations { get; set; }
        [Required]
        public List<EstimationsMark> EstimationsMarks1 { get; set; }
        [Required]
        public List<EstimationsMark> EstimationsMarks2 { get; set; }
        [Required]
        public List<EstimationsMark> EstimationsMarks3 { get; set; }
        [Required]
        public List<EstimationsMark> EstimationsMarks4 { get; set; }
        [Required]
        public List<EstimationsMark> EstimationsMarks5 { get; set; }
        [Required]
        public List<EstimationsMark> EstimationsMarks6 { get; set; }
        [Required]
        public List<EstimationsMark> EstimationsMarks7 { get; set; }
        [Required]
        public List<EstimationsMark> EstimationsMarks8 { get; set; }
        [Required]
        public List<EstimationsMark> EstimationsMarks9 { get; set; }
        [Required]
        public List<EstimationsMark> EstimationsMarks10 { get; set; }
        [Required]
        public List<EstimationsMark> EstimationsMarks11 { get; set; }
        [Required]
        public List<EstimationsMark> EstimationsMarks12 { get; set; }

        [Required]
        public List<Poll> Polls { get; set; }
    }
}