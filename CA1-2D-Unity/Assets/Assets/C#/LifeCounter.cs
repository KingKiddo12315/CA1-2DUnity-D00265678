using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class LifeCounter : MonoBehaviour
{
    public Image[] images;
    public Button button;
    public TMP_Text congrats;
    void Start()
    {
        button = GameObject.Find("Button").GetComponent<Button>();
        button.gameObject.SetActive(false);
        congrats = GameObject.Find("victory").GetComponent<TMP_Text>();
        congrats.gameObject.SetActive(false);
    }

    public void UpdateLifes(int lifes)
    {
        if (lifes == 3)
        {
            images[0].enabled = true;
            images[1].enabled = true;
            images[2].enabled = true;
        }
        else if (lifes == 2)
        {
            images[0].enabled = false;
            images[1].enabled = true;
            images[2].enabled = true;
        }
        else if (lifes == 1)
        {
            images[0].enabled = false;
            images[1].enabled = false;
            images[2].enabled = true;
        }
        else if (lifes == 0)
        {
            images[0].enabled = false;
            images[1].enabled = false;
            images[2].enabled = false;
        }
    }
    public void ToggleRestart(int lifes)
    {
        if (lifes <= 0)
        {
            button.gameObject.SetActive(true);
        }
    }
    public void victoryText(bool victory)
    {
               button.gameObject.SetActive(true);
        congrats.gameObject.SetActive(victory);
    }
}
