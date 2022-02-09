using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public int BonusType; // 1 = Speed Bonus; 2 = Bomb Radius Bonus; 3 = Untouchable Pig Bonus;
    private float timer;

    void OnEnable()
    {
        timer = 10;
    }
    void Update()
    {
        if(timer > 0){timer -= Time.deltaTime;}
        else{Destroy(gameObject);}
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PiglayerController Hero = col.gameObject.GetComponent<PiglayerController>();
            switch(BonusType)
            {
                case 1:
                Hero.Speed+=0.02f;
                Hero.Info.text = "Speed = " + (Hero.Speed*10).ToString("0.0");
                break;
                case 2:
                Hero.BangRadius++;
                Hero.Bang.transform.localScale = new Vector3(Hero.BangRadius,Hero.BangRadius,Hero.BangRadius);
                Hero.Info.text = "Bang Size: " + Hero.BangRadius;
                break;
                case 3:
                Hero.unTouchTimer = 20;
                Hero.Info.text = "You are SuperPig!";
                break;
            }
            Hero.TextInfo.SetActive(true);
            Destroy(gameObject);
        }
    }
}
