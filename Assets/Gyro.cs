using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro: MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    public Quaternion rot;
    public Quaternion rotZero;

    public float HorizontalMove = 0;
    public float VerticalMove = 0;

    private void Start()
    {
        gyroEnabled = EnableGyro();
        if (gyroEnabled)
        {
            
        }
        rot = new Quaternion(0, 0, 0, 0);
        SetGyroZero();
    }

    private void Update()
    {
        if (gyroEnabled)
        {
            rot = gyro.attitude;
            HorizontalMove = Difference(rotZero.z, rot.z);
            VerticalMove = Difference(rotZero.x, rot.x) * -1f;
        }
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }

    public void SetGyroZero()
    {
        rotZero = gyro.attitude;
    }

    float Difference(float v1, float v2)
    {
        float x;

        x = v2 - v1;

        return x;
    }
}
