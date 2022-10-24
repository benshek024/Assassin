using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFinger : MonoBehaviour
{
    private LineRenderer laser;
    public GameObject laserPos, fingerPos;
    public float laserRange;
    public bool hand;


    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        laser.SetPosition(0, transform.position);
        laser.transform.LookAt(transform.position,Vector3.down);
        // Vector3 dir = transform.position - fingerPos.transform.position;
        if (hand)
        {
            laser.SetPosition(1, laserPos.transform.position + laserPos.transform.right * laserRange);
        }
        else
        {
            laser.SetPosition(1, laserPos.transform.position + laserPos.transform.right * -laserRange);
        }
    }


}
