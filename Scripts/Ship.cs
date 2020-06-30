using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    // thust force direction and value
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 3;

    float colliderRadious;


    [SerializeField]
    GameObject prefabBullet;

    [SerializeField]
    GameObject prefabExplosion;

    [SerializeField]
    GameObject HUD;

    
    // rotation speed
    const float RotateDegreesPerSecond = 100;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        colliderRadious = collider.radius;
  
    }

    // Update is called once per frame
    void Update()
    {
        // checks rotaion input and rotates the ship
        float rotationInput= Input.GetAxis("Rotate");
        if(rotationInput != 0)
        {
            // rotation angle
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if(rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            // rotates an object
            transform.Rotate(Vector3.forward, rotationAmount);
            // chages thrus direction
            thrustDirection.x = Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.z - 90));
            thrustDirection.y = Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.z - 90));
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Vector3 bulletPosition = new Vector3();
            bulletPosition.x = transform.position.x +  Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.z - 90)) * colliderRadious;
            bulletPosition.y = transform.position.y + Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.z - 90)) * colliderRadious;
            GameObject bullet = Instantiate(prefabBullet, bulletPosition, Quaternion.identity);
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection);

            AudioManager.Play(AudioClipName.PlayerShot);
        }
    }

    void FixedUpdate()
    {
        // checks thrust input and applies it
        if (Input.GetAxis("Thrust") > 0)
        {
            rigidbody2D.AddForce(ThrustForce * thrustDirection);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "AsteroidPiece")
        {
            Vector3 position = transform.position;
            Destroy(gameObject);
            Instantiate(prefabExplosion, position, Quaternion.identity);
            HUD.GetComponent<HUD>().StopGameTimer();
            AudioManager.Play(AudioClipName.PlayerDeath);
        }
    }
}
