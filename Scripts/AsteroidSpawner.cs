using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;

    float colliderRadious;

    Timer TimeToSpawn;

    const float minTimeToSpawn = 1f;
    const float maxTimeToSpawn = 2f;

    void Start()
    {
        TimeToSpawn = gameObject.GetComponent<Timer>();
        TimeToSpawn.Duration = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        TimeToSpawn.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeToSpawn.Finished)
        {
            TimeToSpawn.Duration = Random.Range(minTimeToSpawn, maxTimeToSpawn);
            TimeToSpawn.Run();

            Direction direction = (Direction)Random.Range(0, 4);

            if(direction == Direction.Left)
            {
                GameObject movingLeftAsteroid = Instantiate(prefabAsteroid);
                float y = Random.Range(ScreenUtils.ScreenBottom, ScreenUtils.ScreenTop);
                Vector3 rightPosition = new Vector3(ScreenUtils.ScreenRight + colliderRadious, y);
                movingLeftAsteroid.GetComponent<Asteroid>().Initialize(Direction.Left, rightPosition);
            }
            if(direction == Direction.Right)
            {
                GameObject movingRightAsteroid = Instantiate(prefabAsteroid);
                float y = Random.Range(ScreenUtils.ScreenBottom, ScreenUtils.ScreenTop);
                Vector3 leftPosition = new Vector3(ScreenUtils.ScreenLeft - colliderRadious, y);
                movingRightAsteroid.GetComponent<Asteroid>().Initialize(Direction.Right, leftPosition);
            }
            if(direction == Direction.Up)
            {
                GameObject movingUpAsteroid = Instantiate(prefabAsteroid);
                float x = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
                Vector3 bottomPosition = new Vector3(x, ScreenUtils.ScreenBottom + colliderRadious);
                movingUpAsteroid.GetComponent<Asteroid>().Initialize(Direction.Up, bottomPosition);
            }
            if(direction == Direction.Down)
            {
                GameObject movingDownAsteroid = Instantiate(prefabAsteroid);
                float x = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
                Vector3 topPosition = new Vector3(x, ScreenUtils.ScreenTop - colliderRadious);
                movingDownAsteroid.GetComponent<Asteroid>().Initialize(Direction.Down, topPosition);
            }
        }
    }
}
