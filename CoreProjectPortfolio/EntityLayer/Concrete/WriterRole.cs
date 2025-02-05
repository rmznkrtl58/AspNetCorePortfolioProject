using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WriterRole:IdentityRole<int>
        //bu sınıfımı tanımlama sebebim
        //Context üzerinde IdentityDbContext tarafında kullanmam gerekecek
        //çünkü benden bir rol isteyecek
    {
    }
}
