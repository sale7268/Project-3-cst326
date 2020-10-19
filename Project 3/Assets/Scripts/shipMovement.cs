using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shipMovement : MonoBehaviour
{
    private Vector3 movement = Vector3.zero;
    private CharacterController controller;

    public GameObject bullet;
    public Transform shottingOffset;

    //Sounds
    public AudioSource soundEffect;
    public AudioClip fire;
    public AudioClip destroy;

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
            soundEffect.clip = fire;
            soundEffect.Play();
            Destroy(shot, 3f);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemyBullet(Clone)")
        {
            GetComponent<Animator>().SetTrigger("Destroy");
            soundEffect.clip = destroy;
            soundEffect.Play();
            Destroy(gameObject, 3.0f);
            Destroy(collision.gameObject);
            Debug.Log("Player loses life");
            Invoke("loadScene", 2.0f);
        }
        //StartCoroutine(loadNextScene());
    }
    //IEnumerator loadNextScene()
    //{
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        //yield return new WaitForSeconds(5);
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
   // }

    void loadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Invoke("Restart", 2.0f);
    }
    void Restart()
    {
        Application.LoadLevel(0);
    }
}



