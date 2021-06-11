using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Game_Manager : MonoBehaviour
{
    bool isOnce;    bool One;   bool Two;   bool Three; public bool isStart;    public bool isLoad;
    // # ���� �޴��� ��ũ��Ʈ������ ���� ������ �������� �帧�� �����ϴ� �ڵ带 �ַ� �ٷ� �����̴�. ex : �÷��̾��� ���̾� ���濡 ���� ������Ʈ ����, UI ������Ʈ ���� ��
    public GameObject Player; GameObject PlayerCache;
    public GameObject Tutorial;
    public GameObject Guide;
    public GameObject MainScreen;
    public GameObject BasicUI;
    GameObject MainScreenCache;
    GameObject GuideCache;

    public GameObject LightArrow;   public GameObject SilverArrow;  public GameObject FireArrow;    public GameObject Middle_Left_ShotPoint;   public GameObject Middle_Right_ShotPoint; 
    public GameObject Full_Left_ShotPoint;     public GameObject Full_Right_ShotPoint;    public GameObject Bottle1;  public GameObject Bottle2;  public GameObject Bottle3;
    public GameObject SkillChoose;
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
        MainScreenCache = MainScreen;
        PlayerCache = Player;
        MainScreenCache.gameObject.SetActive(true);
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
        PlayerCache.GetComponent<Player>().StackStarvation();                               //���۰� ���ÿ� ����, ��� Stack
        PlayerCache.GetComponent<Player>().StackThirsty();
    }


    void Update()
    {
        if(isStart)
        {
            MainScreenCache.SetActive(false);
            Tutorial.SetActive(true);
            isStart = false;
        }

        if(isLoad)
        {
            isLoad = false;
            LoadGame();
        }

        /*if(PlayerCache.layer != LayerMask.NameToLayer("PlayerInShelter") && !isOnce)       //�÷��̾ ���Ͱ� �ƴ϶�� ���ɰ� �񸶸� ��ġ ���� 
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
        }*/


        // # ���ɰ� ȭ�� ũ�θ�ƽ ���� �ڵ�
        if(Temp_RadioActive != Player_Stat.instance.RadioActive)
        {
            CA.intensity.Override(Player_Stat.instance.RadioActive * 0.06f);                //ȭ�鿡 ũ�θ�ƽ ȿ���� �ش�.
            Temp_RadioActive = Player_Stat.instance.RadioActive;
        }

        // # ���� ��ġ UI ���� �ڵ�
        if (Temp_RadioActive > 70 && !Two)
        {
            Two = true;
            GuideCache.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
            Two = false;

        // # �񸶸� ��ġ UI ���� �ڵ�
        if (Player_Stat.instance.thirsty > 70 && !Three)
        {
            Three = true;
            GuideCache.transform.GetChild(4).gameObject.SetActive(true);
        }
        else
            Three = false;

        // # ü�°� ȭ�� ������ ���� �ڵ�
        if (Player_Stat.instance.health <= 35f)                                              //ü���� 35 ���Ϸ� �������ٸ�
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

    void LoadGame()
    {
        MainScreenCache.SetActive(false);

        // # �ε� �ڵ�
        SaveSystem.LoadPhysicalSkill();
        SaveSystem.LoadSkill();
        SaveSystem.LoadStat();
        SaveSystem.LoadItem();

        LoadSystem.LoadPhysicalSkill();
        LoadSystem.LoadSkill();
        LoadSystem.LoadStat();
        LoadSystem.LoadItem();
        BasicUI.SetActive(true);
        Time.timeScale = 1;
        DF.focalLength.Override(0);

        if (Player_Stat.instance.isLight)
        {
            BasicUI.transform.GetChild(16).gameObject.SetActive(true);
            BasicUI.transform.GetChild(16).transform.GetChild(0).gameObject.SetActive(true);    //��¡ UI�� ù��° �ڽ�(�淮ȭ��)�� Ȱ��ȭ
            Destroy(BasicUI.transform.GetChild(16).transform.GetChild(1).gameObject);           //�ι�° �ڽ�(��ȭ��)�� �ı�
            Destroy(BasicUI.transform.GetChild(16).transform.GetChild(2).gameObject);           //����° �ڽ�(��ȭ��)�� �ı�

            SilverArrow.gameObject.SetActive(false);
            FireArrow.gameObject.SetActive(false);
            Middle_Left_ShotPoint.gameObject.SetActive(false);
            Middle_Right_ShotPoint.gameObject.SetActive(false);
            Full_Left_ShotPoint.gameObject.SetActive(false);
            Full_Right_ShotPoint.gameObject.SetActive(false);
            Bottle1.gameObject.SetActive(false);
            Bottle2.gameObject.SetActive(false);
            Bottle3.gameObject.SetActive(false);
            SkillChoose.GetComponent<SkillChoose>().MinValue = 1;
            SkillChoose.GetComponent<SkillChoose>().MaxValue = 8;
            GameObject.Find("SkillChoose").GetComponent<SkillChoose>().sprites = Resources.LoadAll<Sprite>("Light_Arrow_SkillIcon");
        }
        else if (Player_Stat.instance.isSilver)
        {
            BasicUI.transform.GetChild(16).gameObject.SetActive(true);
            BasicUI.transform.GetChild(16).transform.GetChild(1).gameObject.SetActive(true);   
            Destroy(BasicUI.transform.GetChild(16).transform.GetChild(0).gameObject);          
            Destroy(BasicUI.transform.GetChild(16).transform.GetChild(2).gameObject);

            LightArrow.gameObject.SetActive(false);
            FireArrow.gameObject.SetActive(false);
            Bottle1.gameObject.SetActive(false);
            Bottle2.gameObject.SetActive(false);
            Bottle3.gameObject.SetActive(false);
            SkillChoose.GetComponent<SkillChoose>().MinValue = 15;
            SkillChoose.GetComponent<SkillChoose>().MaxValue = 24;
            GameObject.Find("SkillChoose").GetComponent<SkillChoose>().sprites = Resources.LoadAll<Sprite>("Silver_Arrow_SkillIcon");
        }
        else if (Player_Stat.instance.isFire)
        {
            BasicUI.transform.GetChild(16).gameObject.SetActive(true);
            BasicUI.transform.GetChild(16).transform.GetChild(2).gameObject.SetActive(true);
            Destroy(BasicUI.transform.GetChild(16).transform.GetChild(1).gameObject);
            Destroy(BasicUI.transform.GetChild(16).transform.GetChild(0).gameObject);

            LightArrow.gameObject.SetActive(false);
            SilverArrow.gameObject.SetActive(false);
            SkillChoose.GetComponent<SkillChoose>().MinValue = 25;
            SkillChoose.GetComponent<SkillChoose>().MaxValue = 32;
            GameObject.Find("SkillChoose").GetComponent<SkillChoose>().sprites = Resources.LoadAll<Sprite>("Fire_Arrow_SkillIcon");
        }
    }
}
