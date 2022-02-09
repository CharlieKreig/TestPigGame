using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Objects;
    public GameObject[] Positions;
    public float timer;
    public float RespawnTime;
    // Start is called before the first frame update
    void Start()
    {
        RespawnTime = 8;
        timer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            int Pos = Random.Range(0, 45);
            int InstNumber = Random.Range(0, Objects.Count);
            GameObject Inst = Objects[InstNumber];
            Instantiate(Inst, Positions[Pos].transform.position, Quaternion.identity);
            Objects.RemoveAt(InstNumber);
            timer = RespawnTime;
            if(RespawnTime > 1)
            {
                RespawnTime -= 0.1f;
            }            
        }
    }
}
