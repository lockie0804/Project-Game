using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuHandler : MonoBehaviour
{

    public GameObject[] panels;
    public MenuStates menuState;
    private void Start()
    {
        ChangePanel(0);
    }
    public void Update()
    {
        if (menuState == MenuStates.AnyKey)
        {
            if (Input.anyKey)
            {
                ChangePanel(1);
            }
        }
    }
    public void ChangePanel(int value)
    {
        menuState = (MenuStates)value;
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        panels[value].SetActive(true);        
    }
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
public enum MenuStates
{
    AnyKey,
    MainMenu,
    Options
}