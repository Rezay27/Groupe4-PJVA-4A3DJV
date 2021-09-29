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
        for (int i = 0; i < pile.Length; i++ ){
            pile[i].gameObject.GetComponent<PlayerControl>().enabled = false;
            pile[i].gameObject.GetComponent<PlayerControler2>().enabled = false;
            pile[i].gameObject.GetComponent<IdiotControler>().enabled = false;
        }
    }
    
    public void Switch(MonoBehaviour shape, int type)
    {
        float timer=0;

        if (type == 0)
        {
            shape.gameObject.GetComponent<PlayerControl>().swaped = false;
            shape.gameObject.GetComponent<PlayerControl>().enabled = false;
            
        }
        else if (type == 1)
        {
            shape.gameObject.GetComponent<PlayerControler2>().swaped = false;
            shape.gameObject.GetComponent<PlayerControler2>().enabled = false;
        }
        else if (type == 2)
        {
            shape.gameObject.GetComponent<IdiotControler>().swaped = false;
            shape.gameObject.GetComponent<IdiotControler>().enabled = false;
            timer = shape.gameObject.GetComponent<IdiotControler>().previousTime;
            shape.gameObject.GetComponent<IdiotControler>().previousTime = 0;
        }
        /*else if (type == 3)
        {
            shape.gameObject.GetComponent<PlayerControler2>().enabled = false;
        }*/

        var playerShapeP = shape.transform.position;
        var playerShapeR = shape.transform.rotation;


        shape.transform.position = pile[4].position;
        shape.transform.rotation = pile[4].rotation;
        pile[4].position = playerShapeP;
        pile[4].rotation = playerShapeR;

        


        if (type == 0)
        {
            pile[4].gameObject.GetComponent<PlayerControl>().enabled = true;
            pile[4].gameObject.GetComponent<PlayerControl>().swaped = true;
        }
        else if (type == 1)
        {
            pile[4].gameObject.GetComponent<PlayerControler2>().enabled = true;
            pile[4].gameObject.GetComponent<PlayerControler2>().swaped = true;
        }
        else if (type == 2)
        {
            pile[4].gameObject.GetComponent<IdiotControler>().enabled = true;
            pile[4].gameObject.GetComponent<IdiotControler>().swaped = true;
            pile[4].gameObject.GetComponent<IdiotControler>().previousTime = timer;
        }
        /*else if (type == 3)
        {
            pile[4].gameObject.GetComponent<PlayerControler2>().enabled = true;
        }*/
        
        pile[4] = shape.transform;

        

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
