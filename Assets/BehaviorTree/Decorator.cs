//修饰器基类
public abstract class Decorator : Behavior
{
    protected Behavior child;
    public override void AddChild(Behavior child)
    {
        this.child = child;
    }
}