using UnityEngine;


public static class Triggers
{

    static LayerMask Ground;
    static GameObject m_groundCheck;
    static GameObject m_attackGameObject;
    public static bool isGround;


    public static void Init()
    {
        Ground = LayerMask.GetMask("Ground");
        m_groundCheck = GameObject.Find("GroundCheck");
        m_attackGameObject = GameObject.Find("AttackBox");
        //m_shootBullet = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefab/Shoot.prefab", typeof(GameObject));
        m_attackGameObject.SetActive(false);

    }

    public static void Update()
    {
        isGround = IsGround();
    }

    public static bool IsGround()
    {
        bool isGround = Physics2D.OverlapCircle(m_groundCheck.transform.position, 0.2f, Ground);
        if (isGround)
        {
            BehaviourStateBase.jumpCount = 0;
            BehaviourStateBase.canDash = true;
        }
        return isGround;
    }


    public static GameObject GetAttackBox()
    {
        return m_attackGameObject;
    }


    public static void AttackEnable()
    {
        m_attackGameObject.SetActive(true);
    }

    public static void AttackDisable()
    {
        m_attackGameObject.SetActive(false);
    }

}

