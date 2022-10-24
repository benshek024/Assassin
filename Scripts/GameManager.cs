using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject truck, enemies;
    public bool s2=false;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        truck.SetActive(false);
        enemies.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (s2) { Stage2(); s2 = false; }
    }

    void Stage2()
    {
        animator.SetTrigger("Stage2");
    }
}
