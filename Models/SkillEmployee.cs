using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.Models
{

    public class SkillEmployee
    {

        //Chave estrangeira para Employee
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        //Chave estrangeira para Employee
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [NotMapped]
        public string SkillName { get; set; }


    }

}
