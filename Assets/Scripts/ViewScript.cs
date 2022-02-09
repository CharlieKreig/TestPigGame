using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewScript : MonoBehaviour
{
    public FarmerController Enemy;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(col.gameObject.GetComponent<PiglayerController>().unTouch == false)
            {
                Enemy.AngrySpeed = 2;
                Enemy.startWaitTime = 1;
                Enemy.anim.SetBool("Angry", true);
            }            
        }
    }
}
