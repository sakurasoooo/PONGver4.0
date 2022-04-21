using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControls : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public bool locked = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("Goball", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (locked) {
            rb2d.velocity = Vector2.zero;
            rb2d.position = Vector2.zero;
        }
 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player")) {
            Vector2 vel;
            vel.x =(rb2d.velocity.x / 2) + (other.collider.attachedRigidbody.velocity.x / 3);
            vel.y = rb2d.velocity.y + 0.1f;
            rb2d.velocity = vel;
        }
    }

    void Goball(){
        locked = false;
        float rand = Random.Range(0,2);
        if (rand < 1) {
            rb2d.AddForce(new Vector2(1,1) * 20);
        } else {
            rb2d.AddForce(new Vector2(-1,1) * 20);
        }
    }

    void ResetBall (){
        locked = true;
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame() {
        ResetBall();
        Invoke("Goball", 2);
    }
}
