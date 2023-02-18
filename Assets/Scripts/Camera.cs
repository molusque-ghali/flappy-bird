using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour{
    public Transform birdTransform;
    Vector3 range;

    void Awake()
    {
        range = transform.position - birdTransform.position;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(range.x + birdTransform.position.x, transform.position.y, range.z + birdTransform.position.z);
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
 