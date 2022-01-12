using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTestConsole
{
    class A : B
    {
        InnerClass InnerClas = new();
        class InnerClass : C
        {
            protected void MethodInner()
            {
                
            }
        }
    }
}
