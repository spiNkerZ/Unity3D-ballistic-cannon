using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallusticCalculate : MonoBehaviour
{
    static float g = Physics.gravity.y;
    public struct Data
    {
       public float angle;
       public Vector3 fromTo;
    }
    public static float CalculateTrajectory(Data _data)
    {
        _data.angle = Mathf.Abs(_data.angle);
        Vector3 fromToXZ = new Vector3(_data.fromTo.x, 0, _data.fromTo.z);

        float x = fromToXZ.magnitude;
        float y = _data.fromTo.y;

        float radians = _data.angle * Mathf.PI / 180;

        float trajectory = (g * x * x) / (2 * (y - Mathf.Tan(radians) * x) * Mathf.Pow((Mathf.Cos(radians)),2));
        float speed = Mathf.Sqrt(Mathf.Abs(trajectory)) * 0.95f;

        return speed;
    }
}
