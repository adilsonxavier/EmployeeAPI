using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.Models
{
    public class Employee
    {
        public Employee()
        {
            SkillEmployees = new HashSet<SkillEmployee>(); 
        }
        [Key]
        public int EmployeeId { get; set; }

        [Column (TypeName ="nvarchar(50)") ]
        public string EmployeeName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Occupation { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }
        public ICollection<SkillEmployee> SkillEmployees { get; set; }
 

        [NotMapped]  // Indica que o campo não tem correspondente no BD
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }

        ///==> Importante : Os dados vem do React em camel case e são convertidos automaticamente para Pascal Case pelo .net core
        /// Ex. vem imageSrc do React e é convertido para ImageSrc
        
    }

}
