using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter_Item : MonoBehaviour
{
    Canvas DisplayLab;
    Canvas DisplaySkill;
    Canvas DisplayMap;
    Canvas Displaysurvive;
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Lab ������Ʈ�� �÷��̾�� �浹�ߴٸ�
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Lab"))
        {
            DisplayLab.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //Lab ������Ʈ�� �÷��̾���� �浹�� �����ٸ�
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Lab"))
        {
            DisplayLab.gameObject.SetActive(false);
        }
    }
}
