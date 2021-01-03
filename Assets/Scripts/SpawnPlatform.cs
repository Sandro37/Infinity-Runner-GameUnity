using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>(); // lista das plataformas geradas na cena
    private List<Transform> currentsPlatforms = new List<Transform>(); // lista dos prefabs das plataformas
    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex;

    public float distance_platform;
    public float defaultValueDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < platforms.Count; i++)
        {
            Transform trans = Instantiate(platforms[i],new Vector2(i * defaultValueDistance, -5), transform.rotation).transform;
            currentsPlatforms.Add(trans);
            distance_platform += 30f;
        }

        currentPlatformPoint = currentsPlatforms[platformIndex].GetComponent<Platform>().final_point;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        float distance = player.position.x - currentPlatformPoint.position.x;

        if (distance >= 1)
        {
            recycle(currentsPlatforms[platformIndex].gameObject);
            platformIndex++;

            if(platformIndex > platforms.Count - 1)
            {
                platformIndex = 0;
            }
            currentPlatformPoint = currentsPlatforms[platformIndex].GetComponent<Platform>().final_point;
        }
    }
    private void recycle(GameObject platform)
    {
        platform.transform.position = new Vector2(distance_platform, -5);
        distance_platform += 30f;
    }
}
