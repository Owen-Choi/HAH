using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Game_Manager : MonoBehaviour
{
    bool isOnce;    bool One;   bool Two;   bool Three; public bool isStart;    public bool isLoad;
    // # 게임 메니저 스크립트에서는 게임 진행의 전반적인 흐름을 제어하는 코드를 주로 다룰 예정이다. ex : 플레이어의 레이어 변경에 따른 오브젝트 수정, UI 오브젝트 조정 등
    public GameObject Player; GameObject PlayerCache;
    public GameObject Tutorial;
    public GameObject Guide;
    public GameObject MainScreen;
    public GameObject BasicUI;
    GameObject MainScreenCache;
    GameObject GuideCache;

    // # 포스트 프로세싱 관련 변수
    UnityEngine.Rendering.VolumeProfile profile;                        //먼저 프로필에 접근하고
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
        Check = true;                                                                       //노이즈 조건문이 계속해서 업데이트 되는 걸 막기 위한 변수

        Time.timeScale = 0;
        DF.focalLength.Override(80);
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
            MainScreenCache.SetActive(false);
            // # 로드 코드
            SaveSystem.LoadPhysicalSkill();
            SaveSystem.LoadSkill();
            SaveSystem.LoadStat();


            LoadSystem.LoadPhysicalSkill();
            LoadSystem.LoadSkill();
            LoadSystem.LoadStat();
            BasicUI.SetActive(true);
            Time.timeScale = 1;
            DF.focalLength.Override(0);
        }
        if(PlayerCache.layer != LayerMask.NameToLayer("PlayerInShelter") && !isOnce)       //플레이어가 쉘터가 아니라면 방사능과 목마름 수치 증가 
        {
            isOnce = true;
            PlayerCache.GetComponent<Player>().StackRadioActive();
            PlayerCache.GetComponent<Player>().StackThirsty();
        }
        if(PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))                  //플레이어가 쉘터라면 축적 멈춤
        {
            isOnce = false;
            CancelInvoke("StackThirsty");
            CancelInvoke("StackRadioActive");
        }


        // # 방사능과 화면 크로마틱 관련 코드
        if(Temp_RadioActive != Player_Stat.instance.RadioActive)
        {
            CA.intensity.Override(Player_Stat.instance.RadioActive * 0.06f);                //화면에 크로마틱 효과를 준다.
            Temp_RadioActive = Player_Stat.instance.RadioActive;
        }

        // # 방사능 수치 UI 관련 코드
        if (Temp_RadioActive > 70 && !Two)
        {
            Two = true;
            GuideCache.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
            Two = false;

        // # 목마름 수치 UI 관련 코드
        if (Player_Stat.instance.thirsty > 70 && !Three)
        {
            Three = true;
            GuideCache.transform.GetChild(4).gameObject.SetActive(true);
        }
        else
            Three = false;

        // # 체력과 화면 노이즈 관련 코드
        if (Player_Stat.instance.health <= 35f)                                              //체력이 35 이하로 떨어진다면
        {
            Check = true;
            FG.intensity.Override((100 - Player_Stat.instance.health) * 0.01f);             //화면에 노이즈 효과를 준다.
            CAJ.saturation.Override((100 - Player_Stat.instance.health) * -1);
            if (!One)
            {
                GuideCache.transform.GetChild(2).gameObject.SetActive(true);                    //체력 안내 UI를 띄워준다.
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

        // # 스킬 선택창 오픈 시 초점 흐려짐 관련 코드
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
