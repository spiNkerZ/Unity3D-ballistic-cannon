using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProactiveCalculate : MonoBehaviour
{
    public static Vector3 TraectroyCalculate(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

}
