using System;
public class ActivatorUtil
{
    public static T CreateInstance<T>(Type type)
    {
        //反射
        T instance = (T)Activator.CreateInstance(type ?? throw new InvalidCastException());
        return instance;
    }


    public static T CreateInstance<T>(Type type, params object[] args)
    {
        T instance = (T)Activator.CreateInstance(type ?? throw new InvalidCastException(), args);
        return instance;
    }

    public static Type GetFrameWoekType(string className)
    {
        return Type.GetType(className);
    }
}
