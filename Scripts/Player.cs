using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int health = 100;
    public int currentHealth;

    private Level2Manager level2Manager;

    public Image hP;
    public TextMeshProUGUI healthTMP;
    private bool unEscape=true;

    // Start is called before the first frame update
    void Start()
    {
        //hP.fillAmount = 1f;
        currentHealth = health;
        healthTMP.text = "Health: " + currentHealth;
        level2Manager = GameObject.Find("LevelManager").GetComponent<Level2Manager>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            
        }
        hP.fillAmount = (float)currentHealth / (float)health;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Escape"&&unEscape)
        {
            level2Manager.isEscaped = true;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            unEscape = false;
        }
    }
}
