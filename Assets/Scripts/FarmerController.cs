using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FarmerController : MonoBehaviour
{
    public float speed;
    public List<Transform> moveSpots;
    public int randomSpot;
    private float waitTime;
    public float startWaitTime;
    public bool FaceLeft;
    public Vector3 Direction;
    public Animator anim;
    public float DirtTimer;
    public float DirtSpeedMult;
    public float AngrySpeed;

    void Start()
    {
        AngrySpeed = 1;
        DirtSpeedMult = 1;
        anim = GetComponent<Animator>();
        waitTime = startWaitTime;
        randomSpot = 0;
    }
    void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        FaceLeft = !FaceLeft;
    }
    void Update()
    {
        if(DirtTimer > 0) {DirtTimer -= Time.deltaTime;}
        else{anim.SetBool("Dirty", false); DirtSpeedMult = 1;}
        if(Direction.x == 0){anim.SetBool("Move", false);}
        else{anim.SetBool("Move", true);}
        if(randomSpot > moveSpots.Count-1){randomSpot = moveSpots.Count-1;}
        if(randomSpot < 0){randomSpot = 0;}
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime * DirtSpeedMult * AngrySpeed);
        Direction = moveSpots[randomSpot].position - transform.position;
        Direction.Normalize();
        if(FaceLeft == true && Direction.x < 0)
        {
            Flip();
        }
        else if (FaceLeft == false && Direction.x > 0)
        {
            Flip();
        }
        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Count-1);  
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
