using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScr : MonoBehaviour
{
    public Transform target;

    public Vector3 camOffset;

    private void FixedUpdate()
    {
        if (!target) return;

        var smoothPos = Vector3.Lerp(transform.position, target.position, 0.2F);
        transform.position = smoothPos + camOffset;
    }
}
