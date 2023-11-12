#include "Gui.h"
#include "../Utils.h"
#include "../Pilot/IPilot.h"
#include "../Robot/Robot.h"
#include <iostream>
#include <vector>

namespace GUI
{
	void ShowStatus(ROBOT::ROBOT* pPlayer, ROBOT::ROBOT* pBot)
	{
		std::cout << "|====================--====================|\n";
		std::cout << "|                  Robots                  |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "|>-     Player     -<||>-     Ennemi     -<|\n";
		std::cout << "|===================-<>-===================|\n";
		
		std::cout << "| Furnace armor: " 
			<< pPlayer->GetFurnaceArmor() << "/" << pPlayer->GetFurnaceMaxArmor()
			<< " || Furnace armor: "
			<< pBot->GetFurnaceArmor() << "/" << pBot->GetFurnaceMaxArmor()
			<< " |\n";

		std::cout << "| Furnace life: " 
			<< pPlayer->GetFurnaceLife() << "/" << pPlayer->GetFurnaceMaxLife() 
			<<"  || Furnace life: "
			<< pBot->GetFurnaceLife() << "/" << pBot->GetFurnaceMaxLife()
			<<"  |\n";

		std::cout << "|>- - - - - - - - - -<>- - - - - - - - - -<|\n";

		std::cout << "| Legs armor: "
			<< pPlayer->GetLegsArmor() << "/" << pPlayer->GetLegsMaxArmor()
			<< "    || Legs armor: "
			<< pBot->GetLegsArmor() << "/" << pBot->GetLegsMaxArmor()
			<< "    |\n";

		std::cout << "| Legs remains: "
			<< pPlayer->GetLegsLife() << "/" << pPlayer->GetLegsMaxLife()
			<< "  || Legs remains: "
			<< pBot->GetLegsLife() << "/" << pBot->GetLegsMaxLife()
			<< "  |\n";

		std::cout << "|>- - - - - - - - - -<>- - - - - - - - - -<|\n";
		
		std::cout << "| WeaponL armor: "
			<< pPlayer->GetLeftWeaponArmor() << "/" << pPlayer->GetLeftWeaponMaxArmor()
			<< " || WeaponL armor: "
			<< pBot->GetLeftWeaponArmor() << "/" << pBot->GetLeftWeaponMaxArmor()
			<< " |\n";

		std::cout << "| WeaponL life: "
			<< pPlayer->GetLeftWeaponLife() << "/" << pPlayer->GetLeftWeaponMaxLife()
			<< "  || WeaponL life: "
			<< pBot->GetLeftWeaponLife() << "/" << pBot->GetLeftWeaponMaxLife()
			<< "  |\n";

		std::cout << "|>- - - - - - - - - -<>- - - - - - - - - -<|\n";

		std::cout << "| WeaponR armor: "
			<< pPlayer->GetRightWeaponArmor() << "/" << pPlayer->GetRightWeaponMaxArmor()
			<< " || WeaponR armor: "
			<< pBot->GetRightWeaponArmor() << "/" << pBot->GetRightWeaponMaxArmor()
			<< " |\n";

		std::cout << "| WeaponR life: "
			<< pPlayer->GetRightWeaponLife() << "/" << pPlayer->GetRightWeaponMaxLife()
			<< "  || WeaponR life: "
			<< pBot->GetRightWeaponLife() << "/" << pBot->GetRightWeaponMaxLife()
			<< "  |\n";

		std::cout << "|===================-<>-===================|\n";

		const int iPlayerFuel = pPlayer->GetFuel();
		std::cout << "|    Fuel: " << iPlayerFuel << "/100";
		if (iPlayerFuel < 100)
		{
			std::cout << " ";
		}
		
		const int iBotFuel = pBot->GetFuel();
		std::cout << "   ||    Fuel: " << iBotFuel << "/100";
		if (iBotFuel < 100)
		{
			std::cout << " ";
		}
		std::cout <<"   |\n";

		std::cout << "|====================--====================|\n";
	}

	int MainMenu()
	{
		int iResult;
		std::cout << "|====================--====================|\n";
		std::cout << "|                Main  Menu                |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "|  1-Attack  ||  2-Repairs  ||  3-Furnace  |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "| Tap the number of the desired action : ";
		iResult = UTILS::GetInt();
		std::cout << " |\n";
		std::cout << "|====================--====================|\n";

		return iResult;
	}

