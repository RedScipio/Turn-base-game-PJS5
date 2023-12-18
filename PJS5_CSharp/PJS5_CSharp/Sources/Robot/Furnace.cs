namespace PJS5_CSharp.Sources.Robot
{
        public class FURNACE : IPARTS
        {   
            private readonly int _iRestartLimit = -1;

            public FURNACE(int iId, string sName, int iArmor, int iLifePoint, int iRestartLimit)
                : base(iId, sName, iArmor, iLifePoint)
            {
                _iRestartLimit = iRestartLimit;
            }

            public int GetRestartLimit()
            {
                return _iRestartLimit;
            }
        }
    }

