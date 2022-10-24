using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2TextBox : MonoBehaviour
{
    public GameObject textBox, controller, ammo, hP, enemies;
    public Text text;
    private int textPlay1 = 0, textPlay2 = 0;
    public GameObject gameOver;




    // Start is called before the first frame update
    void Start()
    {
        controller.SetActive(false);
        ammo.SetActive(false);
        hP.SetActive(false);
        InvokeRepeating("TextPlay1", 3, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TextPlay1()
    {
        switch (textPlay1)
        {
            case 0:
                {
                    textBox.SetActive(true);

                    text.text = ("21:13 10/2/20XX \n In a downtown street");
                    textPlay1++;
                    break;
                }
            case 1:
                {

                    text.text = ("Supporter: The organization has arranged a vehicle to meet in the alley on the other side of the park.");
                    textPlay1++;
                    break;
                }

            case 2:
                {

                    text.text = ("Okay! The chasers have arrived, so troublesome.");
                    textPlay1++;
                    break;
                }
            default:
                {

                    textPlay1 = 0;
                    controller.SetActive(true);
                    ammo.SetActive(true);
                    hP.SetActive(true);
                    textBox.SetActive(false);
                    enemies.SetActive(true);
                    CancelInvoke("TextPlay1");
                    break;
                }
        }
    }

    public void OpenTextPlay2()
    {
        InvokeRepeating("TextPlay2", 3, 2);
    }
    void TextPlay2()
    {
        switch (textPlay2)
        {
            case 0:
                {
                    textBox.SetActive(true);
                    ammo.SetActive(false);
                    hP.SetActive(false);
                    text.text = ("I can rest assured for the time being, I hope I can get rid of them.");
                    textPlay2++;
                    print("1");
                    break;
                }
            case 1:
                {

                    text.text = ("Supporter: I will lead you to one of our strongholds to avoid chasers.");
                    textPlay2++;
                    print("2");
                    break;
                }

            case 2:
                {

                    text.text = ("Supporter: Your appearance has been exposed and they will find you sooner or later.");
                    textPlay2++;
                    print("3");
                    break;
                }
            default:
                {
                    controller.SetActive(true);
                    textBox.SetActive(false);
                    CancelInvoke("TextPlay2");
                    print("4");
                    break;
                }
        }
    }

}
