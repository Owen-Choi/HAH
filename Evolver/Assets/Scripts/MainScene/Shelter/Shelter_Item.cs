using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shelter_Item : MonoBehaviour
{
    public Canvas DisplayLab;
    public Canvas DisplayPhysical_Lab;
    public Text Current_Skills;
    public Canvas DisplayMap;
    public Canvas DisplayKitchen;
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Lab ������Ʈ�� �÷��̾�� �浹�ߴٸ�
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Lab"))
        {
            DisplayLab.gameObject.SetActive(true);                   //��Ȱ��ȭ �Ǿ������� ��ã�� �� ������.....?
            Current_Skills.text = Player_Stat.instance.SkillLimit.ToString();
        }
        //Kitchen ������Ʈ�� �÷��̾�� �浹�ߴٸ�
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Kitchen"))
        {
            DisplayKitchen.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Map"))
        {
            DisplayMap.gameObject.SetActive(true);
        }
        if(other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Physical_Lab"))
        {
            DisplayPhysical_Lab.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //Lab ������Ʈ�� �÷��̾���� �浹�� �����ٸ�
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Lab"))
        {
            DisplayLab.gameObject.SetActive(false);
        }
        //Kitchen ������Ʈ�� �÷��̾���� �浹�� �����ٸ�
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Kitchen"))
        {
            DisplayKitchen.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Map"))
        {
            DisplayMap.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Physical_Lab"))
        {
            DisplayPhysical_Lab.gameObject.SetActive(false);
        }
    }
}
