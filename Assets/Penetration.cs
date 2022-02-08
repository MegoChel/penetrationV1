using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Penetration : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Sp1;
    public GameObject Sp2;
    public GameObject Blade;
    public GameObject Grip;
    bool isPenetrating;

    Vector3 VectorMul(Vector3 a, Vector3 b)
	{
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Blade.transform.right);
        Debug.Log("isPenetrating: " + isPenetrating);
        //Debug.Log("Velosity: " + GetComponent<VelocityEstimator>().GetVelocityEstimate());

        if (isPenetrating)
		{
            transform.position += VectorMul(Blade.transform.right, GetComponent<VelocityEstimator>().GetVelocityEstimate()) * Time.deltaTime;
		}
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == Cube)
		{
            Blade.GetComponent<Collider>().isTrigger = true;
            Grip.GetComponent<Collider>().isTrigger = true;
            isPenetrating = true;
		}
	}
	private void OnCollisionExit(Collision collision)
	{
            Blade.GetComponent<Collider>().isTrigger = false;
            Grip.GetComponent<Collider>().isTrigger = false;
        isPenetrating = false;
    }
}
