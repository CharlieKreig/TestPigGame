using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageScript : MonoBehaviour
{
    public float timer;

    void OnEnable()
    {
        timer = 30;
    }
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            PiglayerController Hero = collider.gameObject.GetComponent<PiglayerController>();
            if(Hero.Speed > 0.01)
            {
                Hero.Speed -= 0.01f; 
            }
            Hero.Cabbage++; 
            Hero.CabbageCounter.text = Hero.Cabbage  + "/10 Cabbages found!";
            Hero.Info.text = "Speed = " + (Hero.Speed*10).ToString("0.0");
            Hero.TextInfo.SetActive(true);
            if(Hero.Cabbage >= 10){Hero.Win.WinGame();}
            Destroy(gameObject);
        }
    }
}
