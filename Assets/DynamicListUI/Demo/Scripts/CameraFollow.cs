using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Target;

    private float _deltaX;
    private float _deltaZ;

    void Start()
    {
        _deltaX = transform.position.x - Target.position.x;
        _deltaZ = transform.position.z - Target.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Target.position.x + _deltaX, transform.position.y, Target.position.z + _deltaZ);
    }
}
