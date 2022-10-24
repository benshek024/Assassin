using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1TextBox : MonoBehaviour
{
    public GameObject textBox, controller, ammo, gameOver;
    public Text text;
    private int textPlay1 = 0, textPlay2 = 0;



    // Start is called before the first frame update
    void Start()
    {
        controller.SetActive(false);
        ammo.SetActive(false);
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

                    text.text = ("18:36 10/2/20XX \n Outside the private villa of an arms dealer");
                    textPlay1++;
                    break;
                }
            case 1:
                {

                    text.text = ("Mission: Assassinate the owner of the villa \n The arms dealer");
                    textPlay1++;
                    break;
                }

            case 2:
                {

                    text.text = ("Tip: You can lure the main target to appear by killing the scene guard.");
                    textPlay1++;
                    break;
                }
            default:
                {

                    textPlay1 = 0;
                    controller.SetActive(true);
                    ammo.SetActive(true);
                    textBox.SetActive(false);
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
                    if (MissionData.mission == 1)
                    {
                        text.text = ("18:36 10/2/20XX Mission success, is now ready to evacuate.");
                    }
                    if (MissionData.mission == 2)
                    {
                        text.text = ("18:36 10/2/20XX Mission failed, target lost.");
                    }
                    if (MissionData.mission == 0)
                    {
                        text.text = ("The guard notified the reinforcements and I felt unable to escape.");
                        textPlay2 += 5;
                        //gameOver.SetActive(true);
                    }
                    textPlay2++;
                    break;
                }
            case 1:
                {

                    text.text = ("This is? Drone? Why is it here?");
                    textPlay2++;
                    break;
                }

            case 2:
                {

                    text.text = ("Damn, the position has been exposed, and requesting support.");
                    textPlay2++;
                    break;
                }
            default:
                {
                    controller.SetActive(true);
                    textBox.SetActive(false);
                    CancelInvoke("TextPlay2");
                    break;
                }
        }
    }

}
