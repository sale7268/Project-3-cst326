using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeDestroy : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)" || collision.gameObject.name == "EnemyBullet(Clone)")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
