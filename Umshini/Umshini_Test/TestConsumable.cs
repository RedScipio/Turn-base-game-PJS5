namespace Umshini_Test
{
    public class TestConsumable
    {
        [Fact]
        public void RepairKitTest()
        {
            ICONSUMABLE RepairKit = new RepairKit(REPAIR.LIGHT_ARMOR);
            RepairKit.GetValue().Should().Be(1);
            RepairKit.GetName().Should().Be("Light armor kit");

            RepairKit = new RepairKit(REPAIR.HEAVY_ARMOR);
            RepairKit.GetValue().Should().Be(3);
            RepairKit.GetName().Should().Be("Heavy armor kit");

            RepairKit = new RepairKit(REPAIR.LIGHT_KIT);
            RepairKit.GetValue().Should().Be(2);
            RepairKit.GetName().Should().Be("Light repair kit");

            RepairKit = new RepairKit(REPAIR.FULL_KIT);
            RepairKit.GetValue().Should().Be(4);
            RepairKit.GetName().Should().Be("Full repair kit");
        }

        [Fact]
        public void RefuelKitTest()
        {
            ICONSUMABLE RefuelKit = new RefuelKit(ENERGY.ENERGY_WOOD);
            RefuelKit.GetValue().Should().Be(15);
            RefuelKit.GetName().Should().Be("Wood");

            RefuelKit = new RefuelKit(ENERGY.ENERGY_CHARCOAL);
            RefuelKit.GetValue().Should().Be(20);
            RefuelKit.GetName().Should().Be("Charcoal");

            RefuelKit = new RefuelKit(ENERGY.ENERGY_COAL);
            RefuelKit.GetValue().Should().Be(25);
            RefuelKit.GetName().Should().Be("Coal");

            RefuelKit = new RefuelKit(ENERGY.ENERGY_COMPACT_COAL);
            RefuelKit.GetValue().Should().Be(35);
            RefuelKit.GetName().Should().Be("Compact coal");
        }

        [Fact]
        public void IConsumableExceptions()
        {
            Action aRepairKit = () => new RepairKit();
            aRepairKit.Should().Throw<ArgumentNullException>();
            //Assert.Throws()
        }
    }
}
