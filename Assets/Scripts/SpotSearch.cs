using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotSearch : MonoBehaviour
{
    public FarmerController Farmer;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Spot")
        {
            Farmer.moveSpots.Add(col.gameObject.transform);
        }
    }
    void OnTriggerExit2D(Collider2D col2)
    {
        if(col2.gameObject.tag == "Spot")
        {
            Farmer.moveSpots.Remove(col2.gameObject.transform);
        }
    }

}
