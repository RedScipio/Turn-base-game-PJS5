#include "Utils.h"
#include <iostream>
#include <conio.h>

namespace UTILS
{
    int GetInt()
    {
        int iInt;
        iInt = _getch() - '0';
        std::cout << iInt;
        return iInt;
    }
}