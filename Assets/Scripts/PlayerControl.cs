using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Vector3 RotatePoint;
    private float previousTime;
    public float fallTime;
    public bool swaped;
    public bool Player1;
    public bool Random;

    // Update is called once per frame
    void Update()
    {
        if (swaped)
        {
            if (!FindObjectOfType<PlayerArea>().CheckMove(Player1, transform))
            {
                FindObjectOfType<PileManager>().Switch(this, 0);
            }
            else
            {
                swaped = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Q) && Player1 == true)
        {
            FindObjectOfType<Action>().MoveLeft(transform);
            if (!FindObjectOfType<PlayerArea>().CheckMove(Player1, transform))
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) && Player1 == true)
        {
            FindObjectOfType<Action>().MoveRight(transform);
            if (!FindObjectOfType<PlayerArea>().CheckMove(Player1, transform))
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) && Player1 == true)
        {
            FindObjectOfType<Action>().RotateLeft(transform, RotatePoint);
            if (!FindObjectOfType<PlayerArea>().CheckMove(Player1, transform))
            {
                transform.RotateAround(transform.TransformPoint(RotatePoint), new Vector3(0, 0, 1), -90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && Player1 == true)
        {
            FindObjectOfType<Action>().RotateRight(transform, RotatePoint);
            if (!FindObjectOfType<PlayerArea>().CheckMove(Player1, transform))
            {
                transform.RotateAround(transform.TransformPoint(RotatePoint), new Vector3(0, 0, 1), 90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Z) && transform.position.y != 19 && Player1 == true)
        {
            FindObjectOfType<PileManager>().Switch(this, 0);
        }


        if (Time.time - previousTime > (Input.GetKey(KeyCode.S) ? fallTime/10 : fallTime) && Player1 == true)
        {
            transform.position += new Vector3(0, -1, 0);
            if (!FindObjectOfType<PlayerArea>().CheckMove(Player1, transform))
            {
                transform.position += new Vector3(0, 1, 0);
                FindObjectOfType<PlayerArea>().AddToGrid(Player1, transform);
                FindObjectOfType<PlayerArea>().CheckForLines();
                this.enabled = false;
                if (!FindObjectOfType<PlayerArea>().Loose)
                {
                    GameObject.FindGameObjectWithTag("player1").GetComponent<Spawn>().GetShape();
                }
                else
                {
                    if (Random == false)
                    {
                        FindObjectOfType<Menu>().Winner = "player2";
                    }
                    else
                    {
                        FindObjectOfType<Menu>().Winner = "Random";
                    }
                    FindObjectOfType<Menu>().End();
                    Debug.LogWarningFormat("Perdu player1");
                    Time.timeScale = 0;
                }

            }
            previousTime = Time.time;
        }
        if(Input.GetKeyDown(KeyCode.Keypad1) && Player1 == false && Random == false)
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!FindObjectOfType<PlayerArea>().CheckMove(Player1, transform))
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3) && Player1 == false && Random == false)
        {
            transform.position += new Vector3(1, 0, 0);
            if (!FindObjectOfType<PlayerArea>().CheckMove(Player1, transform))
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4) && Player1 == false && Random == false)
        {
            transform.RotateAround(transform.TransformPoint(RotatePoint), new Vector3(0, 0, 1), 90);
            if (!FindObjectOfType<PlayerArea>().CheckMove(Player1, transform))
            {
                transform.RotateAround(transform.TransformPoint(RotatePoint), new Vector3(0, 0, 1), -90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6) && Player1 == false && Random == false)
        {
            transform.RotateAround(transform.TransformPoint(RotatePoint), new Vector3(0, 0, 1), -90);
            if (!FindObjectOfType<PlayerArea>().CheckMove(Player1, transform))
            {
                transform.RotateAround(transform.TransformPoint(RotatePoint), new Vector3(0, 0, 1), 90);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Keypad5) && transform.position.y != 19 && Player1 == false)
        {
            FindObjectOfType<PileManager>().Switch(this, 1);
            if (!FindObjectOfType<PlayerArea>().CheckMove(Player1, transform))
            {
                FindObjectOfType<PileManager>().Switch(this, 1);
            }
        }


        if (Time.time - previousTime > (Input.GetKey(KeyCode.Keypad2) ? fallTime / 10 : fallTime) && Player1 == false)
        {
            transform.position += new Vector3(0, -1, 0);
            if (!FindObjectOfType<PlayerArea>().CheckMove(Player1, transform))
            {
                transform.position += new Vector3(0, 1, 0);
                FindObjectOfType<PlayerArea>().AddToGrid(Player1, transform);
                FindObjectOfType<PlayerArea>().CheckForLines();
                this.enabled = false;
                if (!FindObjectOfType<PlayerArea>().Loose)
                {
                    GameObject.FindGameObjectWithTag("player2").GetComponent<Spawn>().GetShape();
                }
                else
                {
                    FindObjectOfType<Menu>().Winner = "player1";
                    FindObjectOfType<Menu>().End();
                    if (Random == false)
                    {
                        Debug.LogWarningFormat("Perdu player2");
                    }
                    else
                    {
                        Debug.LogWarningFormat("Perdu Random"); 
                    }                    
                    Time.timeScale = 0;
                }

            }
            previousTime = Time.time;
        }
    }    
}
