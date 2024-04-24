using Consumable;

namespace Umshini_Test
{
    public class TestConsumable
    {
        [Fact]
        public void RepairKitTest()
        {
            ICONSUMABLES rk = new RepairKit(3, REPAIR.LIGHT_ARMOR);
            rk.GetValue().Should().Be(1);
            rk.GetName().Should().Be("Light armor kit");

            rk = new RepairKit(3, REPAIR.HEAVY_ARMOR);
            rk.GetValue().Should().Be(2);
            rk.GetName().Should().Be("Heavy armor kit");

            rk = new RepairKit(3, REPAIR.LIGHT_KIT);
            rk.GetValue().Should().Be(3);
            rk.GetName().Should().Be("Light repair kit");

            rk = new RepairKit(3, REPAIR.FULL_KIT);
            rk.GetValue().Should().Be(4);
            rk.GetName().Should().Be("Full repair kit");
        }

        [Fact]
        public void RefuelKitTest()
        {
            ICONSUMABLES RefuelKit = new RefuelKit(3,ENERGY.ENERGY_WOOD);
            RefuelKit.GetValue().Should().Be(15);
            RefuelKit.GetName().Should().Be("Wood");

            RefuelKit = new RefuelKit(3,ENERGY.ENERGY_CHARCOAL);
            RefuelKit.GetValue().Should().Be(20);
            RefuelKit.GetName().Should().Be("Charcoal");

            RefuelKit = new RefuelKit(3, ENERGY.ENERGY_COAL);
            RefuelKit.GetValue().Should().Be(25);
            RefuelKit.GetName().Should().Be("Coal");

            RefuelKit = new RefuelKit(3, ENERGY.ENERGY_COMPACT_COAL);
            RefuelKit.GetValue().Should().Be(35);
            RefuelKit.GetName().Should().Be("Compact coal");
        }

        [Fact]
        public void ICONSUMABLESExceptions()
        {
            Action aRepairKit = () => new RepairKit(0);
            aRepairKit.Should().Throw<ArgumentNullException>();
        }
    }
}
