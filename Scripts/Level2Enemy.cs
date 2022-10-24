using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Level2Enemy : MonoBehaviour
{
    private Animator enemyAnimator;
    private NavMeshAgent enemyAgent;
    private AudioSource enemyAudioSource;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject movePoint;

    private Player _player;
    private float chanceToHit = 30f;

    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float nextFire = 0f;

    public ParticleSystem muzzleFlash;

    public bool isDead = false;
    [SerializeField] private bool isShoot = false, isRun = false;

    // Start is called before the first frame update
    void Start()
    {
        isRun = true;
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        enemyAudioSource = GetComponent<AudioSource>();
        _player = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (isRun)
            {
                EnemyRun();
            }

            if (!isShoot && Vector3.Distance(gameObject.transform.position, movePoint.transform.position) <= 0.2f)
            {
                EnemyShoot();
            }
        }

        if (isShoot && !isDead)
        {
            EnemyAim();
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                HitChance();
            }
        }

        if (_player.currentHealth <= 0)
        {
            isShoot = false;
        }

        if (isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        enemyAudioSource.Stop();
        muzzleFlash.Stop();
        isRun = false;
        isShoot = false;
        enemyAnimator.SetTrigger("Dead");  // Execute dead animation
        enemyAnimator.ResetTrigger("Shoot");
        enemyAnimator.SetBool("isRun", false);
        enemyAgent.ResetPath();
        Destroy(gameObject, 3f);
        Destroy(movePoint, 3f);
    }

    void HitChance()
    {
        int randNum = Random.Range(0, 101);
        int damage = 2;
        if (randNum <= chanceToHit)
        {
            _player.currentHealth -= damage;
            _player.healthTMP.text = "Health: " + _player.currentHealth;
        }
    }

    void EnemyShoot()
    {
        isShoot = true;
        isRun = false;
        enemyAnimator.SetBool("isRun", false);
        enemyAnimator.SetTrigger("Shoot");
        enemyAudioSource.Play();
        muzzleFlash.Play();
    }

    void EnemyAim()
    {
        Quaternion q = Quaternion.LookRotation(player.transform.position - gameObject.transform.position);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, q, 5 * Time.deltaTime);
    }

    void EnemyRun()
    {
        if (isRun)
        {
            enemyAgent.SetDestination(movePoint.transform.position);
            enemyAgent.speed = 1.5f;
            enemyAnimator.SetBool("isRun", true);
            isRun = true;
        }
    }
}
