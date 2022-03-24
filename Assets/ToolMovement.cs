using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody Tool;
    public Vector3 Movement;
    public Vector3 Force;
    private Vector3 PreviousVelocity;

    // Start is called before the first frame update
    void Start()
    {
        PreviousVelocity = Tool.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Movement = (Tool.velocity - PreviousVelocity) / Time.deltaTime;
        Force = Movement * Tool.mass;
        PreviousVelocity = Tool.velocity;
    }
}
