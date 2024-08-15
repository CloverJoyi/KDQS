using UnityEngine;

public class AIRequestHandlerTest : RequestHandlerBase
{
    public AIRequestHandlerTest(BehaviourBase behaviour) : base(behaviour)
    {
    }

    public override void ReceiveRequest(RequestBase request)
    {
        if (!m_foreRequestQueue.Contains(request) && request.exeCondition())
        {
            EnqueueFore(request);
            //Debug.Log("把请求添加至前端队列");
        }
    }

    protected override void OnUpdate()
    {
        //每一帧把仍然存活的队列从前端移动到后端，在下一帧把后端队列的数据移动到前端队列
        for (int i = 1; i < m_backRequestQueue.Count; i++)
        {
            EnqueueFore(DequeueBack());
        }


        for (int i = 0; i < m_foreRequestQueue.Count; i++)
        {
            var currRequest = m_foreRequestQueue.Peek();
            bool exe = currRequest.exeCondition();
            bool over = currRequest.RequestUpdate();
            if (exe)
            {
                currRequest.RequestAction();
            }
            if (over)
            {
                DequeueFore();
                break;
            }
            EnqueueBack(DequeueFore());

        }


    }

    protected override void OnFixedUpdate()
    {

    }
}
