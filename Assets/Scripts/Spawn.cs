using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public PileManager pile;
    
    public bool player1;
    public bool player2;
    public bool RandomIA; 
    // Start is called before the first frame update
    void Start()
    {
        GetShape();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetShape()
    {
        var shape = pile.pile[pile.pile.Length-1];
        shape.GetComponent<PlayerControl>().enabled = true;
        pile.pile[pile.pile.Length - 1] = null;
        pile.GoUp();
        
        if (player1)
        {
            shape.GetComponent<PlayerControl>().Player1 = true;
        }
        else if (player2)
        {
        }
        else if (RandomIA)
        {
            shape.GetComponent<IdiotControler>().enabled = true;
            shape.GetComponent<PlayerControl>().Random = true;
        }

        shape.position = transform.position;

    }
}
