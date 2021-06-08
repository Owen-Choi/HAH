using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    bool isOnce;    bool One;   bool Two;
    // # ���� �޴��� ��ũ��Ʈ������ ���� ������ �������� �帧�� �����ϴ� �ڵ带 �ַ� �ٷ� �����̴�. ex : �÷��̾��� ���̾� ���濡 ���� ������Ʈ ����, UI ������Ʈ ���� ��
    public GameObject Player; GameObject PlayerCache;
    public GameObject Tutorial;
    public GameObject Guide;
    GameObject GuideCache;
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
        GuideCache = Guide;
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
            CA.intensity.Override(Player_Stat.instance.RadioActive * 0.06f);                //ȭ�鿡 ũ�θ�ƽ ȿ���� �ش�.
            Temp_RadioActive = Player_Stat.instance.RadioActive;
        }

        // # ���� ��ġ UI���� �ڵ�
        if (Temp_RadioActive > 70 && !Two)
        {
            Two = true;
            GuideCache.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
            Two = false;


        // # ü�°� ȭ�� ������ ���� �ڵ�
        if(Player_Stat.instance.health <= 35f)                                              //ü���� 35 ���Ϸ� �������ٸ�
        {
            Check = true;
            FG.intensity.Override((100 - Player_Stat.instance.health) * 0.01f);             //ȭ�鿡 ������ ȿ���� �ش�.
            CAJ.saturation.Override((100 - Player_Stat.instance.health) * -1);
            if (!One)
            {
                GuideCache.transform.GetChild(2).gameObject.SetActive(true);                    //ü�� �ȳ� UI�� ����ش�.
                One = true;
            }
        }
        else
        {
            if (Check)
            {
                FG.intensity.Override(0);
                CAJ.saturation.Override(0);
                Check = false;
            }
            One = false;
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
