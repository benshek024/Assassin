using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBoss : MonoBehaviour
{
    private Animator bossAnimator;
    private NavMeshAgent bossAgent;

    public GameObject enemyCount;
    private EnemyCount _enemyCount;

    [HideInInspector]public bool isBossDead = false, isBossAlive = false, isBossStop = false, killBoss = false;
    public bool walkToFirst = false, stand = false, panic = false, getup = false, runBack = false;

    public GameObject firstPoint, lastPoint;


    // Start is called before the first frame update
    void Start()
    {
        _enemyCount = enemyCount.GetComponent<EnemyCount>();
        bossAgent = GetComponent<NavMeshAgent>();
        bossAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyCount.isAllDead == true)
        {
            walkToFirst = true;
        }

        if (!isBossDead)
        {
            MoveBoss();
        }
    }

    public void MoveBoss()
    {
        if (walkToFirst == true)
        {
            bossAgent.SetDestination(firstPoint.transform.position);
            bossAgent.speed = 0.5f;
            bossAnimator.SetTrigger("WalkToFirst");
            walkToFirst = false;
            stand = true;
        }

        if (stand == true)
        {
            if (Vector3.Distance(gameObject.transform.position, firstPoint.transform.position) <= 0.5f)
            {
                bossAnimator.ResetTrigger("WalkToFirst");
                bossAnimator.SetTrigger("Stand1");
                stand = false;
                StartCoroutine(Panic());
            }
        }

        if (panic == true)
        {
            bossAnimator.SetTrigger("Panic");
            bossAnimator.ResetTrigger("Stand1");
            stand = false;
            StartCoroutine(GetUp());
        }

        if (getup == true)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        gameObject.transform.position.y,
                                                        gameObject.transform.position.z + 0.008f);
                                                        
            bossAnimator.SetTrigger("GetUp");
            bossAnimator.ResetTrigger("Panic");
            panic = false;
            StartCoroutine(RunBack());
        }

        if (runBack == true)
        {
            stand = false;
            panic = false;
            getup = false;
            bossAgent.SetDestination(lastPoint.transform.position);
            bossAgent.speed = 1f;
            bossAnimator.SetTrigger("Run");
            bossAnimator.ResetTrigger("GetUp");
            if (Vector3.Distance(gameObject.transform.position, lastPoint.transform.position) <= 0.5f)
            {
                isBossAlive = true;
                runBack = false;
                bossAgent.isStopped=true;
                
            }
        }
    }

    IEnumerator RunBack()
    {
        yield return new WaitForSeconds(1.5f);
        runBack = true;
    }

    IEnumerator Panic()
    {
        yield return new WaitForSeconds(1f);
        panic = true;
    }

    IEnumerator GetUp()
    {
        yield return new WaitForSeconds(2f);
        getup = true;
    }

    public void Die()
    {
        isBossDead = true;
        
        bossAnimator.SetTrigger("Dead");
        bossAnimator.ResetTrigger("WalkToFirst");
        bossAnimator.ResetTrigger("Panic");
        bossAnimator.ResetTrigger("GetUp");
        bossAnimator.ResetTrigger("Run");
        bossAnimator.ResetTrigger("Stand1");
        bossAgent.isStopped = true;
        bossAgent.ResetPath();
    }
}
