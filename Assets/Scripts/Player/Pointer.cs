using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer: MonoBehaviour
{
    public Transform AimTransform;
    public Camera Camera;
    void LateUpdate()
    {
        Plane planeXY = new Plane(Vector3.back, Vector3.zero);
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        float distance;

        //Реальное положение прицела для физики
        planeXY.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        Vector3 toAim = point - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);


        //Рендер поверх остального
        Plane plane2 = new Plane(Vector3.back, new Vector3(0, 0, -3));
        plane2.Raycast(ray, out distance);
        Vector3 point2 = ray.GetPoint(distance);
        AimTransform.position = point2;      
    }
}
