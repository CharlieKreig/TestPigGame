using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private float timer;
    public GameObject Bang;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer-=Time.deltaTime;   
        }       
        else
        {
            Destroy(gameObject);
   
        }
        if(timer > 0 && timer < 0.3f){Bang.SetActive(true);} 
    }
}
