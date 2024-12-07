using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_12_24
{
    public class WeaponException : Exception
    {
        public WeaponException() { }

        public WeaponException(string message) : base(message) { }

    }

}
