using System.Collections;
using UnityEngine;

public class CDNode : Behavior{
    private float cd;
    private bool isCoolingDown;

    public CDNode(float cd){
        this.cd = cd;
        this.isCoolingDown = false;
    }

    protected override void OnInitialize(){
    }

    protected override EStatus OnUpdate(){
        if (isCoolingDown)
            return EStatus.Failure;
        MStartCoroutine();
        return EStatus.Success;
    }

    protected override void OnTerminate(){
    }

    private void MStartCoroutine(){
        GameObject MonoStubTemp = GameObject.Find("MonoStub");
        if (MonoStubTemp == null){
            MonoStubTemp = new GameObject();
            MonoStubTemp.name = "MonoStub";
            MonoStubTemp.AddComponent<MONOStub>();
        }

        MonoStubTemp.GetComponent<MONOStub>().StartCoroutine(CoolDown(cd));
        //Debug.Log("开始计时器协程");
    }

    IEnumerator CoolDown(float cd){
        isCoolingDown = true;
        yield return new WaitForSeconds(cd);
        isCoolingDown = false;
    }
}

public partial class BehaviorTreeBuilder{
    public BehaviorTreeBuilder CDNode(float cd){
        var node = new CDNode(cd);
        AddBehavior(node);
        return this;
    }
}