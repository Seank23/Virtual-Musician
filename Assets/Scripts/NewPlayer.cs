using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : MonoBehaviour
{
    public InputField txtName;
    public Dropdown dropGender;
    public Dropdown dropMusicality;

    private string GetPreviousSaves() { return PlayerPrefs.GetString("SaveID"); }

    public void CreatePlayer()
    {
        string time = System.DateTime.Now.ToString();
        time = time.Replace("/", string.Empty).Replace(" ", string.Empty).Replace(":", string.Empty);
        PlayerDataControl.data.saveID = time;
        PlayerDataControl.data.playerName = txtName.text;
        PlayerDataControl.data.playerGender = dropGender.value;
        PlayerDataControl.data.playerMusicality = dropMusicality.value;

        SaveManager.saveManager.Save(PlayerDataControl.data.saveID, "data");

        PlayerPrefs.SetString("SaveID", GetPreviousSaves() + PlayerDataControl.data.saveID + "\n");

        Debug.Log("Player created");
    }
}
