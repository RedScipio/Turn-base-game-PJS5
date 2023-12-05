using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJS5_CSharp.Sources.Robot
{
        public class IPARTS
        {
            private readonly int _iId;
            private readonly string _sName;
            private int _iArmor = -1;
            private int _iLifePoint = -1;
            private readonly int _iMaxArmor;
            private readonly int _iMaxLifePoint;

            public IPARTS(int iId, string sName, int iArmor, int iLifePoint)
            {
                _iId = iId;
                _sName = sName;
                _iArmor = iArmor;
                _iLifePoint = iLifePoint;
                _iMaxArmor = iArmor;
                _iMaxLifePoint = iLifePoint;
            }

            public bool IsBroken()
            {
                return _iLifePoint < 1;
            }

            public int GetLife()
            {
                return _iLifePoint;
            }

            public int GetArmor()
            {
                return _iArmor;
            }

            public int GetMaxLife()
            {
                return _iMaxLifePoint;
            }

            public int GetMaxArmor()
            {
                return _iMaxArmor;
            }

            public int TakeDamage(int iDamage)
            {
                
                int iResult = 0;
                int iRemainingDamage = iDamage;
                if (_iArmor > 0)
                {
                    iRemainingDamage = iDamage - _iArmor;
                    iResult = _iArmor - iDamage;
                    _iArmor = _iArmor - iDamage;
                }
                if (_iLifePoint > 0 && iRemainingDamage > 0)
                {
                    _iLifePoint--;
                    iResult = iResult + 100;
                    if (_iLifePoint > 0)
                    {
                        _iArmor = _iMaxArmor;
                    }
                }
            Console.WriteLine("Delt damage to " + _iId +", " + _sName);
                return iResult;
            }

            public void RepairArmor(int iRepair)
            {
                if (_iArmor < _iMaxArmor)
                {
                    _iArmor = _iArmor + iRepair;
                    if (_iArmor > _iMaxArmor)
                    {
                        _iArmor = _iMaxArmor;
                    }
                }
            }

            public void RepairLife(int iRepair)
            {
                if (_iLifePoint < _iMaxLifePoint)
                {
                    _iLifePoint = _iLifePoint + iRepair;
                    if (_iLifePoint > _iMaxLifePoint)
                    {
                        _iLifePoint = _iMaxLifePoint;
                    }
                }
            }
        }
    }



