using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    bool isOnce;
    // # ���� �޴��� ��ũ��Ʈ������ ���� ������ �������� �帧�� �����ϴ� �ڵ带 �ַ� �ٷ� �����̴�. ex : �÷��̾��� ���̾� ���濡 ���� ������Ʈ ����, UI ������Ʈ ���� ��
    public GameObject Player; GameObject PlayerCache;
    public GameObject Tutorial;
    // # ����Ʈ ���μ��� ���� ����
    UnityEngine.Rendering.VolumeProfile profile;                        //���� �����ʿ� �����ϰ�
    public GameObject Global_Volume;
    GameObject Global_Volume_Cache;
    UnityEngine.Rendering.Universal.ChromaticAberration CA;
    UnityEngine.Rendering.Universal.FilmGrain FG;
    UnityEngine.Rendering.Universal.ColorAdjustments CAJ;
    UnityEngine.Rendering.Universal.DepthOfField DF;

    float Temp_RadioActive; float Temp_Health;  bool Check; public bool SkillOpen;  public bool SkillChosen;
    float DecreaseVal;
    void Awake()
    {
        PlayerCache = Player;
        Tutorial.gameObject.SetActive(true);

        Global_Volume_Cache = Global_Volume;
        profile = Global_Volume_Cache.GetComponent<UnityEngine.Rendering.Volume>().profile;
        profile.TryGet(out CA);
        profile.TryGet(out FG);
        profile.TryGet(out CAJ);
        profile.TryGet(out DF);

    }

    private void Start()
    {
        Temp_RadioActive = Player_Stat.instance.RadioActive;
        Temp_Health = Player_Stat.instance.health;
        Check = true;                                                                       //������ ���ǹ��� ����ؼ� ������Ʈ �Ǵ� �� ���� ���� ����

        Time.timeScale = 0;
        DF.focalLength.Override(80);
    }


    void Update()
    {
        if(PlayerCache.layer != LayerMask.NameToLayer("PlayerInShelter") && !isOnce)       //�÷��̾ ���Ͱ� �ƴ϶�� ���ɰ� �񸶸� ��ġ ���� 
        {
            isOnce = true;
            PlayerCache.GetComponent<Player>().StackRadioActive();
            PlayerCache.GetComponent<Player>().StackThirsty();
        }
        if(PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))                  //�÷��̾ ���Ͷ�� ���� ����
        {
            isOnce = false;
            CancelInvoke("StackThirsty");
            CancelInvoke("StackRadioActive");
        }


        // # ���ɰ� ȭ�� ũ�θ�ƽ ���� �ڵ�
        if(Temp_RadioActive != Player_Stat.instance.RadioActive)
        {
            CA.intensity.Override(Player_Stat.instance.RadioActive * 0.04f);                //ȭ�鿡 ũ�θ�ƽ ȿ���� �ش�.
            Temp_RadioActive = Player_Stat.instance.RadioActive;
        }


        // # ü�°� ȭ�� ������ ���� �ڵ�
        if(Player_Stat.instance.health <= 35f)                                              //ü���� 35 ���Ϸ� �������ٸ�
        {
            Check = true;
            FG.intensity.Override((100 - Player_Stat.instance.health) * 0.01f);             //ȭ�鿡 ������ ȿ���� �ش�.
            CAJ.saturation.Override((100 - Player_Stat.instance.health) * -1);
        }
        else
        {
            if (Check)
            {
                FG.intensity.Override(0);
                CAJ.saturation.Override(0);
                Check = false;
            }
            
        }

        // # ��ų ����â ���� �� ���� ����� ���� �ڵ�
        if (SkillOpen)
        {
            DF.focalLength.Override(80);
            SkillOpen = false;
        }
        if (SkillChosen)
        {
            SkillChosen = false;
            DF.focalLength.Override(0);
        }
    }
}