	int TargetMenu()
	{
		int iResult;

		std::cout << "|====================--====================|\n";
		std::cout << "|              Target  Menu                |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "|    1-Left Weapon   ||   2-Right Weapon   |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "|       3-Legs       ||     4-Furnace      |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "|                    ||       0-Back       |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "| Select the target part : ";
		iResult = UTILS::GetInt();
		std::cout << "               |\n";
		std::cout << "|====================--====================|\n";

		return iResult;
	}

	int RepairMenu(PILOT::IPILOT* pPilot) 
	{
		int iResult;

		std::cout << "|====================--====================|\n";
		std::cout << "|                Kits  Menu                |\n";
		std::cout << "|===================-<>-===================|\n";
		
		const std::vector<int> vRepairKitsReserve = pPilot->GetRepairKitsReserve();

		const int iLightArmor = vRepairKitsReserve.at(0);
		std::cout << "| 1-Light armor: x" << iLightArmor;
		if (iLightArmor < 10)
		{
			std::cout << " ";
		}

		const int iHeavyKits = vRepairKitsReserve.at(1);
		std::cout << " || 2-Heavy armor: x" << iHeavyKits;
		if (iHeavyKits < 10)
		{
			std::cout << " ";
		}
		std::cout << " |\n";

		std::cout << "|      Armor: 1      ||      Armor: 3      |\n";
		std::cout << "|===================-<>-===================|\n";

		const int iRepairKits = vRepairKitsReserve.at(2);
		std::cout << "| 3-Repair kits: x" << iRepairKits;
		if (iRepairKits < 10)
		{
			std::cout << " ";
		}

		const int iFullKits = vRepairKitsReserve.at(3);
		std::cout << " ||  4-Full kits: x" << iFullKits;
		if (iFullKits < 10)
		{
			std::cout << " ";
		}
		std::cout << "  |\n";

		std::cout << "|   Life Points: 1   ||   Life Points: 3   |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "|                    ||       0-Back       |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "| Select your kit type : ";
		iResult = UTILS::GetInt();
		std::cout << "                 |\n";
		std::cout << "|====================--====================|\n";

		return iResult;
	}

	int FuelMenu(PILOT::IPILOT* pPilot)
	{
		int iResult;

		std::cout << "|====================--====================|\n";
		std::cout << "|                Fuel  Menu                |\n";
		std::cout << "|===================-<>-===================|\n";

		const std::vector<int> vFuelsReserve = pPilot->GetFuelsReserve();

		const int iWood = vFuelsReserve.at(0);
		std::cout << "|     1-Wood: x" << iWood;
		if (iWood < 10)
		{
			std::cout << " ";
		}

		const int iCharcoal = vFuelsReserve.at(1);
		std::cout << "    ||   2-Charcoal: x" << iCharcoal;
		if (iCharcoal < 10)
		{
			std::cout << " ";
		}
		std::cout << "  |\n";
		
		std::cout << "|     Energy: 15     ||     Energy: 20     |\n";
		std::cout << "|===================-<>-===================|\n";
		
		const int iCoal = vFuelsReserve.at(2);
		std::cout << "|     3-Coal: x" << iCoal;
		if (iCoal < 10)
		{
			std::cout << " ";
		}

		const int iCompactCoal = vFuelsReserve.at(3);
		std::cout << "    || 4-Compact Coal: x" << iCompactCoal;
		if (iCompactCoal < 10)
		{
			std::cout << " ";
		}
		std::cout << "|\n";

		std::cout << "|     Energy: 25     ||     Energy: 35     |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "|                    ||       0-Back       |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "| Select your fuel type : ";
		iResult = UTILS::GetInt();
		std::cout << "                |\n";
		std::cout << "|====================--====================|\n";

		return iResult;
	}

