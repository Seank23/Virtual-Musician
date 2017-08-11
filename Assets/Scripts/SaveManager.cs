using UnityEngine;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager saveManager;
	
	void Awake ()
    {
	    if(saveManager == null)
        {
            DontDestroyOnLoad(gameObject);
            saveManager = this;
        }
        else if(saveManager != this)
        {
            Destroy(gameObject);
        }
	}

    public void Save(string saveName, string condition)
    {
        if (condition == "data")
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/" + saveName + ".dat");

            PlayerData data = new PlayerData();
            // Gets current game data from PlayerDataControl
            data.saveID = PlayerDataControl.data.saveID;
            data.playerName = PlayerDataControl.data.playerName;
            data.playerGender = PlayerDataControl.data.playerGender;
            data.playerMusicality = PlayerDataControl.data.playerMusicality;

            binary.Serialize(file, data);
            file.Close();
        }
        else if(condition == "awards")
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/" + saveName + "_Awards.dat");
            PlayerData data = new PlayerData();
            //data.unlockedAwards = PlayerDataControl.data.awardsUnlocked;
            binary.Serialize(file, data);
            file.Close();
        }
    }

    public void Load(string fileName, string conditions)
    {
        if (conditions == "all")
        {
            if (File.Exists(Application.persistentDataPath + "/" + fileName + ".dat"))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/" + fileName + ".dat", FileMode.Open);
                PlayerData data = (PlayerData)binary.Deserialize(file);
                file.Close();
                // Gets saved data from file, sets to current game data
                PlayerDataControl.data.saveID = data.saveID;
                PlayerDataControl.data.playerName = data.playerName;
                PlayerDataControl.data.playerGender = data.playerGender;
                PlayerDataControl.data.playerMusicality = data.playerMusicality;
            }
            if (File.Exists(Application.persistentDataPath + "/" + fileName + "_Awards.dat"))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/" + fileName + "_Awards.dat", FileMode.Open);
                PlayerData data = (PlayerData)binary.Deserialize(file);
                file.Close();
                //PlayerDataControl.data.awardsUnlocked = data.unlockedAwards;
            }
        }

        if(conditions == "stats")
        {
            if (File.Exists(Application.persistentDataPath + "/" + fileName + ".dat"))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/" + fileName + ".dat", FileMode.Open);
                PlayerData data = (PlayerData)binary.Deserialize(file);
                file.Close();
                // Gets saved data from file, sets to current game data
                PlayerDataControl.data.playerName = data.playerName;
                PlayerDataControl.data.playerGender = data.playerGender;
                PlayerDataControl.data.playerMusicality = data.playerMusicality;
            }
        }
    }

    public void DeleteSave(string fileName)
    {
        if (File.Exists(Application.persistentDataPath + "/" + fileName + ".dat"))
        {
            File.Delete(Application.persistentDataPath + "/" + fileName + ".dat");
        }
        if (File.Exists(Application.persistentDataPath + "/" + fileName + "_Awards.dat"))
        {
            File.Delete(Application.persistentDataPath + "/" + fileName + "_Awards.dat");
        }
    }
}

[Serializable]
class PlayerData
{
    public string saveID;
    public string playerName;
    public int playerGender;
    public int playerMusicality;
}

