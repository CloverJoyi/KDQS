using UnityEngine;
using UnityEngine.InputSystem;

public class InputDevice
{
    public static Keyboard keyboard;
    public static Mouse mouse;
    public static Gamepad pad;

    static InputDevice()
    {
        keyboard = Keyboard.current;
        mouse = Mouse.current;
        pad = Gamepad.current;
    }

    //工具方法,用于获取玩家输入
    public static Vector2 GetPlayerMovement()
    {
        Vector2 move = Vector2.zero;
        float w = keyboard.wKey.ReadValue();
        float s = -keyboard.sKey.ReadValue();
        float a = -keyboard.aKey.ReadValue();
        float d = keyboard.dKey.ReadValue();

        float horizontal = a + d;
        float vertical = w + s;
        move.x = horizontal;
        move.y = vertical;
        return move;
    }
}
