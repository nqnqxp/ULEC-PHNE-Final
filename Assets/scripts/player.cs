using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

	public float speed = 0f;

	Animator animator;
    SpriteRenderer sprite;

	void Start()
	{
	    animator = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
	}


    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
			
			//animator.SetBool("isWalking", true);
			sprite.flipX = false;
		}
		
		if (Input.GetKeyUp(KeyCode.RightArrow)) {
			//animator.SetBool("isWalking", false);
		}
		
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
			
			//animator.SetBool("isWalking", true);
            sprite.flipX = true;
		}
		
		if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			//animator.SetBool("isWalking", false);
		}
		
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
			
			//animator.SetBool("isWalking", true);
		}
		
		if (Input.GetKeyUp(KeyCode.UpArrow)) {
			//animator.SetBool("isWalking", false);
		}
		
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
			
			//animator.SetBool("isWalking", true);
		}
		
		if (Input.GetKeyUp(KeyCode.DownArrow)) {
			animator.SetBool("isWalking", false);
		}
		
	}
}