using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    public bool isAllDead = false;
    public int enemyAlive = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAlive <= 0)
        {
            isAllDead = true;
        }
    }
}