	int WeaponMenu(ROBOT::ROBOT* pPlayer)
	{
		int iResult;

		std::cout << "|====================--====================|\n";
		std::cout << "|              Weapon  Menu                |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "| 1-Left Weapon type: ";
		switch (pPlayer->GetLeftWeaponType())
		{
		case 1:
		{
			std::cout << "Normal               |\n";
			break;
		}
		case 2:
		{
			std::cout << "Melee                |\n";
			break;
		}
		case 3:
		{
			std::cout << "Projectile           |\n";
			const int iAmmo = pPlayer->GetLeftWeaponSpecificity();
			std::cout << "| Remaining ammo: x" << iAmmo;
			if (iAmmo < 10)
			{
				std::cout << " ";
			}
			std::cout << "                      |\n";
			break;
		}
		case 4:
		{
			std::cout << "Thermal              |\n";
			const int iFuel = pPlayer->GetLeftWeaponSpecificity();
			std::cout << "| Burning fuels: x" << iFuel;
			if (iFuel < 10)
			{
				std::cout << " ";
			}
			std::cout << "                     |\n";
			break;
		}
		default :
		{
			std::cout << "Undefined            |\n";
			break;
		}
		}
		std::cout << "|>- - - - - - - - - -<>- - - - - - - - - -<|\n";
		std::cout << "| Damage: " << pPlayer->GetLeftWeaponDamage() << "                                |\n";

		const int iLeftAccuracy = pPlayer->GetLeftWeaponHitChance();
		std::cout << "| Accuracy: " << iLeftAccuracy << "%";
		if (iLeftAccuracy < 100)
		{
			std::cout << " ";
		}
		std::cout << "                           |\n";
		std::cout << "| Fuel Consumption: " << pPlayer->GetLeftWeaponPowerConsumption() << "                     |\n";


		std::cout << "|===================-<>-===================|\n";
		
		std::cout << "| 2-Right Weapon type: ";
		switch (pPlayer->GetRightWeaponType())
		{
		case 1:
		{
			std::cout << "Normal              |\n";
			break;
		}
		case 2:
		{
			std::cout << "Melee               |\n";
			break;
		}
		case 3:
		{
			std::cout << "Projectile          |\n";
			const int iAmmo = pPlayer->GetRightWeaponSpecificity();
			std::cout << "| Remaining ammo: x" << iAmmo;
			if (iAmmo < 10)
			{
				std::cout << " ";
			}
			std::cout << "                      |\n";
			break;
		}
		case 4:
		{
			std::cout << "Thermal             |\n";
			const int iFuel = pPlayer->GetRightWeaponSpecificity();
			std::cout << "| Burning fuels: x" << iFuel;
			if (iFuel < 10)
			{
				std::cout << " ";
			}
			std::cout << "                     |\n";
			break;
		}
		default:
		{
			std::cout << "Undefined           |\n";
			break;
		}
		}
		std::cout << "|>- - - - - - - - - -<>- - - - - - - - - -<|\n";
		std::cout << "| Damage: " << pPlayer->GetRightWeaponDamage() << "                                |\n";

		const int iRightAccuracy = pPlayer->GetRightWeaponHitChance();
		std::cout << "| Accuracy: " << iRightAccuracy << "%";
		if (iRightAccuracy < 100)
		{
			std::cout << " ";
		}
		std::cout << "                           |\n";
		std::cout << "| Fuel Consumption: " << pPlayer->GetRightWeaponPowerConsumption() << "                     |\n";

		std::cout << "|===================-<>-===================|\n";
		std::cout << "|                    ||       0-Back       |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "| Select your weapon : ";
		iResult = UTILS::GetInt();
		std::cout << "                   |\n";
		std::cout << "|====================--====================|\n";

		return iResult;
	}

	void RobotRestart()
	{
		std::cout << "|--------------------==--------------------|\n";
		std::cout << "|      The robot need fuel to restart      |\n";
		std::cout << "|--------------------==--------------------|\n";
	}

	void WeaponIsUnusable()
	{
		std::cout << "|--------------------==--------------------|\n";
		std::cout << "|         This weapon  is unusable         |\n";
		std::cout << "|--------------------==--------------------|\n";
	}

	void AlreadyDestroy()
	{
		std::cout << "|--------------------==--------------------|\n";
		std::cout << "|       This part is already destroy       |\n";
		std::cout << "|--------------------==--------------------|\n";
	}

	void MissedFire()
	{
		std::cout << "|--------------------==--------------------|\n";
		std::cout << "|            It's a missed fire            |\n";
		std::cout << "|--------------------==--------------------|\n";
	}

	void NoStockKit()
	{
		std::cout << "|--------------------==--------------------|\n";
		std::cout << "|    No more kits of this type in stock    |\n";
		std::cout << "|--------------------==--------------------|\n";
	}

	void PerfectlyFine()
	{
		std::cout << "|--------------------==--------------------|\n";
		std::cout << "|              Perfectly Fine              |\n";
		std::cout << "|--------------------==--------------------|\n";
	}

	void NoStockFuel()
	{
		std::cout << "|--------------------==--------------------|\n";
		std::cout << "|    No more fuel of this type in stock    |\n";
		std::cout << "|--------------------==--------------------|\n";
	}

	void WrongEntry()
	{
		std::cout << "!!!-----------------!==!-----------------!!!\n";
		std::cout << "|               Wrong  Entry               |\n";
		std::cout << "!!!-----------------!==!-----------------!!!\n";
	}
}