using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    [HideInInspector]
    public float moveVertical;
    [HideInInspector]
    public float moveHorizontal;

    [HideInInspector]
    public float lookVertical;
    [HideInInspector]
    public float lookHorizontal;

    [HideInInspector]
    public bool isIdle;
    [HideInInspector]
    public bool isMoving;
    [HideInInspector]
    public bool isSprinting;
}
