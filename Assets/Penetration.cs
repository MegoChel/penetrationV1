using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class Penetration : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Blade;
    public GameObject Grip;
    bool isPenetrating;
    Hand HoldigHand;

 //   Vector3 VectorMul(Vector3 a, Vector3 b)
	//{
 //       return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
	//}

    // Start is called before the first frame update
    void Start()
    {

    }
    VelocityEstimator ve;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Blade.transform.right);
        //Debug.Log("isPenetrating: " + isPenetrating);
        //Debug.Log("Velosity: " + GetComponent<VelocityEstimator>().GetVelocityEstimate());

        if (isPenetrating)
		{
            //transform.position += VectorMul(Blade.transform.right, GetComponent<VelocityEstimator>().GetVelocityEstimate()) * Time.deltaTime;
		}
        //Debug.Log("VelocityEstimator: " + ve.GetVelocityEstimate());
    }

	//private void OnCollisionEnter(Collision collision)
	//{
	//	if (collision.gameObject == Cube)
	//	{
 //           isPenetrating = true;
 //       }
	//}

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Wood")
            isPenetrating = true;
    }

	private void OnTriggerExit(Collider other)
	{

        isPenetrating = false;
    }

	public void DetachFormHand()
	{
        Blade.GetComponent<Collider>().isTrigger = false;
        Grip.GetComponent<Collider>().isTrigger = false;
        
    }

	//private void OnCollisionExit(Collision collision)
	//{
 //       if (collision.gameObject == Cube)
	//	{
 //           isPenetrating = false;
 //       }
 //   }

    void OnAttachedToHand(Hand hand)
	{
		Blade.GetComponent<Collider>().isTrigger = true;
		Grip.GetComponent<Collider>().isTrigger = true;
		HoldigHand = hand;
        if (ve == null)
		{
            ve = HoldigHand.gameObject.AddComponent<VelocityEstimator>();
            ve.BeginEstimatingVelocity();
        }
	}

    public void UpdateObjVelocity()
	{
        Vector3 velocityTarget, angularTarget;
        velocityTarget = ve.GetVelocityEstimate();
        angularTarget = ve.GetAngularVelocityEstimate();
        if (isPenetrating)
		{
            velocityTarget = Vector3.Project(velocityTarget, transform.right);
            angularTarget = Vector3.Project(angularTarget, transform.forward);
        }

        float scale = SteamVR_Utils.GetLossyScale(transform);
        float maxAngularVelocityChange = 20f * scale;
        float maxVelocityChange = 10f * scale;

        Rigidbody axeRigidbody = gameObject.GetComponent<Rigidbody>();

        axeRigidbody.velocity = Vector3.MoveTowards(axeRigidbody.velocity, velocityTarget, maxVelocityChange);
        //attachedObjectInfo.attachedRigidbody.velocity = Vector3.MoveTowards(attachedObjectInfo.attachedRigidbody.velocity, velocityTarget, maxVelocityChange);
        axeRigidbody.angularVelocity = Vector3.MoveTowards(axeRigidbody.angularVelocity, angularTarget, maxAngularVelocityChange);
        
    }
}
