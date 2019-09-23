using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;

    public Text countText;
    public Text winText;

    public Text playerLives;
    public Text loseText;
    public GameObject player;
    

    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    void Start()
        //varible set
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text="";
        loseText.text = "";
        SetCountText ();
        SetPlayerLives();


    }
    void FixedUpdate()
    //Players Movement
    {
        float moveHorizonal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizonal, moveVertical);
        rb2d.AddForce (movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

  
    void OnTriggerEnter2D(Collider2D other)
    {
        //Pick up counting
         if (other.gameObject.CompareTag("PickUp"))
            {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            }

        //NEW Enemy life count
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetPlayerLives();
        }


    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count>= 20)
        {
            winText.text = "You win! Game created by Erica!";
            Destroy(player);
        }
        if (count == 12)
            //equal to the number pickups on the first playfield
           {
            transform.position = new Vector2(50.0f, 50.0f); 
           }
    }

    void SetPlayerLives()
    {
        playerLives.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            loseText.text = "You Lose, please try again. By: Erica";
            Destroy(player);

        }
    }
}

