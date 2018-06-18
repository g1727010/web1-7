using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigit2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    // Use this for initialization
    void Start () {
        this.rigit2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.rigit2D.velocity.y == 0)
        {
            this.rigit2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;

        if (Input.GetKey(KeyCode.RightArrow))
            key = 1;

        if (Input.GetKey(KeyCode.LeftArrow))
            key = -1;

        float speedx = Mathf.Abs(this.rigit2D.velocity.x);

        if (speedx < this.maxWalkSpeed)
        {
            this.rigit2D.AddForce(transform.right * key * this.walkForce);
        }

        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        this.animator.speed = speedx / 2.0f;

        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ゴール");
        SceneManager.LoadScene("ClearScence");
    }
}
