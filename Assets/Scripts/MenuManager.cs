using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject newPlayerPanel;
    public GameObject optionsPanel;
    private GameObject activeMenu;

    void Start()
    {
        mainMenuPanel.SetActive(true);
        newPlayerPanel.SetActive(false);
        //optionsPanel.SetActive(false);
    }

    public void GoToMenu(string menuName)
    {
        switch (menuName)
        {
            case "MainMenu":
                mainMenuPanel.SetActive(true);
                break;

            case "NewPlayer":
                activeMenu = mainMenuPanel;
                newPlayerPanel.transform.Translate(-1500, 0, 0);
                StartCoroutine(SlideMenu(new Vector3(1500, 0, 0), 1));
                //mainMenuPanel.SetActive(false);
                //newPlayerPanel.SetActive(true);

                break;

            case "Options":
                break;
        }
    }

    IEnumerator SlideMenu(Vector3 translation, int time)
    {
        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            Vector3 frame = new Vector3(Mathf.Lerp(0, translation.x, t),
                                        Mathf.Lerp(0, translation.y, t),
                                        Mathf.Lerp(0, translation.z, t));
            print(frame.x);
        }
        yield return null;
    }
}
