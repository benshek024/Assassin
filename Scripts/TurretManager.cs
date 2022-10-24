using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public Turret turret1, turret2, turret3, turret4, turret5, turret6,turret7;
    private int openCount = 0;
    public GameManager gm;
    public bool allReady=false, allFire=false, allOpen=false, allStop=false;
    private AudioSource audioSource;
    public AudioClip gun;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        turret1.openBox = false;
        turret2.openBox = false;
        turret3.openBox = false;
        turret4.openBox = false;
        turret5.openBox = false;
        turret6.openBox = false; 
        turret7.openBox = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (allStop)
        {
            turret1.endFire = true;
            turret2.endFire = true;
            turret3.endFire = true;
            turret4.endFire = true;
            turret5.endFire = true;
            turret6.endFire = true;
            turret7.endFire = true;
        }
        if (allOpen)
        {
            Open1(); Open2(); Open3(); Open4(); Open5(); Open6(); Open7();
            allOpen = false;
        }

        if (allReady)
        {
            Ready();
            allReady = false;
        }

        if (allFire)
        {
            Fire();
            allFire = false;
            audioSource.PlayOneShot(gun, 0.4f);
        }
    }

    public void Open1()
    {
        turret1.openBox = true;
        openCount += 1;
    }
    public void Open2()
    {
        turret2.openBox = true;
        openCount += 1;
    }
    public void Open3()
    {
        turret3.openBox = true;
        openCount += 1;
    }
    public void Open4()
    {
        turret4.openBox = true;
        openCount += 1;
    }
    public void Open5()
    {
        turret5.openBox = true;
        openCount += 1;
    }
    public void Open6()
    {
        turret6.openBox = true;
        openCount += 1;
    }
    public void Open7()
    {
        turret7.openBox = true;
        openCount += 1;
    }

    void Count()
    {
        if (openCount >= 7) Stage2();
    }

    void Stage2()
    {
        
    }

    void Ready()
    {
        turret1.reload = true;
        turret2.reload = true;
        turret3.reload = true;
        turret4.reload = true;
        turret5.reload = true;
        turret6.reload = true;
        turret7.reload = true;
    }

    void Fire()
    {
        turret1.fire = true;
        turret2.fire = true;
        turret3.fire = true;
        turret4.fire = true;
        turret5.fire = true;
        turret6.fire = true;
        turret7.fire = true;
    }
}
