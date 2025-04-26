using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrientationManager : MonoBehaviour
{
    public enum SpriteType { LookAtCamera, CameraForward };
    private SpriteType spriteType;

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
    }
}
