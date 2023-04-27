using Gaz.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Gaz.Models
{
    public class SidebarModel
    {
        public bool MainAdmin { get; set; }
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

        [Required]
        public List<Score> Scores { get; set; }

        public string Name { get; set; }
        [Required]
        public List<Role> Roles { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }

        [Required]
        public string Fio { get; set; }
        [Required]
        public string ServiceNumber { get; set; }
        [Required]
        public string Division { get; set; }
        [Required]
        public string Position { get; set; }

        [Required]
        public int EditUserId { get; set; }
        [Required]
        public User EditUser { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string OldPass { get; set; }
        [Required]
        public string NewPass { get; set; }

        [Required]
        public int? TypeId { get; set; }
        [Required]
        public Onetype Type { get; set; }
        [Required]
        public List<Onetype> Types { get; set; }

        [Required]
        public List<User> Users { get; set; }
        [Required]
        public List<User> AllUsers { get; set; }
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

        [Required]
        public int MarkId1 { get; set; }
        [Required]
        public int MarkId2 { get; set; }
        [Required]
        public int MarkId3 { get; set; }
        [Required]
        public int MarkId4 { get; set; }
        [Required]
        public int MarkId5 { get; set; }
        [Required]
        public int MarkId6 { get; set; }
        [Required]
        public int MarkId7 { get; set; }
        [Required]
        public int MarkId8 { get; set; }
        [Required]
        public int MarkId9 { get; set; }
        [Required]
        public int MarkId10 { get; set; }
        [Required]
        public int MarkId11 { get; set; }
        [Required]
        public int MarkId12 { get; set; }

        [Required]
        public string Explanation { get; set; }
    }
}