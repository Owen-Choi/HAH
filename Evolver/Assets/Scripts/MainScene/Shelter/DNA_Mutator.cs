using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DNA_Mutator : MonoBehaviour
{
    float radius;
    int require;    int DefaultRequire;
    public GameObject BackPack;
    public Text Require;
    public Canvas BodyPartChoose;
    public Canvas BasicUI;
    private void Awake()
    {
        BodyPartChoose.gameObject.SetActive(false);
        radius = 1f;
        Require.text = require.ToString();
        DefaultRequire = 3;
        require = DefaultRequire;
    }
    private void Update()
    {
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("Player"));
        if(circle)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(BackPack.GetComponent<BackPack>().GetItemCount("MutantSample") >= require)
                {
                    BackPack.GetComponent<BackPack>().UseItem("MutantSample", require);
                    BodyPartChoose.gameObject.SetActive(true);
                    BasicUI.gameObject.SetActive(false);                                //BodyPartChoose Canvas에서 버튼을 눌러 선택 완료시 BasicUI 다시 켜주기.
                }
            }
        }
    }
}
