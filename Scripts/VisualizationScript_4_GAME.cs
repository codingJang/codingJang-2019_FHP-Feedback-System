using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizationScript_4_GAME : MonoBehaviour
{
    public nuitrack.JointType[] typeJoint;
    GameObject[] CreatedJoint;
    public GameObject PrefabJoint;
    public GameObject PrefabHand;
    public string defaultMessage = "@@공을 쳐보세요!!@@\n";
    public string message = "";
    public int cnt = 0;
    public Vector3 moveOrigin = new Vector3(200, 70, 0);

    void Start()
    {
        CreatedJoint = new GameObject[typeJoint.Length];
        for (int q = 0; q < typeJoint.Length; q++)
        {
            if (typeJoint[q] == nuitrack.JointType.RightWrist)
                CreatedJoint[q] = Instantiate(PrefabHand);
            else CreatedJoint[q] = Instantiate(PrefabJoint);
            CreatedJoint[q].transform.SetParent(transform);
        }
        message = defaultMessage + "Skeleton created";
    }

    void FixedUpdate()
    {
        if (cnt % 2 == 0)
        {
            if (CurrentUserTracker.CurrentUser != 0)
            {
                nuitrack.Skeleton skeleton = CurrentUserTracker.CurrentSkeleton;
                nuitrack.Joint joint = skeleton.GetJoint(nuitrack.JointType.None);
                for (int q = 0; q < typeJoint.Length; q++)
                {
                    joint = skeleton.GetJoint(typeJoint[q]);
                    Rigidbody rb = CreatedJoint[q].GetComponent<Rigidbody>();
                    Vector3 newPosition = 0.15f * joint.ToVector3() + moveOrigin;
                    rb.MovePosition(newPosition);
                    if (typeJoint[q] == nuitrack.JointType.RightWrist)
                    {
                        Vector3 jointRight = new Vector3(joint.Orient.Matrix[0], joint.Orient.Matrix[3], joint.Orient.Matrix[6]);   //X(Right)
                        Vector3 jointUp = new Vector3(joint.Orient.Matrix[1], joint.Orient.Matrix[4], joint.Orient.Matrix[7]);   //Y(Up)
                        Vector3 jointForward = new Vector3(joint.Orient.Matrix[2], joint.Orient.Matrix[5], joint.Orient.Matrix[8]);   //Z(Forward)
                        Quaternion newRotation = Quaternion.LookRotation(jointForward, jointUp);

                        rb.MoveRotation(newRotation);
                    }
                }
            }
            else
            {
                message = defaultMessage + "Skeleton not found";
            }
        }
        cnt++;
    }


    void OnGUI()
    {
        GUI.color = Color.cyan;
        GUI.skin.label.fontSize = 50;
        GUILayout.Label(message);
    }
}