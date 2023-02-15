using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCrud
{
    class Student 
    {
        [Key]
        public int id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }
        public string Phoneno { get; set; }

        public string age { get; set; }

        public DateTime DOB { get; set; }

        //public string studentaddress { get; set; }



    }
}
