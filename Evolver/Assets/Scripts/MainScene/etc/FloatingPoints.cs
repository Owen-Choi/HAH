using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPoints : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine("delay");
    }

    
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);            //�̷��� �ϸ� �θ� ������Ʈ�� ���´�
    }
}
