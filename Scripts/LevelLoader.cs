using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject transition;
    public float transitionTime = 1f;
    public bool loadNextLevel = false;

    private void Start()
    {
        transition.SetActive(true);
        Invoke("LevelStart", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (loadNextLevel == true)
        {
            LoadNextLevel();
        }
    }

    public void RestartLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    public void LoadMenu()
    {
        StartCoroutine(BackToMenu());
    }

    public void LoadNextLevel()
    {
        // Execute the coroutine if the function is called
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    // Show transition and load next scene after seconds of transitionTime has passed. 
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetActive(true);
        transition.GetComponent<Animator>().SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator BackToMenu()
    {
        transition.SetActive(true);
        transition.GetComponent<Animator>().SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(0);
    }

    void LevelStart()
    {
        transition.GetComponent<Animator>().SetTrigger("End");
    }
}
