using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    public Transform center;
    public float angle = 5;
    public float speed = 2;
    Vector3 axis;
    private void Start()
    {
        axis = center.transform.position;
        StartCoroutine("MoveRoutine");
    }
    IEnumerator MoveRoutine()
    {
        while(true)
        {
            transform.RotateAround(axis, Vector3.up, angle);
            yield return new WaitForSeconds(Time.fixedDeltaTime * speed);
        }
    }
}
