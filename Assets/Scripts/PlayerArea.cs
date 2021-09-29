using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{

    public static int height = 20;
    public static int width = 10;
    public int player = 1;
    private Transform[,,] grid = new Transform[width, height,2];
    public bool Loose;

    public bool CheckMove(bool Player1, Transform sp)
    {
        foreach (Transform children in sp)
        {
            int X;
            if (Player1 == true)
            {
                player = 1;
                X = Mathf.RoundToInt(children.transform.position.x);
            }
            else
            {
                player = 0;
                X = Mathf.RoundToInt(children.transform.position.x) - 25;
            }
            int Y = Mathf.RoundToInt(children.transform.position.y);

            if (X < 0 || X >= width || Y < 0 || Y >= height)
            {
                return false;
            }

            if (grid[X, Y, player] != null)
            {
                return false;
            }
        }

        return true;
    }

    public void CheckForLines()
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
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i,player] == null)
            {
                return false;
            }
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i,player].gameObject);
            grid[j, i,player] = null;
        }
    }

    void GoDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y,player] != null)
                {
                    grid[j, y - 1,player] = grid[j, y, player];
                    grid[j, y,player] = null;
                    grid[j, y - 1, player].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    public void AddToGrid(bool Player1,Transform sp)
    {
        foreach (Transform children in sp)
        {
            int X;
            if (Player1 == true)
            {
                X = Mathf.RoundToInt(children.transform.position.x);
            }
            else
            {
                X = Mathf.RoundToInt(children.transform.position.x) - 25;
            }
            int Y = Mathf.RoundToInt(children.transform.position.y);

            if (Y >= height)
            {
                Loose = true;
            }
            else
            {
                grid[X, Y,player] = children;
            }
        }
    }
}
