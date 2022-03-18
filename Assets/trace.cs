using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class trace : MonoBehaviour
{
    public GameObject Cube;
    bool isPenetrating;
    [SerializeReference]
    private List<Vector3> Sp1Pos;

    public List<Vector3> Sp2Pos;
    public GameObject Sp1;
    public GameObject Sp2;
    private float TimeLeft;
    private const float Interval = 0.5f;

    [SerializeField]
    private bool InRealTime = true;

    [SerializeField]
    private float duration = 10;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(1, 0, 0), Color.red, duration, false);
    }

    void Update()
    {
        if (isPenetrating)
        {
			TimeLeft -= Time.deltaTime;
			if (TimeLeft < 0)
			{
				Sp1Pos.Add(Sp1.GetComponent<Transform>().position);
                Sp2Pos.Add(Sp2.GetComponent<Transform>().position);

                if (InRealTime)
				{
                    int count = Sp1Pos.Count;
                    Debug.DrawLine(Sp1Pos[count - 1], Sp2Pos[count - 1], Color.red, duration, false);
                    if (count >= 2)
                    {
                        Debug.DrawLine(Sp1Pos[count - 2], Sp1Pos[count - 1], Color.red, duration, false);
                        Debug.DrawLine(Sp2Pos[count - 2], Sp2Pos[count - 1], Color.red, duration, false);
                    }
                }

                TimeLeft = Interval;
		    }
	    }
    }

	private void OnTriggerEnter(Collider other)
	{
        //Debug.Log("!!!!!!");
        if (other.gameObject == Cube)
        {
            isPenetrating = true;
            TimeLeft = 0;
            //Debug.Log("NEW LIST!!!");
            Sp1Pos = new List<Vector3>();
            Sp2Pos = new List<Vector3>();
        }
    }

	private void OnTriggerExit(Collider other)
	{
        if (other.gameObject == Cube)
        {
            isPenetrating = false;

            if (Sp1Pos.Count > 1 && Sp2Pos.Count > 1 && !InRealTime)
            {
                //Debug.Log("DRAWING LINE");
                int count = Sp1Pos.Count;
                for (int i = 0; i < count - 1; i++)
                {
                    Debug.DrawLine(Sp1Pos[i], Sp1Pos[i + 1], Color.red, duration, false);
                    Debug.DrawLine(Sp2Pos[i], Sp2Pos[i + 1], Color.red, duration, false);
                    Debug.DrawLine(Sp1Pos[i], Sp2Pos[i], Color.red, duration, false);
                }
                Debug.DrawLine(Sp1Pos[count - 1], Sp2Pos[count - 1], Color.red, duration, false);
            }
        }
    }
}
