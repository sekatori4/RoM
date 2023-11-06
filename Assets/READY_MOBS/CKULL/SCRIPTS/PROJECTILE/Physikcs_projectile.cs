//------------------------------------------------------------------------------------------------------------
//using UnityEngine;

//Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
//{
//    Vector3 distance = target - origin;
//    Vector3 distanceXZ = distance;
//    distanceXZ.y = 0f;

//    float Sy = distance.y;
//    float Sxz = distanceXZ.magnitude;

//    float Vxz = Sxz / time;
//    float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

//    Vector3 result = distanceXZ.normalized;
//    result *= Vxz;
//    result.y = Vy;

//    return result;

//}

//public void LaunchProjectale()
//{


//    Vector3 Vo = CalculateVelocity(target_kidat, ruka_kidat.position, 0.5f);


//    Rigidbody obj = Instantiate(boolet, ruka_kidat.position, Quaternion.AngleAxis(90, Vector3.forward));
//    obj.velocity = Vo;
//    obj_torch = obj.gameObject;

//    // Destroy(obj_torch,3f);


//}