using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateTest : AIStateBase
{
    public class AIStateID
    {
        public const int idle = 1;
        public const int track = 1 << 1;
        public const int attack = 1 << 2;
        public const int skill = 1 << 3;
        public const int died = 1 << 4;

    }

    public int state;
    public bool onGround;
    public bool isDie;
    public void Reset()
    {
        state = AIStateID.idle;
        isDie = false;
    }
}
