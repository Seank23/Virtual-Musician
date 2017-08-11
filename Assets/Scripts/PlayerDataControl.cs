using UnityEngine;
using System.Collections.Generic;

public class PlayerDataControl : MonoBehaviour
{
    public static PlayerDataControl data;

    public string saveID;
    public string playerName;
    public int playerGender;
    public int playerMusicality;

    void Awake()
    {
        if (data == null)
        {
            DontDestroyOnLoad(gameObject);
            data = this;
        }
        else if (data != this)
        {
            Destroy(gameObject);
        }
    }

    public string ConvertToGender(int i)
    {
        switch(i)
        {
            case 0:
                return "Male";
            case 1:
                return "Female";
        }
        return "N/A";
    }

    public string ConvertToMusicality(int i)
    {
        switch (i)
        {
            case 0:
                return "Complete Beginner";
            case 1:
                return "Limited Ability";
            case 2:
                return "Somewhat Musical";
            case 3:
                return "Fairly Proficient";
            case 4:
                return "Virtuoso Musician";
        }
        return "N/A";
    }
}
