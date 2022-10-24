using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class Test : MonoBehaviour
{
    public GameObject firePos;
    public float range = 100f;
    public Transform mainCam;

    public GameObject weaponHolder;
    public GameObject soundEffectController;
    public AudioSource gunSound;
    public Animator gunAnimator;
    //private bool isScoped = false;

    [SerializeField] private float timeBetweenShot = 1.5f;
    private bool isShootable = true;

    private void Awake()
    {
        weaponHolder = GameObject.Find("WeaponHolder");
        gunAnimator = weaponHolder.GetComponent<Animator>();
        soundEffectController = GameObject.Find("SoundEffectController");
        gunSound = soundEffectController.GetComponent<AudioSource>();
    }

    public void onAimEvent()
    {
        Debug.Log("Aiming!");
    }

    public void onExitAimEvent()
    {
        Debug.Log("Not Aiming!");
    }

    public void onReloadEvent()
    {
        Debug.Log("Reloading!");
    }

    public void onExitReloadEvent()
    {
        Debug.Log("Not Reloading!");
    }

    public void onFireEvent()
    {
        Debug.Log("Firing!");
    }

    public void onExitFireEvent()
    {
        Debug.Log("Not Firing!");
    }

    public void Shoot()
    {
        if (isShootable)
        {
            RaycastHit hit;
            gunSound.Play();
            if (Physics.Raycast(firePos.transform.position, firePos.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
            }
            isShootable = false;
            StartCoroutine(ShootingDelay());
        }
    }

    IEnumerator ShootingDelay()
    {
        yield return new WaitForSeconds(timeBetweenShot);
        isShootable = true;
    }

    public void ScopeIn()
    {
        gunAnimator.SetBool("isScoped", true);
    }

    public void ScopeOut()
    {
        gunAnimator.SetBool("isScoped", false);
    }
}
