using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject Sharp;
    public GameObject NotSharp;
    Mesh meshSharp;
    Mesh meshNotSharp;
    Vector3 SharpVector;
    Vector3 NotSharpVector;
    public Vector3[] _out;

    // Start is called before the first frame update
    void Start()
    {
        meshSharp = Sharp.GetComponent<MeshFilter>().mesh;
        meshNotSharp = NotSharp.GetComponent<MeshFilter>().mesh;
        Debug.Log("Sharp mesh vertices: " + meshSharp.vertices);
        _out = meshSharp.vertices;
		if (_out.Length != 0)
		{
            Debug.DrawLine(_out[0], _out[2], Color.red, 100f, false);
            Debug.DrawLine(_out[1], _out[3], Color.red, 100f, false);
		}
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
