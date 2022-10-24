using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Manager : MonoBehaviour
{
    public GameObject drone;
    public DroneController droneController;
    public GameObject enemyBoss;
    private EnemyBoss _enemyBoss;
    public GameObject hands;
    public GameObject canvas;
    public GameObject levelLoader;
    private LevelLoader _levelLoader;
    private bool FirstTime = true;
    public bool call = false;
    public bool isAlerted = false;

    // Start is called before the first frame update
    void Start()
    {
        hands.SetActive(false);
        canvas.SetActive(false);
        StartCoroutine(StartLevel());
        drone.SetActive(false);
        droneController = drone.GetComponent<DroneController>();
        _enemyBoss = enemyBoss.GetComponent<EnemyBoss>();
        _levelLoader = levelLoader.GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyBoss.isBossDead == true || _enemyBoss.isBossAlive == true || isAlerted == true)
        {
            StartCoroutine(EndLevel());
        }
    }

    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(2f);
        hands.SetActive(true);
        canvas.SetActive(true);
    }

    IEnumerator EndLevel()
    {
        /*
        hands.SetActive(false);
        drone.SetActive(true);

        droneController.droneIsEnd = true;
        yield return new WaitForSeconds(1f);
        if (_enemyBoss.isBossDead == true)
        {
            MissionData.mission = 1;
            //print("mission = " + MissionData.mission);
        }
        if (_enemyBoss.isBossAlive == true)
        {
            MissionData.mission = 2;
            //print("mission = " + MissionData.mission);
        }
        canvas.GetComponent<Level1TextBox>().OpenTextPlay2();
        yield return new WaitForSeconds(10f);
        if (MissionData.mission == 0)
        {
            _levelLoader.RestartLevel(0);
        }
        _levelLoader.loadNextLevel = true;
        */

        yield return new WaitForSeconds(1f);
        if (_enemyBoss.isBossDead == true)
        {
            MissionData.mission = 1;
        }
        if (_enemyBoss.isBossAlive == true)
        {
            MissionData.mission = 2;
        }
        hands.SetActive(false);
        drone.SetActive(true);
        droneController.droneIsEnd = true;
        canvas.GetComponent<Level1TextBox>().OpenTextPlay2();
        yield return new WaitForSeconds(10f);
        _levelLoader.loadNextLevel = true;
    }
}
