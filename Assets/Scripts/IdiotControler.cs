using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IdiotControler : MonoBehaviour
{
    public Vector3 RotatePoint;
    public float previousTime;
    public float fallTime;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];
    public bool Loose;
    private static int nbAction = 6;
    public bool swaped;
    public bool counter = false;
    public float Timer = 0.5f;
    public float ResetTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        Debug.LogWarningFormat(Timer.ToString());
        if (swaped)
        {
            if (!FindObjectOfType<PlayerArea>().CheckMove(false, transform))
            {
                FindObjectOfType<PileManager>().Switch(this, 2);
            }
            swaped = false;
            
        }

        int action = Random.Range(0, nbAction);

        if (action == 0 && Timer <= 0)
        {
            FindObjectOfType<Action>().MoveLeft(transform);
            if (!FindObjectOfType<PlayerArea>().CheckMove(false, transform))
            {
                transform.position += new Vector3(1, 0, 0);
            }
            Timer = ResetTimer;
            counter = true;
        }

        if (action == 1 && Timer <= 0)
        {
            FindObjectOfType<Action>().MoveRight(transform);
            if (!FindObjectOfType<PlayerArea>().CheckMove(false, transform))
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            Timer = ResetTimer;
            counter = true;
        }

        if (action == 2 && Timer <= 0)
        {
            FindObjectOfType<Action>().RotateLeft(transform, RotatePoint);
            if (!FindObjectOfType<PlayerArea>().CheckMove(false, transform))
            {
                transform.RotateAround(transform.TransformPoint(RotatePoint), new Vector3(0, 0, 1), -90);
            }
            Timer = ResetTimer;
            counter = true;
        }

        if (action == 3 && Timer <= 0)
        {
            FindObjectOfType<Action>().RotateRight(transform, RotatePoint);
            if (!FindObjectOfType<PlayerArea>().CheckMove(false, transform))
            {
                transform.RotateAround(transform.TransformPoint(RotatePoint), new Vector3(0, 0, 1), 90);
            }
            Timer = ResetTimer;
            counter = true;
        }

        if (action == 4 && transform.position.y != 19 && Timer <= 0 && counter == true)
        {
            SwapShape();
            counter = false;
        }


        if (previousTime > (nbAction-1 == action ? fallTime / 10 : fallTime))
        {
            if(Timer <= 0)
            {
                FindObjectOfType<Action>().MoveDown(transform);
                Timer = ResetTimer;
                counter = true;
            }
            
            if (!FindObjectOfType<PlayerArea>().CheckMove(false, transform))
            {
                transform.position += new Vector3(0, 1, 0);
                FindObjectOfType<PlayerArea>().AddToGrid(false, transform);
                FindObjectOfType<PlayerArea>().CheckForLines();
                this.enabled = false;
                if (!Loose)
                {
                    GameObject.FindGameObjectWithTag("player2").GetComponent<Spawn>().GetShape();
                }
                else
                {
                    FindObjectOfType<Menu>().End();
                    FindObjectOfType<Menu>().Winner = "player1";
                    Debug.LogWarningFormat("Perdu Random");
                    Time.timeScale = 0;
                }

            }
            previousTime = Time.time;
        }
        previousTime += Time.deltaTime;
    }

    private void SwapShape()
    {
        FindObjectOfType<PileManager>().Switch(this, 2);
        if (!FindObjectOfType<PlayerArea>().CheckMove(false, transform))
        {
            FindObjectOfType<PileManager>().Switch(this, 2);
        }
    }
}
