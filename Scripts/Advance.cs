using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advance : MonoBehaviour
{
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            if (playerAnimator == null)
            {
                playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
            }

            playerAnimator.SetTrigger("Advance");
            gameObject.SetActive(false);
        }
    }
}
