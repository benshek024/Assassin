using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public bool droneIsEnd = false;

    private Animator droneAnimator;

    // Start is called before the first frame update
    void Start()
    {
        droneAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (droneAnimator == true)
        {
            StartCoroutine(MoveDrone());
        }
    }

    IEnumerator MoveDrone()
    {
        yield return new WaitForSeconds(1f);
        droneAnimator.SetTrigger("droneIsEnd");
    }
}
