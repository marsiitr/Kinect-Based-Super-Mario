 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class UseAsASwitch : MonoBehaviour
{
    public BoxCollider b;
    public BoxCollider r1;
    public BoxCollider r2;
    public float initialPosX = 0f;
    public float detectablePos = 4f;
    public bool s;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (b.enabled == true)
        {
            s = true;
        }
            if (s == true) {
                if (transform.position.x - initialPosX < -1 * detectablePos)
                {
                    r2.enabled = true;
                }
                else if (transform.position.x - initialPosX > detectablePos)
                {
                    r1.enabled = true;
                }
                else
                {
                    r1.enabled = false;
                    r2.enabled = false;
                }
               // Debug.Log(transform.position.x);
            }
        }
    }