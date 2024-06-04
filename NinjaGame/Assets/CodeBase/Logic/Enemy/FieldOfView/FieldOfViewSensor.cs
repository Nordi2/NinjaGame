using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FieldOfView))]
[ExecuteInEditMode]
public class FieldOfViewSensor : MonoBehaviour
{
    public float Distance = 10;
    public float angle = 30;
    public float height = 1.0f;
    public Color meshColor = Color.red;
    public int scanFrequncy = 30;
    public LayerMask layers;
    public List<GameObject> Objects = new List<GameObject>();

    private Collider[] colliders = new Collider[50];
    private Mesh _mesh;
    private int count;
    private float scanInterval;
    private float scanTimer;
    private void Start()
    {
        scanInterval = 1.0f / scanFrequncy;
    }
    private void Update()
    {
        scanInterval -= Time.deltaTime;
        if (scanTimer <0)
        {
            scanTimer += scanInterval;
            Scan();
        }
    }
    public bool IsInSight(GameObject obj) 
    {
        Vector3 origin = transform.position;
        Vector3 dest = obj.transform.position;
        Vector3 direction = dest - origin;

        if (direction.y < 0 || direction.y >height)
        {
            return false;
        }
        return true;
    }    
    private void Scan()
    {
        count = Physics.OverlapSphereNonAlloc(transform.position, Distance, colliders, layers, QueryTriggerInteraction.Collide);

        Objects.Clear();
        for (int i = 0; i < count; ++i)
        {
            GameObject obj = colliders[i].gameObject;
            if (IsInSight(obj))
            {
                Objects.Add(obj);
            }
        }
    }

    private void OnValidate()
    {
        _mesh = CreateWedgeMesh();
        scanInterval = 1.0f / scanFrequncy;
    }

    //private void OnDrawGizmos()
    //{
    //    if (_mesh)
    //    {
    //        Gizmos.color = meshColor;
    //        Gizmos.DrawMesh(_mesh, transform.position, transform.rotation);
    //    }

    //    Gizmos.DrawWireSphere(transform.position, Distance);
    //    for (int i = 0; i < count; ++i)
    //    {
    //        Gizmos.DrawSphere(colliders[i].transform.position, 1);
    //    }

    //    Gizmos.color = Color.green;
    //    foreach (var obj in Objects)
    //    {
    //        Gizmos.DrawSphere(obj.transform.position, 0.2f);
    //    }
    //}
    private Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();

        int segments = 10;
        int numTrinagles = (segments * 4) + 2 + 2;
        int numVertices = numTrinagles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * Distance;
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * Distance;

        Vector3 topCenter = bottomCenter + Vector3.up * height;
        Vector3 topLeft = bottomLeft + Vector3.up * height;
        Vector3 topRight = bottomRight + Vector3.up * height;

        int vert = 0;
        //left Side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;

        //Right Side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomCenter;

        float currentAngle = -angle;
        float deltaAngle = (angle * 2) / segments;
        for (int i = 0; i < segments; i++)
        {
            bottomLeft = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * Distance;
            bottomRight = Quaternion.Euler(0, currentAngle  + deltaAngle, 0) * Vector3.forward * Distance;

            topLeft = bottomLeft + Vector3.up * height;
            topRight = bottomRight + Vector3.up * height;

            //far Side
            vertices[vert++] = bottomLeft;
            vertices[vert++] = bottomRight;
            vertices[vert++] = topRight;

            vertices[vert++] = topRight;
            vertices[vert++] = topLeft;
            vertices[vert++] = bottomLeft;

            //top
            vertices[vert++] = topCenter;
            vertices[vert++] = topLeft;
            vertices[vert++] = topRight;
            //bottom
            vertices[vert++] = bottomCenter;
            vertices[vert++] = bottomRight;
            vertices[vert++] = bottomLeft;

            currentAngle += deltaAngle;
        }
        for (int i = 0; i < numVertices; i++)
        {
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        return mesh;
    }

}
