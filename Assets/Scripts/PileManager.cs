using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PileManager : MonoBehaviour
{
    public Transform[] pile = new Transform[5];
    public GameObject[] Shape;
    
    void Awake()
    {
        for (int i = 0; i < pile.Length; i++)
        {
            pile[i] = NewShape();
            pile[i].position = new Vector3(pile[i].position.x, pile[i].position.y + 4 * i, pile[i].position.z);
        }
        
    }

    private void Update()
    {
        
    }

    public void GoUp()
    {
        for (int i = 3; i >= 0; i--)
        {
            pile[i+1] = pile[i];
            pile[i+1].position = new Vector3(pile[i].position.x, pile[i].position.y + 4, pile[i].position.z);
        }

        pile[0] = NewShape();
    }

    public Transform NewShape()
    {
        return Instantiate(Shape[Random.Range(0, Shape.Length)], transform.position+ new Vector3(0,1,0), Quaternion.identity).transform;
    }
}
