using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeCounter : MonoBehaviour
{
    //public Text scoreText;
    public Image[] images;
    public Button button;
    //public void SetScore(int score)
    //{
    //    scoreText.text = score.ToString();
    //}
    void Start()
    {
        button = GameObject.Find("Button").GetComponent<Button>();
        button.gameObject.SetActive(false);
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
}
