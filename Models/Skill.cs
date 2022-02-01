using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.Models
{

    public class Skill
    {
        public Skill()
        {
            SkillEmployees = new HashSet<SkillEmployee>();
        }
        [Key]
        public int SkillId { get; set; }

        [Column (TypeName ="nvarchar(100)") ]
        public string SkillName { get; set; }
        public ICollection<SkillEmployee> SkillEmployees { get; set; }

        [NotMapped]

        public bool Checked { get; set; }


    }

}
