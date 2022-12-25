using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage = 25;
    float speed = 0.3f;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed, 0);

        if(transform.position.y <= -7)
        {
            Destroy(gameObject);
        }
    }
}
