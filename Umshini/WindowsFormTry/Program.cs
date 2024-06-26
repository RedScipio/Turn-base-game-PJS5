using Battle;
using UGUI;
using Consumable;
using Part;
using Pilot;
using Robot;
using Weapon;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormTry
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            new UGUI.StartingForm(null).Show();
            Application.Run();
        }
    }
}
