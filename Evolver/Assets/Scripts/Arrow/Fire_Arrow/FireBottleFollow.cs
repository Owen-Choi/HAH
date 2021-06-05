using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBottleFollow : MonoBehaviour
{
    public Transform Parent;                            //����ٴ� ��ü�� ���� �þ�ٸ� Parent���� �ٷ� �� ��ü�� ������Ʈ�� �־��ָ� �ȴ�. 
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
        //����ٴ� �������� �־��ֱ�
        if(!ParentPos.Contains(Parent.position))
        ParentPos.Enqueue(Parent.position);

        //����ٴ� �������� ��������
        if (ParentPos.Count > followDelay)
            followPosition = ParentPos.Dequeue();
        else if (ParentPos.Count < followDelay)
            followPosition = Parent.position;
    }
}
