using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveController : MonoBehaviour
{
    public Animator playerAnimator;

    public GameObject wave1, wave2, wave3, wave4, wave5, wave6, wave7;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = playerAnimator.GetComponent<Animator>();
        wave2.SetActive(false);
        wave3.SetActive(false);
        wave4.SetActive(false);
        wave5.SetActive(false);
        wave6.SetActive(false);
        wave7.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (wave1.transform.childCount <= 0)
        {
            wave1.SetActive(false);
            StartCoroutine(WavesDelay(wave2, 9f));
            playerAnimator.SetBool("AdvanceS1", true);
        }

        if (wave2.transform.childCount <= 0)
        {
            wave2.SetActive(false);
            StartCoroutine(WavesDelay(wave3, 5f));
            playerAnimator.SetBool("AdvanceS1", false);
            playerAnimator.SetBool("AdvanceS2", true);
        }

        if (wave3.transform.childCount <= 0)
        {
            wave3.SetActive(false);
            StartCoroutine(WavesDelay(wave4, 14f));
            playerAnimator.SetBool("AdvanceS2", false);
            playerAnimator.SetBool("AdvanceS3", true);
        }

        if (wave4.transform.childCount <= 0)
        {
            wave4.SetActive(false);
            StartCoroutine(WavesDelay(wave5, 8f));
            playerAnimator.SetBool("AdvanceS3", false);
            playerAnimator.SetBool("AdvanceS4", true);
        }

        if (wave5.transform.childCount <= 0)
        {
            wave5.SetActive(false);
            StartCoroutine(WavesDelay(wave6, 22f));
            playerAnimator.SetBool("AdvanceS4", false);
            playerAnimator.SetBool("AdvanceS5", true);
        }

        if (wave6.transform.childCount <= 0)
        {
            wave6.SetActive(false);
            StartCoroutine(WavesDelay(wave7, 5f));
            playerAnimator.SetBool("AdvanceS5", false);
            playerAnimator.SetBool("AdvanceS6", true);
        }

        if (wave7.transform.childCount <= 0)
        {
            wave7.SetActive(false);
            StopAllCoroutines();
            playerAnimator.SetBool("AdvanceS6", false);
            playerAnimator.SetBool("AdvanceS7", true);

        }
    }

    IEnumerator WavesDelay(GameObject wave, float delay)
    {
        yield return new WaitForSeconds(delay);
        wave.SetActive(true);
    }
}
