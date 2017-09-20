using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBob : MonoBehaviour
{
    [Space, Header("Movement Variables")]
    [Range(.004f, 1)]
    public float gunbobAmountX;
    [Range(.004f, 1)]
    public float gunbobAmountY;

    float currentGunbobX;
    float currentGunbobY;

    HeadBob headbob;

    void Start()
    {
        headbob = Camera.main.GetComponent<HeadBob>();
    }

    void Update()
    {
        currentGunbobX = Mathf.Sin(headbob.headbobStepCounter) * gunbobAmountX;
        currentGunbobY = Mathf.Cos(headbob.headbobStepCounter * 2) * gunbobAmountY;
        transform.position = transform.root.position + new Vector3(currentGunbobX, currentGunbobY, 0);
    }
}