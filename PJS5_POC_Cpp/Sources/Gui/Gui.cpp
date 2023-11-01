#include "Gui.h"
#include "..\Utils.h"
#include <iostream>

namespace GUI
{
	void ShowStatus(ROBOT::ROBOT* pPlayer, ROBOT::ROBOT* pBot)
	{
		std::cout << "|====================--====================|";
		std::cout << "|         Statistiques des robots          |";
		std::cout << "|===================-<>-===================|";
		std::cout << "|>-     Player     -<||>-     Ennemi     -<|";
		std::cout << "|===================-<>-===================|";
		std::cout << "";
		std::cout << "";
		std::cout << "";
		std::cout << "";
		std::cout << "";
		}

	int MainMenu()
	{
		int iResult;
		std::cout << "|====================--====================|\n";
		std::cout << "|                Main  Menu                |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "|  1-Attack  ||  2-Repairs  ||  3-Furnace  |\n";
		std::cout << "|===================-<>-===================|\n";
		std::cout << "|Tap the number of the desired action: ";
		iResult = UTILS::GetInt();
		std::cout << "   |\n";
		std::cout << "|====================--====================|\n";

		return iResult;
	}
}