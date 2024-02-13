
namespace Robot
{
    public interface IWEAPON : IPART
    {
        int GetSpecificity();
        int GetAccuracy();
        int GetMinAccuracy();
    }
}
