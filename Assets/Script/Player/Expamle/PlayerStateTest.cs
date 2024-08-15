

public class PlayerStateTest : PlayerStateBase
{
    public class PlayerStateID
    {
        public const int idle = 1;
        public const int move = 1 << 1;
        public const int jump = 1 << 2;
        public const int attack = 1 << 3;
        public const int down = 1 << 4;
        public const int shoot = 1 << 5;
        public const int doubleJump = 1 << 6;
        public const int fall = 1 << 7;
        public const int land = 1 << 8;
        public const int hurted = 1 << 9;
        public const int died = 1 << 10;
    }


    enum PlayerStateEnum
    {
        idle = 1,
        move = 1 << 1,
        jump = 1 << 2,
        attack = 1 << 3,
    }


    public int state;
    public bool onGround;
    public bool isDie;
    public void Reset()
    {
        state = PlayerStateID.idle;
        isDie = false;
        //onGround =Triggers.IsGround;
    }


}
