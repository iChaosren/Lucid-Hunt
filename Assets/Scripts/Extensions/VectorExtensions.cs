using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 ToVector2(this Vector3 vec3) => new Vector2(vec3.x, vec3.y);

    public static Vector3 ToVector3(this Vector2 vec2, float z = 0) => new Vector3(vec2.x, vec2.y, z);
}
