using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class MenuManager : MonoBehaviour
{
    public GameObject levelLoader;
    private LevelLoader _levelLoader;

    public GameObject mainMenu;
    public GameObject howToPlayMenu;
    public GameObject controlMenu;
    public GameObject stagesMenu;

    private void Awake()
    {
        _levelLoader = levelLoader.GetComponent<LevelLoader>();
        mainMenu.SetActive(true);
        howToPlayMenu.SetActive(false);
        controlMenu.SetActive(false);
        stagesMenu.SetActive(false);
    }

    public void OnPlayPressed()
    {
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1f);
        _levelLoader.LoadNextLevel();
    }

    public void OnHowToPlayPressed()
    {
        mainMenu.SetActive(false);
        howToPlayMenu.SetActive(true);
    }

    public void OnBackPressed()
    {
        mainMenu.SetActive(true);
        howToPlayMenu.SetActive(false);
    }

    public void OpenControls()
    {
        howToPlayMenu.SetActive(false);
        controlMenu.SetActive(true);
    }

    public void OpenStages()
    {
        howToPlayMenu.SetActive(false);
        stagesMenu.SetActive(true);
    }

    public void CloseControls()
    {
        howToPlayMenu.SetActive(true);
        controlMenu.SetActive(false);
    }

    public void CloseStages()
    {
        howToPlayMenu.SetActive(true);
        stagesMenu.SetActive(false);
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }
}