#pragma once
#include "IParts.h"
#include <string>

namespace ROBOT
{
	class LEGS : public IPARTS
	{
	public:
		LEGS(const int iId, const std::string& sName, const int iArmor, const int iLegs);
		~LEGS();
	};
}