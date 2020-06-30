using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;

    [SerializeField]
    List<Sprite> AsteroidSprites = new List<Sprite>();
    // Start is called before the first frame update

    Vector3 standartScale;
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = AsteroidSprites[Random.Range(0, AsteroidSprites.Count)];
        standartScale = transform.localScale;
    }
    
    public void Initialize(Direction movingDirection, Vector3 location)
    {
        gameObject.transform.position = location;

        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 2f;
      
        float lowerBound = 0;
        float upperBound = 2*Mathf.PI;
        if (movingDirection == Direction.Up)
        {
            lowerBound = Mathf.Deg2Rad * (90 - 15);
            upperBound = Mathf.Deg2Rad * (90 + 15);
        }
        if (movingDirection == Direction.Left)
        {
            lowerBound = Mathf.Deg2Rad * (180 - 15);
            upperBound = Mathf.Deg2Rad * (180 + 15);
        }
        if (movingDirection == Direction.Down)
        {
            lowerBound = Mathf.Deg2Rad * (270 - 15);
            upperBound = Mathf.Deg2Rad * (270 + 15);
        }
        if (movingDirection == Direction.Right)
        {
            lowerBound = Mathf.Deg2Rad * (360 - 15);
            upperBound = Mathf.Deg2Rad * (360 + 15);
        }
        float angle = Random.Range(lowerBound, upperBound);

        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        float torqueValue = Random.Range(-30, 31);

        StartMoving(direction, magnitude, torqueValue);
    }

    void StartMoving(Vector2 direction, float magnitude, float torqueValue)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddTorque(torqueValue);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Vector3 position = transform.position;
            Destroy(this.gameObject);
            Instantiate(prefabExplosion, position, Quaternion.identity);
            AudioManager.Play(AudioClipName.AsteroidHit);
            GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().AddPoints();
        }
    }
}
