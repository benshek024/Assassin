using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Level1Enemy : MonoBehaviour
{
    private Animator enemyAnimator;
    private NavMeshAgent navMeshAgent;

    private bool isStop = false;
    [SerializeField] private bool isDead = false, isTalk=false;
    [HideInInspector] public bool isWalk = false;

    public Level1Manager level1Manager;

    public GameObject enemyManager;
    public EnemyCount enemyCount;
    public Level1Manager level1;

    [Tooltip("Scripted to auto assign a broken glass object upon destorying a glass so you don't have to assign it yourself.")]
    public GameObject brokenGlass;

    [Header("Enemy Expression Icons")]
    [Tooltip("Storing the location of where question mark icons will be displayed.")]
    [SerializeField] private RectTransform curious;
    [Tooltip("Image that will show on top of the enemy after a glass has been broken.")]
    [SerializeField] private GameObject questionMarkImage;
    [Tooltip("Storing the location of where exclamation mark icons will be displayed.")]
    [SerializeField] private RectTransform alerted;
    [Tooltip("Image that will show on top of the enemy after the distance between broken glass and enemy is close enough.")]
    [SerializeField] private GameObject exclamationMarkImage;
    [Tooltip("Assign Canvas under Enemy game object.")]
    [SerializeField] Canvas enemyCanvas;
    [Tooltip("Assign Main Camera so the icons will always face where player at.")]
    [SerializeField] private Transform playerPos;


    private void Start()
    {
        questionMarkImage.SetActive(false);
        exclamationMarkImage.SetActive(false);
        enemyCount = enemyManager.GetComponent<EnemyCount>();
        enemyAnimator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!isDead)
        {
            CanvasPosition();
            WalkToGlass();
            StopAtGlass();
        }

        if (isTalk == true) 
        {
            level1.call = true;
            isTalk = false;
        }
        // Execute Die function if enemy was hit by player.
        if (isDead && !isStop)
        {
            isStop = true;
            Die();
        }
    }

    // START of Canvas region
    #region Canvas
    // Makes the canvas and its expression icons always face where the player at.
    void CanvasPosition()
    {
        enemyCanvas.transform.LookAt(new Vector3(-playerPos.position.x,
                                                  playerPos.transform.position.y,
                                                  -playerPos.transform.position.z));

        curious.transform.LookAt(new Vector3(-playerPos.position.x,
                                              playerPos.transform.position.y,
                                              -playerPos.transform.position.z));

        alerted.transform.LookAt(new Vector3(-playerPos.position.x,
                                              playerPos.transform.position.y,
                                              -playerPos.transform.position.z));
    }
    #endregion
    // END of Canvas region

    // START of Explore region
    #region Explore
    // Stop enemy from moving and trigger Alerted animation if 
    // 1. Distance between enemy and broken glass is less than 0.5
    //                              or
    // 2. Distance between enemy and broken glass is less than or equal to NavMeshAgent's stopping distance.
    void StopAtGlass()
    {
        if (Vector3.Distance(this.transform.position, brokenGlass.transform.position) < .5 || 
            Vector3.Distance(this.transform.position, brokenGlass.transform.position) <= navMeshAgent.stoppingDistance)
        {
            StartCoroutine(Alerted());
        }
    }

    // Set a destination for enemy's NavMeshAgent to move enemy while isWalk bool is true and 
    // its distance between broken glass is less than 0.5.
    void WalkToGlass()
    {
        if (isWalk && Vector3.Distance(this.transform.position, brokenGlass.transform.position) > .5)
        {
            navMeshAgent.SetDestination(brokenGlass.transform.position);
            enemyAnimator.SetTrigger("isWalk");
            isWalk = true;
        }
    }

    // Executed in Glass.cs when a glass is broken
    public void Curious()
    {
        questionMarkImage.SetActive(true);
        navMeshAgent.isStopped = true;
        navMeshAgent.ResetPath();
        enemyAnimator.SetTrigger("Curious");
    }

    IEnumerator Alerted()
    {
        isWalk = false;
        enemyAnimator.SetTrigger("isStop");
        yield return new WaitForSeconds(1f);
        exclamationMarkImage.SetActive(true);
        questionMarkImage.SetActive(false);
        enemyAnimator.SetTrigger("Alerted");
        yield return new WaitForSeconds(15f);
        level1Manager.isAlerted = true;
    }
    #endregion
    // END of Explore region

    // START of Dead region
    #region Dead
    public void Die()
    {
        enemyCount.enemyAlive--;
        isWalk = false;
        enemyAnimator.SetTrigger("Dead");  // Execute dead animation
        enemyAnimator.ResetTrigger("isWalk");
        enemyAnimator.ResetTrigger("isStop");
        enemyAnimator.ResetTrigger("Curious");
        enemyAnimator.ResetTrigger("Alerted");
        enemyAnimator.ResetTrigger("useRadio");
        navMeshAgent.isStopped = true;
        navMeshAgent.ResetPath();
        questionMarkImage.SetActive(false);
        exclamationMarkImage.SetActive(false);
    }
    #endregion
    // END of Dead region
}
