using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdvanceLevel3 : MonoBehaviour
{
    public Level3TextBox tb;
    public Animator playerAnimator;
    public bool enemyIsOn, enemyIsDead;
    public GameObject[] enemy;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyIsOn)
        {
            WaveStart();
            enemyIsOn = false;
        }
        if (enemyIsDead)
        {
            KillAll();
            enemyIsDead = false;
            
        }
        if (transform.childCount <= 0)
        {
            if (playerAnimator == null)
            {
                playerAnimator = GameObject.Find("Main Camera").GetComponent<Animator>();
            }

            playerAnimator.SetTrigger("Advance");
            Destroy(gameObject);
        }
    }

    public void WaveStart()
    {
        for(int i=0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<Level3Enemy>().isOn = true;
            enemyIsOn = false;
        }
    }
    public void KillAll()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<Level3Enemy>().isDead = true;
            enemyIsOn = false;
            tb.OpenTextPlay5();
        }
    }
}
