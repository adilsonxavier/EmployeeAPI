using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.Models
{

    public class Foto
    {
        [Key]
        public int FotoId { get; set; }

        [Column (TypeName ="nvarchar(100)") ]
        public string Description { get; set; }

        [Column(TypeName = "int")]
  
        public int Position { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }

        [NotMapped]  // Indica que o campo não tem correspondente no BD
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public string ImageSrc { get; set; }



        //Chave estrangeira para Employee
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        ///==> Importante : Os dados vem do React em camel case e são convertidos automaticamente para Pascal Case pelo .net core
        /// Ex. vem imageSrc do React e é convertido para ImageSrc
        
    }

}
