using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpriteOrientationManager : MonoBehaviour
{
    public enum SpriteType { LookAtCamera, CameraForward };
    private SpriteType spriteType;
    private bool lockX = true;
    private Vector3 originalRotation;

    private void Awake()
    {
        originalRotation = transform.rotation.eulerAngles;
    }

    private void LateUpdate()
    {
        switch (spriteType)
        {
            case SpriteType.LookAtCamera:
                transform.LookAt(Camera.main.transform.position, Vector3.up);
                break;

            case SpriteType.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
                default:
                break;
        }

        Vector3 rotation = transform.rotation.eulerAngles;
        if (lockX)
        {
            rotation.x = originalRotation.x;
        }
        transform.rotation = Quaternion.Euler(rotation);
    }
}
