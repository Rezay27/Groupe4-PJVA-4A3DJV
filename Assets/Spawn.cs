using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] Shape;
    // Start is called before the first frame update
    void Start()
    {
        NewShape();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewShape()
    {
        Instantiate(Shape[Random.Range(0, Shape.Length)], transform.position, Quaternion.identity);
    }
}
