using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public WeaponController weaponController;
    private int ammoLeft;
    private int ammoSize;
    public TextMeshProUGUI ammoTMP;
    public Image ammoLogo;
    public GameObject reload;

    // Start is called before the first frame update
    void Start()
    {
        weaponController = weaponController.GetComponent<WeaponController>();
        ammoLeft = weaponController.rounds;
        ammoSize = weaponController.magSize;
        ammoTMP.text = "Ammo: " + ammoLeft + "/" + ammoSize;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ammoLeft > 0)
        {
            reload.SetActive(false);
        }

        if (ammoLeft <= 0)  // Prevent ammoLeft to go below 0
        {
            ammoLeft = 0;
            reload.SetActive(true);
        }
    }

    public void MinusAmmoText(int minusRound)
    {
        ammoLeft -= minusRound;
        ammoLogo.fillAmount = (float)ammoLeft / (float)ammoSize;
        //ammoTMP.text = "Ammo: " + ammoLeft + "/" + ammoSize;   // Update the text
    }

    public void AddAmmoText(int ammo)
    {
        ammoLeft = ammo;
        ammoLogo.fillAmount = (float)ammoLeft / (float)ammoSize;
        //ammoTMP.text = "Ammo: " + ammoLeft + "/" + ammoSize;
        // Prevent ammoLeft goes larger than ammoSize after weapon is reloaded.
        if (ammoLeft >= ammoSize)
        {
            ammoLeft = ammoSize;
        }
    }
}
