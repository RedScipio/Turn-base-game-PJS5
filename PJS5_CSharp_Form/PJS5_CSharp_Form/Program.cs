using PJS5_CSharp.Sources.Battle;
using PJS5_CSharp.Sources.Pilot.Bot;
using PJS5_CSharp.Sources.Pilot.Player;
using PJS5_CSharp.Sources.Robot;
using PJS5_CSharp.Sources.Weapon.MeleeWeapon;
using PJS5_CSharp.Sources.Weapon.NormalWeapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJS5_CSharp_Form
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CombatForm());

        }
    }
}
