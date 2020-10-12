using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static Boolean goLeft = false;
    static Boolean goDown = false;
    private Vector3 movement = Vector3.zero;
    float x,y;
    public float speed = 3f;
    private int timer = 300;

    public GameObject EnemyBullet;
    public Transform shottingOffset;

    private void Start()
    {
        x = transform.position.x;
    }
    void Update()
    {
        if (goLeft)
        {
            x -= speed * Time.deltaTime;
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
        else
        {
            x += speed * Time.deltaTime;
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        timer -= 1;
        if(timer < 2)
        {
            int numChoosen = UnityEngine.Random.Range(0, 10);

            if(numChoosen == 2)
            {
                GameObject shot = Instantiate(EnemyBullet, shottingOffset.position, Quaternion.identity);
                Debug.Log("Bang!");

                Destroy(shot, 3f);
            }
            timer = 300;
        }
        speed += 0.0001f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            if (gameObject.name == "Alien1")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerScored(40);
            }
            else if (gameObject.name == "Alien2")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerScored(30);
            }
            else if (gameObject.name == "Alien3")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerScored(20);
            }
            else if (gameObject.name == "Alien4")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerScored(10);
            }
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LeftWall")
        {
            goLeft = false;
        }
        if (collision.gameObject.name == "RightWall")
        {
            goLeft = true;
            y = transform.position.y - 1;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
    }

}
