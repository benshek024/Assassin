using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject box, gun, gunHead,target,gunShot;

    public bool openBox=false;

    public bool ready = false, fire=false,reload=false, endFire=false;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        gunShot.SetActive(false);
        box.SetActive(true);
        gun.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (endFire)
        {
            EndFire();
            endFire = false;
        }
        if (openBox)
        {
            OpenBox();
        }

        if (reload)
        {
            ReadyFire();
        }

        if (fire&&ready&&reload)
        {
            fire = false;
            Fire();
        }
    }

    void OpenBox()
    {
        ready = true;
        box.SetActive(false);
        gun.SetActive(true);
    }

    void ReadyFire()
    {
        Vector3 targetDir = gunHead.transform.position - target.transform.position;
        Quaternion newRotation = Quaternion.LookRotation(targetDir);
        gunHead.transform.rotation = Quaternion.Slerp(gunHead.transform.rotation, newRotation, 2*Time.deltaTime);
    }

    void Fire()
    {
        gunShot.SetActive(true);
    }

    void EndFire()
    {
        gunShot.SetActive(false);
    }
}
