using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJS5_CSharp.Sources.Robot
{
        public class LEGS : IPARTS
        {
            public LEGS(int iId, string sName, int iArmor, int iLegs) : base(iId, sName, iArmor, iLegs)
            {
            }

            ~LEGS()
            {
            }
        }
    }

