using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Vector3 RotatePoint;
    private float previousTime;
    public float fallTime;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];
    public bool Loose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!CheckMove())
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!CheckMove())
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.RotateAround(transform.TransformPoint(RotatePoint), new Vector3(0,0,1), 90);
            if (!CheckMove())
            {
                transform.RotateAround(transform.TransformPoint(RotatePoint), new Vector3(0, 0, 1), -90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.RotateAround(transform.TransformPoint(RotatePoint), new Vector3(0, 0, 1), -90);
            if (!CheckMove())
            {
                transform.RotateAround(transform.TransformPoint(RotatePoint), new Vector3(0, 0, 1), 90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            FindObjectOfType<PileManager>().Switch(this, 0);
            if (!CheckMove())
            {
                FindObjectOfType<PileManager>().Switch(this, 0);
            }
        }


        if (Time.time - previousTime > (Input.GetKey(KeyCode.S) ? fallTime/10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!CheckMove())
            {
                transform.position += new Vector3(0, 1, 0);
                AddToGrid();
                CheckForLines();
                this.enabled = false;
                if (!Loose)
                {
                    GameObject.FindGameObjectWithTag("player1").GetComponent<Spawn>().GetShape();
                }
                
            }
            previousTime = Time.time;
        }
    }

    bool CheckMove()
    {
        foreach(Transform children in transform)
        {
            int X = Mathf.RoundToInt(children.transform.position.x);
            int Y = Mathf.RoundToInt(children.transform.position.y);

            if (X < 0 || X >= width || Y < 0 || Y >= height)
            {
                return false;
            }

            if (grid[X, Y] != null)
            {
                return false;
            }
        }

       

        return true;
    }

    void CheckForLines()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                GoDown(i);
            }
        }
    }

    bool HasLine(int i)
    {
        for (int j=0; j < width; j++)
        {
            if (grid[j,i]== null)
            {
                return false;
            }
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j <width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void GoDown(int i)
    {
        for (int y = i; y< height; y++)
        {
            for (int j = 0; j< width; j++)
            {
                if(grid[j,y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int X = Mathf.RoundToInt(children.transform.position.x);
            int Y = Mathf.RoundToInt(children.transform.position.y);

            if (Y >= height)
            {
                Loose = true;
            }
            else
            {
                grid[X, Y] = children;
            }
            
        }
    }

    
}
