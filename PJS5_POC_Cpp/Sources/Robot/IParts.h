#pragma once
#include <string>

namespace ROBOT
{
	class IPARTS
	{
	public:
		IPARTS(const int iId, const std::string& sName, const int iArmor, const int iLifePoint);
		virtual ~IPARTS() {} ;

	protected:
		const int _iId;
		const std::string _sName;
		int _iArmor = -1;
		int _iLifePoint = -1;

		const int _iMaxArmor;
		const int _iMaxLifePoint;
	};
}