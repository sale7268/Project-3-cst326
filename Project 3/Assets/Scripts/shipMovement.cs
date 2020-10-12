using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
    private Vector3 movement = Vector3.zero;
    private CharacterController controller;

    public GameObject bullet;
    public Transform shottingOffset;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        movement = transform.TransformDirection(movement);

        movement *= 8;
        controller.Move(movement * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");

            Destroy(shot, 3f);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EnemyBullet(Clone)")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("Player loses life");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemyBullet(Clone)")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("Player loses life");
        }
    }
}
