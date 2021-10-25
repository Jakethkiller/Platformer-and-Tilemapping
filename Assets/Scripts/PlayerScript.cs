using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text score;
    public Text livesText;
    public Text winText;

    private int scoreValue = 0;
    private int lives;
    

   

    // Start is called before the first frame update
    void Start()
    {
        
        lives = 3;
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        livesText.text = "Lives: "+ lives.ToString();
        SetLivesText ();
        winText.text = "";
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }
void SetLivesText()
    {
        livesText.text = "lives: " + lives.ToString();
        if (lives <= 0)
        {
            
        }
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            
            if( scoreValue == 4)
            {
                transform.position = new Vector2(371.4f, 6.4f);
                lives = 3;
                livesText.text = "lives: " + lives.ToString();
                
            }
            if( scoreValue == 8)
            {
                winText.text = "you win game made by Jacob Boone!";
            }
        }

        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();

            if(lives <= 0)
            {
                winText.text = "You lost the game made by jacob Boone";
                Destroy(this);
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 5), ForceMode2D.Impulse); //the 3 in this line of code is the player's "jumpforce," and you change that number to get different jump behaviors.  You can also create a public variable for it and then edit it in the inspector.
            }
        }
    }
    
}