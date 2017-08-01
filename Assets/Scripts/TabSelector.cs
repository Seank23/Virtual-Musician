using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabSelector : MonoBehaviour
{
    public GameObject[] tabs;
    public GameObject[] menus;
    private Color defaultColor;
    public float alpha = 0.8f;

    void Awake()
    {
        defaultColor = tabs[0].GetComponent<Image>().color;

        EventSystem.current.SetSelectedGameObject(tabs[0]);
        SetActiveMenu(menus[0]);
    }

    public void SetActiveMenu(GameObject menuToBeSet)
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }

        foreach(GameObject tab in tabs)
        {
            tab.GetComponent<Image>().color = defaultColor;
        }

        menuToBeSet.SetActive(true);
        //Color menuColor = menuToBeSet.GetComponent<Image>().color;
        //menuColor.a = alpha;
        //menuToBeSet.GetComponent<Image>().color = menuColor;

        GameObject currentTab = EventSystem.current.currentSelectedGameObject;
        Color tabColor = currentTab.GetComponent<Image>().color;
        tabColor.a = alpha;
        currentTab.GetComponent<Image>().color = tabColor;
    }
}
