// extension class for vector2

using UnityEngine;
public static class Vector2Extension {
     
     // counter-clockwise rotate the vector2 "degrees" degree
     public static Vector2 Rotate(this Vector2 vec, float degrees) {
         float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
         float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
         float tx = vec.x;
         float ty = vec.y;
         vec.x = (cos * tx) - (sin * ty);
         vec.y = (sin * tx) + (cos * ty);
         return vec;
     }

    // counter-clockwise rotate the vector2 "degrees" degree
     public static Vector3 Rotate(this Vector3 vec, float degrees) {
         float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
         float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
         float tx = vec.x;
         float ty = vec.y;
         vec.x = (cos * tx) - (sin * ty);
         vec.y = (sin * tx) + (cos * ty);
         return vec;
     }
 }