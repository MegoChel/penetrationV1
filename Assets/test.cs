using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cube.transform.rotation.eulerAngles);
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
