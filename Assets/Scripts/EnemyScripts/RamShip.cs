using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : MonoBehaviour
{
    public MovingDirections direction;
    public SpriteRenderer shipRenderer;
    private float heal = 100f;
    private float speed = 0.15f;
    private float halfWidth;
    private float halfHeight;
    void Start()
    {
        halfWidth = shipRenderer.sprite.bounds.size.x / 2;
        halfHeight = shipRenderer.sprite.bounds.size.y / 2;
    }

    public void FixedUpdate()
    {
        switch(direction)
        {
            case MovingDirections.left:
            MovingLeft();
            break;
            case MovingDirections.right:
            MovingRight();
            break;
            case MovingDirections.up:
            MovingUp();
            break;
            case MovingDirections.down:
            MovingDown();
            break;
        }
    }
    private void MovingRight()
    {
        Vector3 newPosition = new Vector3(transform.position.x + speed, transform.position.y, 0);
        Vector3 checkPosition = newPosition;
        checkPosition.x += halfWidth;
        if(Helpers.IsPositionOnScreen(checkPosition))
        {
            transform.position = newPosition;
        }else
        {
            if (transform.position.y > 0)
            {
                direction = MovingDirections.down;
            }else
            {
                direction = MovingDirections.up;
            }
        }
    }
    private void MovingLeft()
    {
        Vector3 newPosition = new Vector3(transform.position.x - speed, transform.position.y, 0);
        Vector3 checkPosition = newPosition;
        checkPosition.x -= halfWidth;
        if(Helpers.IsPositionOnScreen(checkPosition))
        {
            transform.position = newPosition;
        }else
        {
            if (transform.position.y > 0)
            {
                direction = MovingDirections.down;
            }else
            {
                direction = MovingDirections.up;
            }
        }
    }
    private void MovingUp()
    {
        
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + speed, 0);
        Vector3 checkPosition = newPosition;
        checkPosition.y += halfHeight;
        if(Helpers.IsPositionOnScreen(checkPosition))
        {
            transform.position = newPosition;
        }else
        {
            if (transform.position.x > 0)
            {
                direction = MovingDirections.left;
            }else
            {
                direction = MovingDirections.right;
            }
        }
    }
    private void MovingDown()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y - speed, 0);
        Vector3 checkPosition = newPosition;
        checkPosition.y -= halfHeight;
        if(Helpers.IsPositionOnScreen(checkPosition))
        {
            transform.position = newPosition;
        }else
        {
            if (transform.position.x > 0)
            {
                direction = MovingDirections.left;
            }else
            {
                direction = MovingDirections.right;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObject = collider.gameObject ;
        PlayerBullet bulletObject = otherObject.GetComponent<PlayerBullet>();
        if(bulletObject != null)
        {
            heal -= bulletObject.damage;
            Destroy(otherObject);
            if(heal <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
