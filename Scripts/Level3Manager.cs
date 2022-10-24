using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public Animator transition;
    public LevelLoader levelLoader;

    public GameObject player;
    private Level3Player _player;

    public GameObject canvas;
//    public GameObject playerHand;
 //   public GameObject leapController;

    public bool isEscaped = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay(2f));
        _player = player.GetComponent<Level3Player>();
//        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
//        transition = GameObject.Find("Crossfade").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.dead ==true )
        {
            GameOver();
        }

        if (isEscaped == true)
        {
            isEscaped = false;
            Debug.Log("Escaped!");
            StartCoroutine(EndLevel());
        }
    }

    IEnumerator StartDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canvas.SetActive(true);
//        playerHand.SetActive(true);
//        leapController.SetActive(true);
    }

    void GameOver()
    {
//        playerHand.SetActive(false);
//        leapController.SetActive(false);
        canvas.GetComponent<Level2TextBox>().gameOver.SetActive(true);
        Invoke("RestartDelay", 5);
    }

    void RestartDelay()
    {
        transition.SetTrigger("Start");
        //yield return new WaitForSeconds(delay);
        levelLoader.RestartLevel(0);
    }



    IEnumerator EndLevel()
    {
//        playerHand.SetActive(false);
//        leapController.SetActive (false);
        yield return new WaitForSeconds(1f);

        canvas.GetComponent<Level2TextBox>().OpenTextPlay2();
        yield return new WaitForSeconds(10f);
        levelLoader.LoadMenu();
    }
}
