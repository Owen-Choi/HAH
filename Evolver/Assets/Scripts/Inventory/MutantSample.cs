using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantSample : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            //오디오 플레이 추가 예정
        }
    }
    //불가능한 구조 : 이 오브젝트가 프리팹화 된 시점부터 다른 클래스나 오브젝트로의 참조는 불가능한 것 같다.
    /*private void OnDestroy()
    {
        BackPack.GetComponent<BackPack>().AddItem("MuntantSample", Random.Range(1, 4));
    }*/
}
