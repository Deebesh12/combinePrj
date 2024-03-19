using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int score;
    public int health;
    public int jumpforce;
    private Rigidbody2D rigidbody;
    public Text scoretext;
    public AudioSource coinAudio;

    // Start is called before the first frame update
    void Start()
    {
        health=100;
        rigidbody=GetComponent<Rigidbody2D>();
        scoretext.text="score-"+score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }
    void OnCollisionEnter2D(Collision2D colloider)
    {
        if(colloider.gameObject.tag == "coin")
        {
            score++;
            coinAudio.Play();
            scoretext.text="score-"+score.ToString();
            Destroy(colloider.gameObject);
        }
        else if(colloider.gameObject.tag == "spike")
        {
            health-=10;
        }
    }
    void jump()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpforce);
    }
}
