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

    public static Vector3 Rotate(this Vector3 vec, float degrees) {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
        float tx = vec.x;
        float ty = vec.y;
        vec.x = (cos * tx) - (sin * ty);
        vec.y = (sin * tx) + (cos * ty);
        return vec;
    }


    // check if the vector2 is in camera
    public static bool in_camera(this Vector2 vec){
        Vector2 temp = Camera.main.WorldToViewportPoint(vec);
        if(temp.x>=0 && temp.x<=1 && temp.y>=0 && temp.y<=1){
            return true;
        } 
        return false;
    }

    public static bool in_camera(this Vector2 vec, Camera _cam_ref){
        Vector2 temp = _cam_ref.WorldToViewportPoint(vec);
        if(temp.x>=0 && temp.x<=1 && temp.y>=0 && temp.y<=1){
            return true;
        } 
        return false;
    }
     
    public static bool in_camera(this Vector3 vec){
        return in_camera(new Vector2(vec.x, vec.y));
    }

    public static bool in_camera(this Vector3 vec, Camera _cam_ref){
        return in_camera(new Vector2(vec.x, vec.y), _cam_ref);
    }

    // check if the pos is roughly in camera
    // may be a little bit outside the camera
    public static bool rough_in_camera(this Vector2 vec){
        Vector2 temp = Camera.main.WorldToViewportPoint(vec);
        if(temp.x>= -0.3f && temp.x<= 1.3f && temp.y>= -0.3f && temp.y<= 1.3f){
            return true;
        } 
        return false;
    }

    public static bool rough_in_camera(this Vector2 vec, Camera _cam_ref){
        Vector2 temp = _cam_ref.WorldToViewportPoint(vec);
        if(temp.x>= -0.3f && temp.x<= 1.3f && temp.y>= -0.3f && temp.y<= 1.3f){
            return true;
        } 
        return false;
    }
     
    public static bool rough_in_camera(this Vector3 vec){
        return rough_in_camera(new Vector2(vec.x, vec.y));
    }

    public static bool rough_in_camera(this Vector3 vec, Camera _cam_ref){
        return rough_in_camera(new Vector2(vec.x, vec.y), _cam_ref);
    }


    // calculate the length of the projection of a vector2 on vector2 target
    public static float projection(this Vector2 vec, Vector2 target){
        return Vector2.Dot(vec, target) / vec.magnitude;
    }

    public static float projection(this Vector3 vec, Vector3 target){
        Vector2 vec_temp = new Vector2(vec.x, vec.y);
        return Vector2.Dot(vec_temp, new Vector2(target.x, target.y)) / vec_temp.magnitude;
    }


    // check if vectors are equal in 2d dimension
    public static bool equals_in_2d(this Vector2 vec, Vector2 rhs){
        return Mathf.Approximately(vec.x, rhs.x) && Mathf.Approximately(vec.y, rhs.y);
    }

    public static bool equals_in_2d(this Vector2 vec, Vector3 rhs){
        return Mathf.Approximately(vec.x, rhs.x) && Mathf.Approximately(vec.y, rhs.y);
    }

    public static bool equals_in_2d(this Vector3 vec, Vector2 rhs){
        return Mathf.Approximately(vec.x, rhs.x) && Mathf.Approximately(vec.y, rhs.y);
    }

    public static bool equals_in_2d(this Vector3 vec, Vector3 rhs){
        return Mathf.Approximately(vec.x, rhs.x) && Mathf.Approximately(vec.y, rhs.y);
    }


    // cast vector3 to vector2
    public static Vector2 cast_to_2d(this Vector3 vec){
        return new Vector2(vec.x, vec.y);
    }
     
}
