using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    
    public Transform center;

    [Header("Orbita")]
    public float orbitSpeed;
    public float radiusX;
    public float radiusZ;
    public float angleOffset;


    public Vector3 orbitInclination = Vector3.zero;

    [Header("Gizmo Orbit")]
    public bool drawOrbit = true;
    public Color orbitColor = Color.cyan;

    private float currentAngle = 0f;

    void Update()
    {
        if (center == null) return;

        currentAngle = Time.time * orbitSpeed + angleOffset;

       
        float x = Mathf.Cos(currentAngle) * radiusX;
        float z = Mathf.Sin(currentAngle) * radiusZ;
        Vector3 orbitPosition = new Vector3(x, 0f, z);

        Quaternion inclination = Quaternion.Euler(orbitInclination);
        orbitPosition = inclination * orbitPosition;

        transform.position = center.position + orbitPosition;
    }

    void OnDrawGizmos()
    {
        if (!drawOrbit || center == null) return;

        Gizmos.color = orbitColor;
        Vector3 prevPoint = Vector3.zero;
        int segments = 100;

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * Mathf.PI * 2 / segments;
            float x = Mathf.Cos(angle) * radiusX;
            float z = Mathf.Sin(angle) * radiusZ;
            Vector3 point = new Vector3(x, 0f, z);

         
            Quaternion inclination = Quaternion.Euler(orbitInclination);
            point = inclination * point + center.position;

            if (i > 0)
                Gizmos.DrawLine(prevPoint, point);

            prevPoint = point;
        }
    }
}
