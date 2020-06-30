using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWraper : MonoBehaviour
{
    float colliderRadious;

    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        colliderRadious = collider.radius;
    }

    // wraps an object when it becomes invisible
    void OnBecameInvisible()
    {
        Vector3 position = transform.position;
        if (position.x + colliderRadious > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenLeft + colliderRadious;
        }
        if (position.x - colliderRadious < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenRight - colliderRadious;
        }
        if (position.y + colliderRadious > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenBottom + colliderRadious;
        }
        if (position.y - colliderRadious < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenTop - colliderRadious;
        }
        transform.position = position;
    }
}
