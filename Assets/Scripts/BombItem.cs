using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PiglayerController>().BombCount++;
            col.gameObject.GetComponent<PiglayerController>().BombText();
            Destroy(gameObject);
        }
    }
}
