using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brodilna : MonoBehaviour
{
    public Transform CameraAxisTransform;

    public float MinAngle;
    public float MaxAngle;

    public float RotationSpead;

    void Update()
    {
        float newAngleY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * RotationSpead;
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);

        float newAngleX = CameraAxisTransform.localEulerAngles.x - Input.GetAxis("Mouse Y") * RotationSpead;
        if (newAngleX > 180)
        {
            newAngleX -= 360;
        }
        newAngleX = Mathf.Clamp(newAngleX, MinAngle, MaxAngle);
        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
