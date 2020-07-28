using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class DetectJoints : MonoBehaviour
{
    public GameObject BodySrcManager;
    public JointType TrackedJoint;
    public BoxCollider b;
    private BodySourceManager bodyManager;
    private Body[] bodies;
    public float multiplier = 10f;
    // Start is called before the first frame update
    void Start()
    {
        if (BodySrcManager == null)
        {
            Debug.Log("Assign Game Object with Body Source Manager ");
        }
        else
        {
            bodyManager = BodySrcManager.GetComponent<BodySourceManager>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (bodyManager == null)
        {
            return;
        }
        bodies = bodyManager.GetData();

        if (bodies == null)
        {
            return;
        }
        foreach (var body in bodies)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                var pos = body.Joints[TrackedJoint].Position;
                gameObject.transform.position = new Vector3(pos.X * multiplier, 0f);
                b.enabled = true;
            }
        }
    } 
}