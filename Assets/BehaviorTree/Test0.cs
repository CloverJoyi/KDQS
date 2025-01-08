using System;
using UnityEngine;

public class Test0 : MonoBehaviour{
    public Transform Pos1;
    public Transform Pos2;

    private Rigidbody rb;
    BehaviorTreeBuilder builder;

    private void Awake(){
        builder = new BehaviorTreeBuilder();
        rb = GetComponent<Rigidbody>();
    }

    private void Start(){
        // builder.Repeat(3)
        //     .Sequence()
        //     .DebugNode("Ok,") //由于动作节点不进栈，所以不用Back
        //     .DebugNode("It's ")
        //     .DebugNode("My time")
        //     .Back()
        //     .End();
        // builder.TreeTick();
        builder.Sequence()
            .Move(rb, Pos1, Pos2)
            .End();
    }

    private void Update(){
        builder.TreeTick();
    }
}