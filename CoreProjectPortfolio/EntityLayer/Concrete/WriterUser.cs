using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WriterUser:IdentityUser<int>//key olarak int tanımlıyorum
        //Identity ile birlikte gelen tablolarımdan AspNetUsers tablomda olup
        //hem buradaki proplar hemde aspnetusersdaki proplar birlikte kullanılabilir.
        //benim istediğim Adın,soyadın ve ımage url bilgileri olmadığı için 
        //bu sınıfımıda tanımlıyorum
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
    }
}
