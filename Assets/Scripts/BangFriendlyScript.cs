using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangFriendlyScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            FarmerController Enemy = col.gameObject.GetComponent<FarmerController>();
            Enemy.anim.SetBool("Dirty", true);
            Enemy.DirtSpeedMult = 0.1f;
            Enemy.DirtTimer = 15;
            Enemy.AngrySpeed = 1;
            Enemy.startWaitTime = 5;
            Enemy.anim.SetBool("Angry", false);
        }
    }
}
