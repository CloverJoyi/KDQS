using UnityEngine;

interface IAgent
{

}

public class Agent : MonoBehaviour, IAgent
{
    public GameObject bullet;
    public Transform entity;
    public T GetEnitityComponment<T>()
    {
        return entity.GetComponent<T>();
    }

    public static GameObject CreateShootBullet(GameObject bullet, Vector2 position)
    {
        GameObject shootBullet = Instantiate(bullet, position, Quaternion.identity);
        return shootBullet;
    }

    public static void DestroyObject(GameObject m_object, float time)
    {
        Destroy(m_object, time);
    }

}
