using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBottleFollow : MonoBehaviour
{
    public Transform Parent;                            //따라다닐 구체의 수가 늘어난다면 Parent값에 바로 전 구체의 오브젝트를 넣어주면 된다. 
    public Vector3 followPosition;
    public Queue<Vector3> ParentPos;
    public int followDelay;

    private void Awake()
    {
        ParentPos = new Queue<Vector3>();
    }

    void Update()
    {
        UpdateFollowPos();
        Follow();
    }

    void Follow()
    {
        transform.position = followPosition;
    }

    void UpdateFollowPos()
    {
        //따라다닐 포지션을 넣어주기
        if(!ParentPos.Contains(Parent.position))
        ParentPos.Enqueue(Parent.position);

        //따라다닐 포지션을 꺼내오기
        if (ParentPos.Count > followDelay)
            followPosition = ParentPos.Dequeue();
        else if (ParentPos.Count < followDelay)
            followPosition = Parent.position;
    }
}
