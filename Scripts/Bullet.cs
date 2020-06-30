using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float lifeDuration = 1;

    Timer timer;

    void Start()
    {
        timer = gameObject.GetComponent<Timer>();
        timer.Duration = lifeDuration;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.Finished)
        {
            Destroy(this.gameObject);
        }
    }

    public void ApplyForce(Vector2 direction)
    {
        const float forceMagnitude = 10;
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
    }
}
