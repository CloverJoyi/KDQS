using UnityEngine;

public class ExploreAreaUtil
{

    // 观察距离的偏移量——x轴
    private static float watchOffsetX = 7.6f;
    // 观察距离的偏移量——y轴
    private static float watchOffsetY = 2f;
    // 观察距离的区域大小
    private static Vector2 watchDistance = new Vector2(5f, 4f);
    // 攻击距离的偏移量——x轴
    private static float attackOffsetX = 3f;
    // 攻击距离的偏移量——y轴
    private static float attackOffsetY = 2f;
    // 攻击距离的区域大小
    private static Vector2 attackDistance = new Vector2(4f, 4f);
    // 当前物体的位置
    private static Vector2 enemyPosition;


    // 观察检测
    public static Collider2D WatchBox(Rigidbody2D rb)
    {
        // 关于检测转向 当物体的x轴 > 0 代表右边 偏移量设置正值
        watchOffsetX = rb.transform.localScale.x > 0 ? Mathf.Abs(watchOffsetX) : -Mathf.Abs(watchOffsetX);
        // enemy位置
        enemyPosition = rb.transform.position;
        // 检测盒子偏移量设置
        enemyPosition.x += watchOffsetX;
        enemyPosition.y += watchOffsetY;
        // 检测在指定区域内是否存在其他碰撞体
        return Physics2D.OverlapBox(enemyPosition, watchDistance, 0, LayerMask.GetMask("Player"));
    }


    // 攻击检测
    public static Collider2D AttackBox(Rigidbody2D rb)
    {
        // 关于检测转向 当物体的x轴 > 0 代表右边 偏移量设置正值
        attackOffsetX = rb.transform.localScale.x > 0 ? Mathf.Abs(attackOffsetX) : -Mathf.Abs(attackOffsetX);
        // enemy位置
        enemyPosition = rb.transform.position;
        // 检测盒子偏移量设置
        enemyPosition.x += attackOffsetX;
        enemyPosition.y += attackOffsetY;
        // 检测在指定区域内是否存在其他碰撞体
        return Physics2D.OverlapBox(enemyPosition, attackDistance, 0, LayerMask.GetMask("Player"));
    }

    public static void DrawWatchBox(Rigidbody2D enemy)
    {
        // 设置颜色
        Gizmos.color = Color.yellow;
        // 设置中心位置 偏移量
        enemyPosition = enemy.transform.position;
        enemyPosition.x += watchOffsetX;
        enemyPosition.y += watchOffsetY;
        // 绘制线框立方体
        Gizmos.DrawWireCube(enemyPosition, watchDistance);
    }

    public static void DrawAttackBox(Rigidbody2D enemy)
    {
        // 设置颜色
        Gizmos.color = Color.red;
        // 设置中心位置 偏移量
        enemyPosition = enemy.transform.position;
        enemyPosition.x += attackOffsetX;
        enemyPosition.y += attackOffsetY;
        // 绘制线框立方体
        Gizmos.DrawWireCube(enemyPosition, attackDistance);
    }



}
