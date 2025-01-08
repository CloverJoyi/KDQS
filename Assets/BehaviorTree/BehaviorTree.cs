//实现树

public class BehaviorTree
{
    public bool HaveRoot => root != null;
    private Behavior root;//根节点
    public BehaviorTree(Behavior root)
    {
        this.root = root;
    }
    public void Tick()
    {
        root.Tick();
    }
    public void SetRoot(Behavior root)
    {
        this.root = root;
    }
}