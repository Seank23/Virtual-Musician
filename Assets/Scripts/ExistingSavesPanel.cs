using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ExistingSavesPanel : MonoBehaviour
{
    public GameObject continueGameMenu;
    public GameObject saveTab;
    public List<GameObject> saveTabs = new List<GameObject>();
    private Color defaultColor;
    private bool isFocused;

    void Update()
    {
        if(continueGameMenu.GetComponent<CanvasGroup>().interactable && !isFocused && Time.time > 1)
        {
            SetupSavesPanel();
            isFocused = true;
        }
        if(!continueGameMenu.GetComponent<CanvasGroup>().interactable)
        {
            isFocused = false;
        }
    }

    private string GetPreviousSaves() { return PlayerPrefs.GetString("SaveID"); }

    private void SetupSavesPanel()
    {
        saveTabs.Clear();

        foreach (Transform child in transform)
            Destroy(child.gameObject);

        if (PlayerPrefs.HasKey("SaveID"))
        {
            string[] saves = GetPreviousSaves().Split('\n');
            List<string> savesL = saves.ToList();
            savesL.RemoveAt(saves.Length - 1);
            saves = savesL.ToArray();

            foreach (string save in saves)
            {
                SaveManager.saveManager.Load(save, "stats");
                GameObject saveEntry = Instantiate(saveTab);
                saveEntry.GetComponent<RectTransform>().SetParent(transform, false);
                Text[] entryText = saveEntry.GetComponentsInChildren<Text>();
                entryText[0].text = PlayerDataControl.data.playerName;
                entryText[1].text = PlayerDataControl.data.ConvertToGender(PlayerDataControl.data.playerGender) + "\n"
                    + PlayerDataControl.data.ConvertToMusicality(PlayerDataControl.data.playerMusicality);
                saveTabs.Add(saveEntry);
            }

            defaultColor = saveTabs[0].GetComponent<Image>().color;
        }
    }

    public void OnTabClick(GameObject tab)
    {
        foreach(GameObject saveTab in saveTabs)
        {
            saveTab.GetComponent<Image>().color = defaultColor;
        }

        tab.GetComponent<Image>().color = new Color32(39, 32, 98, 222);
    }
}
