using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection : MonoBehaviour
{
    public GameObject Sp1;      //Sharp point 1 & 2
    public GameObject Sp2;
    public GameObject NSp1;     //NotSharp point 1 & 2
    public GameObject NSp2;
    public GameObject Cube;
    Plane plane;
    Vector3 SharpVector;
    Vector3 NotSharpVector;
    // Start is called before the first frame update
    void Start()
    {
        SharpVector = Sp1.transform.position - Sp2.transform.position;
        NotSharpVector = NSp1.transform.position - NSp2.transform.position;
        Mesh CubeMesh = Cube.GetComponent<MeshFilter>().mesh;
        Debug.Log(CubeMesh.vertices.Length);
        plane = new Plane(CubeMesh.vertices[2] + Cube.transform.position, CubeMesh.vertices[4] + Cube.transform.position, CubeMesh.vertices[5] + Cube.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 SharpVectorProjection;
    Vector3 NotSharpVectorProjection;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Cube)
        {
            SharpVectorProjection = Vector3.ProjectOnPlane(SharpVector, plane.normal);
            NotSharpVectorProjection = Vector3.ProjectOnPlane(NotSharpVector, plane.normal);
            Debug.Log(SharpVectorProjection);
            Debug.Log(NotSharpVectorProjection);
        }
        Debug.Log("121");
    }
}
