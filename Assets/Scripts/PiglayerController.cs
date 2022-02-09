using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiglayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 MoveDirection;
    public float Speed;
    public Animator anim;
    public int Cabbage;
    public Text CabbageCounter;
    public GameObject Bomb;
    public GameObject Bang;
    public WinScript Win;
    public int BombCount;
    public Text BombTexts;
    public int BangRadius;
    public float unTouchTimer;
    public bool unTouch;
    public GameObject TextInfo;
    public Text Info;

    void Start()
    {
        Bang = Bomb.GetComponent<BombScript>().Bang;
        Bang.transform.localScale = new Vector3(BangRadius,BangRadius,BangRadius);
        Speed = 0.08f;
        anim = GetComponent<Animator>();
        MoveDirection = new Vector2(0f,0f);
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(unTouchTimer > 5){unTouchTimer -= Time.deltaTime; unTouch = true; gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,0f,1f);}
        else if(unTouchTimer > 0){unTouchTimer -= Time.deltaTime; gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,1f);}
        else{unTouch = false;gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);}
        rb.MovePosition(rb.position + MoveDirection);   
    }

    public void BombText()
    {
        BombTexts.text = "Bombs: " + BombCount;
    }
    public void BombSetup()
    {
        if(BombCount > 0)
        {
            BombCount--;
            Instantiate(Bomb, gameObject.transform.position, Quaternion.identity);
            BombText();
        }      
        else
        {
            Info.text = "You Don't Have any bombs";
            TextInfo.SetActive(true);
        } 
    }
    public void MoveUp()
    {
        anim.SetInteger("Direction", 1);
        MoveDirection = new Vector2(0f, Speed);
    }

    public void MoveDown()
    {
        anim.SetInteger("Direction", 2);
        MoveDirection = new Vector2(0f, -Speed);
    }

    public void MoveLeft()
    {
        anim.SetInteger("Direction", 3);
        MoveDirection = new Vector2(-Speed, 0f);
    }

    public void MoveRight()
    {
        anim.SetInteger("Direction", 4);       
        MoveDirection = new Vector2(Speed, 0f);
    }

    public void OnButtonUp()
    {
        anim.SetInteger("Direction", 0);
        MoveDirection = new Vector2(0f, 0f);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "bang" && unTouch == false)
        {
            Win.GameOver();
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Enemy" && unTouch == false)
        {
            Win.GameOver();
            Destroy(gameObject);
        }
    }

}
