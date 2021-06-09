using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    
    public static void SaveStat()                                                       //능력치를 저장하는 함수
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player_Stat.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData statData = new PlayerData();                                         //default 생성자는 스탯을 저장한다.
        formatter.Serialize(stream, statData);
        stream.Close();
    }

    public static void SaveSkill()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Skills.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData SkillData = new PlayerData(GameObject.Find("Skill_System_In_Map"));  //스킬 정보를 저장하는 함수
        formatter.Serialize(stream, SkillData);                                         //여기에 구조체 정보가 들어갈 것이다.(Skill_Container)
        stream.Close();
    }

    public static PlayerData LoadStat()                                                 //능력치를 불러오는 함수
    {
        string path = Application.persistentDataPath + "/Player_Stat.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData StatData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return StatData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static PlayerData LoadSkill()                                                //스킬을 불러오는 함수
    {
        string path = Application.persistentDataPath + "/Skills.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData StatData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return StatData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
