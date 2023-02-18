using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner: MonoBehaviour{
    public float minV;
    public float maxV;
    public float distance;
    public GameObject bird;
    public GameObject coin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ObstacleParent")
        {
            Debug.Log("yes");
            float obstacleY = Random.Range(minV, maxV);
            Vector3 spawnPosition = new Vector3(bird.transform.position.x + distance, obstacleY, 0);
            collision.gameObject.transform.position = spawnPosition;
            coin.GetComponent<Animator>().Play("coin");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
