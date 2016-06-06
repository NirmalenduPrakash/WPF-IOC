using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proj3;

namespace Proj2
{
    public class Class3
    {
        IClass1 class1;
        IClass2 class2;
        public Class3(IClass1 class1, IClass2 class2) { this.class1 = class1; this.class2 = class2; }
        public void Class1Method1() 
        { 
            class1.Class1Method1();
            class2.Class2Method2();
        }
    }
}
