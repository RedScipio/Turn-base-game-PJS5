#pragma once
#include <string>

namespace ROBOT
{
	class IPARTS
	{
	public:
		IPARTS(const int iId, const std::string& sName, const int iArmor, const int iLifePoint);
		virtual ~IPARTS() {} ;

		bool IsBroken() { return _iLifePoint < 1; }

		int GetLife() { return _iLifePoint; }
		int GetArmor() { return _iArmor; }
		int GetMaxLife() { return _iMaxLifePoint; }
		int GetMaxArmor() { return _iMaxArmor; }

		int TakeDamage(const int iDamage);
		void RepairArmor(const int iRepair);
		void RepairLife(const int iRepair);

	protected:
		const int _iId;
		const std::string _sName;
		int _iArmor = -1;
		int _iLifePoint = -1;

		const int _iMaxArmor;
		const int _iMaxLifePoint;
	};
}