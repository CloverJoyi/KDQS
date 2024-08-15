

public class InputDeviceTest : InputDevice
{
    public static bool GetJump()
    {
        bool jump = keyboard.spaceKey.wasPressedThisFrame;
        return jump;
    }

    public static bool GetAttack()
    {
        bool attack = mouse.leftButton.wasPressedThisFrame;
        return attack;
    }

    public static bool GetSprint()
    {
        bool sprint = keyboard.shiftKey.wasPressedThisFrame;
        return sprint;
    }

    public static bool GetDown()
    {
        bool down = keyboard.cKey.wasPressedThisFrame;
        return down;
    }
    public static bool GetShoot()
    {
        bool shoot = keyboard.eKey.wasPressedThisFrame;
        return shoot;
    }
}
