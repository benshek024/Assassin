using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3TextBox : MonoBehaviour
{
    public GameObject textBox, boxes,turerts,GM, gloves, levelLoader;
    public Text text;
    private int textPlay1 = 0, textPlay2 = 0, textPlay3 = 0, textPlay4 = 0, textPlay5 = 0;
    public GameObject gameEnd;
    public GameObject player;




    // Start is called before the first frame update
    void Start()
    {
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

                    text.text = ("05:21 11/2/20XX \n In the warehouse that became the base");
                    textPlay1++;
                    break;
                }
            case 1:
                {

                    text.text = ("Supporter: Good morning, are you sleeping well?");
                    textPlay1++;
                    break;
                }

            case 2:
                {

                    text.text = ("Supporter: There are several remote control turrets in the warehouse, you can activate them in advance to prevent emergencies.");
                    textPlay1++;
                    break;
                }
            default:
                {

                    textPlay1 = 0;
                    textBox.SetActive(false);
                    CancelInvoke("TextPlay1");
                    boxes.SetActive(false);
                    player.GetComponent<Animator>().SetTrigger("w1");
                    break;
                }
        }
    }

    public void OpenTextPlay2()
    {
        InvokeRepeating("TextPlay2", 1, 2);
    }
    void TextPlay2()
    {
        switch (textPlay2)
        {
            case 0:
                {
                    textBox.SetActive(true);
                    text.text = ("Okay! Let me try.");
                    textPlay2++;
                    break;
                }

            default:
                {
                    textBox.SetActive(false);
                    player.GetComponent<Animator>().SetTrigger("w2");
                    turerts.GetComponent<Animator>().SetTrigger("setup");
                    CancelInvoke("TextPlay2");

                    break;
                }
        }
    }

    public void OpenTextPlay3()
    {
        InvokeRepeating("TextPlay3", 1, 2);
    }

    void TextPlay3()
    {
        switch (textPlay3)
        {
            case 0:
                {
                    textBox.SetActive(true);
                    text.text = ("Supporter: If you want to start the turret, you can use the gloves in the box.");
                    textPlay3++;
                    break;
                }
            case 1:
                {

                    text.text = ("Gloves? It always feels cool.");
                    textPlay3++;
                    break;
                }

            case 2:
                {

                    text.text = ("Supporter: This glove can issue commands to control the turret, and it also emits laser light to help the turret aim.");
                    textPlay3++;
                    break;
                }
            default:
                {
                    textBox.SetActive(false);
                    GM.GetComponent<GameManager>().s2 = true;
                    player.GetComponent<Animator>().SetTrigger("w3");
                    CancelInvoke("TextPlay3");
                    break;
                }
        }
    }

    public void OpenTextPlay4()
    {
        InvokeRepeating("TextPlay4", 1, 2);
    }
    void TextPlay4()
    {
        switch (textPlay4)
        {
            case 0:
                {
                    textBox.SetActive(true);
                    text.text = ("I didn't expect it to come so soon.");
                    textPlay4++;
                    break;
                }
            case 1:
                {

                    text.text = ("Enemies: You attacked our boss and killed our men, now you want to pay for it.");
                    textPlay4++;
                    break;
                }

            case 2:
                {

                    text.text = ("It's time to experience the power of new weapons.");
                    textPlay4++;
                    break;
                }
            default:
                {
                    textBox.SetActive(false);
                    gloves.SetActive(true);
                    CancelInvoke("TextPlay4");
                    break;
                }
        }
    }

    public void OpenTextPlay5()
    {
        InvokeRepeating("TextPlay5", 5, 2);
    }
    void TextPlay5()
    {
        switch (textPlay5)
        {
            case 0:
                {
                    gameEnd.SetActive(true);
                    textPlay5++;
                    break;
                }
            case 1:
                {
                    levelLoader.GetComponent<LevelLoader>().RestartLevel(0); 
                    textPlay5++;
                    break;
                }

            default:
                {

                    CancelInvoke("TextPlay5");
                    break;
                }
        }
    }
}
