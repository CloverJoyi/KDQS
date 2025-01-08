using System.Collections.Generic;

//构建树
public partial class BehaviorTreeBuilder
{
    private readonly Stack<Behavior> nodeStack;//构建树结构用的栈
    private readonly BehaviorTree bhTree;//构建的树
    public BehaviorTreeBuilder()
    {
        bhTree = new BehaviorTree(null);//构造一个没有根的树
        nodeStack = new Stack<Behavior>();//初始化构建栈
    }
    private void AddBehavior(Behavior behavior)
    {
        if (bhTree.HaveRoot)//有根节点时，加入构建栈
        {
            nodeStack.Peek().AddChild(behavior);
        }
        else //当树没根时，新增得节点视为根节点
        {
            bhTree.SetRoot(behavior);
        }
        //只有组合节点和修饰节点需要进构建栈
        if (behavior is Composite || behavior is Decorator)
        {
            nodeStack.Push(behavior);
        }
    }
    public void TreeTick()
    {
        bhTree.Tick();
    }
    public BehaviorTreeBuilder Back()
    {
        nodeStack.Pop();
        return this;
    }
    public BehaviorTree End()
    {
        nodeStack.Clear();
        return bhTree;
    }
    
    //---------包装各节点---------
    public BehaviorTreeBuilder Sequence()
    {
        var tp = new Sequence();
        AddBehavior(tp);
        return this;
    }
    public BehaviorTreeBuilder Seletctor()
    {
        var tp = new Selector();
        AddBehavior(tp);
        return this;
    }
    public BehaviorTreeBuilder Filter()
    {
        var tp = new Filter();
        AddBehavior(tp);
        return this;
    }
    public BehaviorTreeBuilder Parallel(Parallel.Policy success, Parallel.Policy failure)
    {
        var tp = new Parallel(success, failure);
        AddBehavior(tp);
        return this;
    }
    public BehaviorTreeBuilder Monitor(Parallel.Policy success, Parallel.Policy failure)
    {
        var tp = new Monitor(success, failure);
        AddBehavior(tp);
        return this;
    }
    public BehaviorTreeBuilder ActiveSelector()
    {
        var tp = new ActiveSelector();
        AddBehavior(tp);
        return this;
    }
    public BehaviorTreeBuilder Repeat(int limit)
    {
        var tp = new Repeat(limit);
        AddBehavior(tp);
        return this;
    }
    public BehaviorTreeBuilder Inverter()
    {
        var tp = new Inverter();
        AddBehavior(tp);
        return this;
    }
}