﻿using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumable
{
    public class RepairKit : ACONSUMABLE
    {
        public RepairKit(int iNumberItems, REPAIR? eRepair = null) : base(iNumberItems, eRepair, null) { }

        public RepairKit(RepairKit repairKit) : base(repairKit) { }

        public override ICONSUMABLES Clone()
        {
            return new RepairKit(this);
        }
    }
}
