#include "IParts.h"

namespace ROBOT
{
	IPARTS::IPARTS(const int iId, const std::string& sName, const int iArmor, const int iLifePoint) :
		_iId(iId),
		_sName(sName),
		_iArmor(iArmor),
		_iLifePoint(iLifePoint),
		_iMaxArmor(iArmor),
		_iMaxLifePoint(iLifePoint)
	{
	}

	int IPARTS::TakeDamage(const int iDamage)
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

		return iResult;
	}

	void IPARTS::RepairArmor(const int iRepair)
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

	void IPARTS::RepairLife(const int iRepair)
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