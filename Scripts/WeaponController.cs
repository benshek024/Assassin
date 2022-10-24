using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private bool isShootable = true;
    private bool isEmpty = false;
    private bool isFull = false;
    private bool isReloading = false;

    float timer;

    [Header("Weapon's Firing Pos, Range & Shooting Delay")]
    [SerializeField] private GameObject firePos;        // Position of where the bullet will be shooting from
    [SerializeField] private float gunRange;
    [SerializeField] private float timeBetweenShot;     // Shooting delay

    [Header("Weapon's Mag Size and Reload")]
    public float reloadTime;
    public int magSize;
    [HideInInspector] public int rounds;    // Make it kinda private-ish by not shown in Inspector to let UIController 
                                            // to access it and don't allow the value to be changed in the Inspector.

    [Header("Weapon's Visual Effects")]
    public ParticleSystem muzzleFlash;
    public LineRenderer bulletTrail;
    private float effectDisplayTime = 0.2f;

    [Header("Weapon's Sound Effects")]
    public GameObject soundEffectController;
    private AudioSource gunSound;
    public AudioClip shootingSound;
    public AudioClip reloadSound;
    public AudioClip emptySound;

    [Header("Place UIController")]
    public UIController uiController;

    // Start is called before the first frame update
    void Awake()
    {
        uiController = uiController.GetComponent<UIController>();
        gunSound = soundEffectController.GetComponent<AudioSource>();
        rounds = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (isReloading)    // Do nothing when reloading
            return;

        // Prevent rounds to drop below zero and set isEmpty bool to true
        // to stop player from shooting.
        if (rounds <= 0)
        {
            rounds = 0;
            isEmpty = true;
            isShootable = false;
        }

        if (timer >= timeBetweenShot * effectDisplayTime)
        {
            bulletTrail.enabled = false;
        }

        // If player shot at least one round, allow player to reload.
        // If not, prevent rounds goes larger than magSize after reload to avoid ammo overflow
        // and set isFull bool back to true to block player from reloading.
        if (rounds >= magSize)
        {
            rounds = magSize;
            isFull = true;
        }
        else
        {
            isFull = false;
        }
    }

    // START of Weapon Shooting region
    #region Weapon Shooting
    public void WeaponShoot()
    {
        if (isShootable && !isEmpty && !isReloading)
        {
            RaycastHit hit;

            if (Physics.Raycast(firePos.transform.position, firePos.transform.forward, out hit, gunRange))
            {
                Level1Enemy enemy = hit.transform.GetComponent<Level1Enemy>();
                if (enemy != null)
                {                       // Execute Die function from Enemy script if
                    enemy.Die();        // the game object have Enemy script attached.
                }

                EnemyBoss boss = hit.transform.GetComponent<EnemyBoss>();
                if (boss != null)
                {
                    boss.killBoss = true;
                    boss.Die();
                }

                Level2Enemy level2Enemy = hit.transform.GetComponent<Level2Enemy>();
                if (level2Enemy != null)
                {
                    level2Enemy.isDead = true;
                }

                Glass glass = hit.transform.GetComponent<Glass>();
                if (glass != null)
                {
                    glass.isBroken = true;
                }
            }

            bulletTrail.enabled = true;     // Show bullet trail
            bulletTrail.SetPosition(0, firePos.transform.position);
            bulletTrail.SetPosition(1, firePos.transform.position + firePos.transform.forward * gunRange);

            muzzleFlash.Play();     // Play muzzle flash effect for gun
            gunSound.PlayOneShot(shootingSound, 0.7f);  // Play shooting sound once

            rounds--;

            uiController.MinusAmmoText(1);  // Change ammoLeft variable by minus 1 in UIController to
                                                // update the ammoText.

            StartCoroutine(ShootingDelay());    // Execute ShootingDelay
        }

        if (!isShootable && isEmpty && !isReloading)
        {
            gunSound.PlayOneShot(emptySound, 0.7f);     // Play emptySound if gun is empty and not reloading
        }
    }

    IEnumerator ShootingDelay()
    {
        isShootable = false;
        yield return new WaitForSeconds(timeBetweenShot);   // Wait until the time of timeBetweenShot has passed
        isShootable = true;                                 // to set isShootable bool to true again.
        
    }
    #endregion
    // END of Weapon Shooting region

    // START of Weapon Reloading region
    #region Weapon Reloading
    public void WeaponReload()
    {
        if (!isFull)    // Start the reload coroutine if the isFull bool is not true
        {
            StartCoroutine(Reload(reloadTime));
        }
    }

    IEnumerator Reload(float reloadTime)
    {
        isFull = true;          // Prevent player from performing multiple reloads at the same time
        isReloading = true;     // Set isReloading bool to true to prevent player to shoot during reload
        isShootable = false;
        isEmpty = false;        // Set isEmpty bool back to false when reloading during 0 rounds

        gunSound.PlayOneShot(reloadSound, 0.8f);    // Play reload sound once
        rounds = magSize;                           // Set rounds back to magSize

        uiController.AddAmmoText(magSize);  // Update ammo text

        yield return new WaitForSeconds(reloadTime);    // When reloading, wait until reloadTime passed
        isReloading = false;                            // and set isReloading back to false to allow shooting.
        isShootable = true;
    }
    #endregion
    // END of Weapon Reload region
}
