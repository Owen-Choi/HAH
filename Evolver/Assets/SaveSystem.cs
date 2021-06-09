using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    
    public static void SaveStat()                                                       //�ɷ�ġ�� �����ϴ� �Լ�
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player_Stat.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData statData = new PlayerData();                                         //default �����ڴ� ������ �����Ѵ�.
        formatter.Serialize(stream, statData);
        stream.Close();
    }

    public static void SaveSkill()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Skills.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData SkillData = new PlayerData(GameObject.Find("Skill_System_In_Map"));  //��ų ������ �����ϴ� �Լ�
        formatter.Serialize(stream, SkillData);                                         //���⿡ ����ü ������ �� ���̴�.(Skill_Container)
        stream.Close();
    }

    public static PlayerData LoadStat()                                                 //�ɷ�ġ�� �ҷ����� �Լ�
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

    public static PlayerData LoadSkill()                                                //��ų�� �ҷ����� �Լ�
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
