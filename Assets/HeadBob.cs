using System.Collections;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public float headbobSpeed;
    public float headbobAmountX;
    public float headbobAmountY;
    [HideInInspector]
    public float headbobStepCounter;
    Vector3 parentLastPosition;

    void Start()
    {
        parentLastPosition = transform.root.position;
    }

    void Update()
    {
        headbobStepCounter += Vector3.Distance(parentLastPosition, transform.root.position) * headbobSpeed;
        transform.localPosition = new Vector3(Mathf.Sin(headbobStepCounter) * headbobAmountX,
            (Mathf.Cos(headbobStepCounter * 2) * headbobAmountY * -1), 0);
        parentLastPosition = transform.root.position;
    }
}