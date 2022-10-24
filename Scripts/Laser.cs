using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer laser;
    public GameObject laserPos;
    public float laserRange;

    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        laser.SetPosition(0, laserPos.transform.position);
        laser.SetPosition(1, laserPos.transform.position + laserPos.transform.forward * laserRange);
    }
}
