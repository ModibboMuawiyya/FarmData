using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    class Class1
    {
            static void Main(string[] args)
            {

                using (var ctx = new FarmContext())
                {
                    Profile frmr = new Profile() { FarmerId = 1 };

                    ctx.Profiles.Add(frmr);
                    ctx.SaveChanges();
                }
            }
        
    }
}
