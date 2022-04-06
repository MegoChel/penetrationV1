using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject Sharp;
    public GameObject NotSharp;
    public GameObject Sp1;      //Sharp point 1 & 2
    public GameObject Sp2;
    public GameObject NSp1;     //NotSharp point 1 & 2
    public GameObject NSp2;
    public GameObject Plane;
    Mesh meshSharp;
    Mesh meshNotSharp;
    Vector3 SharpVector;
    Vector3 NotSharpVector;
    public Vector3[] _out;

    // Start is called before the first frame update
    void Start()
    {
        Mesh PlaneMesh = Plane.GetComponent<MeshFilter>().mesh;
        Plane PlanePlane = new Plane(PlaneMesh.vertices[2] + Plane.transform.position, PlaneMesh.vertices[4] + Plane.transform.position, PlaneMesh.vertices[5] + Plane.transform.position);
        Debug.DrawLine(PlaneMesh.vertices[4] + Plane.transform.position, PlaneMesh.vertices[5] + Plane.transform.position, Color.red, 100f, false);
        Debug.DrawLine(PlaneMesh.vertices[2] + Plane.transform.position, PlaneMesh.vertices[4] + Plane.transform.position, Color.red, 100f, false);
        Debug.DrawLine(PlaneMesh.vertices[2] + Plane.transform.position, PlaneMesh.vertices[5] + Plane.transform.position, Color.red, 100f, false);

        Debug.DrawLine(Plane.transform.position, PlanePlane.normal + Plane.transform.position, Color.green, 100f, false);

        meshSharp = Sharp.GetComponent<MeshFilter>().mesh;
        Mesh mesh2 = Instantiate(meshSharp);
        meshNotSharp = NotSharp.GetComponent<MeshFilter>().mesh;
        //Debug.Log("Sharp mesh vertices: " + meshSharp.vertices);
        _out = meshSharp.vertices;
        for (int i = 0; i < _out.Length; i++)
            _out[i] += Sharp.transform.position;
        if (_out.Length != 0)
        {
            //Debug.DrawLine(Sp1.transform.position, Sp2.transform.position, Color.magenta, 100f, false);
            //Debug.DrawLine(_out[0], _out[1], Color.red, 100f, false);
            //Debug.DrawLine(_out[2], _out[3], Color.red, 100f, false);

        }
        //Debug.DrawLine( Color.red, 100f, false);
    }

    //private void OnDrawGizmosSelected()
    //{
    //	if (_out.Length != 0)
    //	{
    //           Debug.Log("draw");
    //           Gizmos.color = Color.green;
    //           foreach (var o in _out)
    //               Gizmos.DrawSphere(o, 0.01f);
    //       }
    //}

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(Sp1.transform.position, Sp2.transform.position, Color.magenta, Time.deltaTime, false);
        Debug.DrawLine(NSp1.transform.position, NSp2.transform.position, Color.magenta, Time.deltaTime, false);
    }

	//private void OnCollisionEnter(Collision collision)
	//{
 //       if (collision.gameObject == cube)
 //           GetComponent<Collider>().isTrigger = true;

	//}

	//private void OnCollisionExit(Collision collision)
	//{
 //       GetComponent<Collider>().isTrigger = false;
	//}
}
