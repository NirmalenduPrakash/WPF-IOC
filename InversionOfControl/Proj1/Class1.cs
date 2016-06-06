using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proj3;
namespace Proj1
{
    public class Class1
    {
        IClass3 class3;
        public Class1(IClass3 class3) { this.class3 = class3; }
        public void Class1Method1() { class3.Class3Method3(); }
    }

    public class Class2
    {
        IClass3 class3;
        public Class2(IClass3 class3) { this.class3 = class3; }
        public void Class2Method2() { class3.Class3Method3(); }
    }
}
