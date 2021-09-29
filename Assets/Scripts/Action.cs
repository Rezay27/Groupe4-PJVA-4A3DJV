using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public void MoveDown(Transform sp)
    {
        sp.position += new Vector3(0, -1, 0);
    }
    public void MoveLeft(Transform sp)
    {
        sp.position += new Vector3(-1, 0, 0);
    }
    public void MoveRight(Transform sp)
    {
        sp.position += new Vector3(1, 0, 0);
    }
    public void RotateLeft(Transform sp, Vector3 RotatePoint)
    {
        sp.RotateAround(sp.TransformPoint(RotatePoint), new Vector3(0, 0, 1), 90);
    }
    public void RotateRight(Transform sp, Vector3 RotatePoint)
    {
        sp.RotateAround(sp.TransformPoint(RotatePoint), new Vector3(0, 0, 1), -90);
    }
}
