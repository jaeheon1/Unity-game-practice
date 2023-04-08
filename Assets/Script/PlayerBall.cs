using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    float jumpPower = 10;
    public int itemCount;
    Rigidbody rigid;
    bool isJump;
    AudioSource audio;

   
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody>();
        isJump = false;
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump")&&!isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0),ForceMode.Impulse);
           

        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Floor")
        {
            isJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
        }
    }
}
