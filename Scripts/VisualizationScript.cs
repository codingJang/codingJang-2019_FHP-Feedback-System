using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizationScript : MonoBehaviour
{
    public nuitrack.JointType[] typeJoint;
    GameObject[] CreatedJoint;
    public GameObject PrefabJoint;
    public GameObject PrefabHead;
    public string message = "", status = "", path = "Assets/Test Results/filename.txt";
    public int cnt_update = 0;
    public int delayTime = 5;
    public double thetaAns = 82.11632;
    public double sumTheta = 0;
    public float theta, thetaPrime, phi, alpha;
    public float[] arrTheta;
    public Vector3[] vectors;  // 0 : head | 1 : neck | 2 : collar | 3 : torso
    public Vector3 headOrient, floorNormal;
    public bool isTurtle = false, isTurtlePrev = false, playSound = false;
    public int soundControl = 0;
    public Quaternion newRotation = Quaternion.identity;
    public FaceInfo faceInfo;
    public Angles angles;

    void Start()
    {

        CreatedJoint = new GameObject[typeJoint.Length];
        vectors = new Vector3[8];
        arrTheta = new float[delayTime*30];

        for (int q = 0; q < typeJoint.Length; q++ )
        {
            if(typeJoint[q] == nuitrack.JointType.Head)
                CreatedJoint[q] = Instantiate(PrefabHead);
            else CreatedJoint[q] = Instantiate(PrefabJoint);
            CreatedJoint[q].transform.SetParent(transform);
        }

        message = "Skeleton created";
    }
    
    void Update()
    {
        
        if (cnt_update % 2 == 0)
        {
            //Debug.Log("안막혔음");

            if (CurrentUserTracker.CurrentUser != 0)
            {
                nuitrack.Skeleton skeleton = CurrentUserTracker.CurrentSkeleton;
                //vectors[6] = CurrentUserTracker.CurrentFloor.ToVector3();
                if (cnt_update % 300 == 0)
                {
                    floorNormal = CurrentUserTracker.CurrentFloorNormal.ToVector3();
                    if (floorNormal.magnitude >= 0.01) vectors[7] = floorNormal;
                }
                
                string json = nuitrack.Nuitrack.GetInstancesJson();
                faceInfo = JsonUtility.FromJson<FaceInfo>(json.Replace("\"\"", "[]"));
                angles = faceInfo.Instances[0].face.angles;
                if (angles != null)
                    newRotation = Quaternion.Euler(0, angles.yaw * (float)1.5, 0);


                for (int q = 0; q < typeJoint.Length; q++)
                {
                    nuitrack.Joint joint = skeleton.GetJoint(typeJoint[q]);
                    Vector3 newPosition = 0.05f * joint.ToVector3();

                    if (typeJoint[q] == nuitrack.JointType.Head)
                    {
                        vectors[0] = newPosition;
                        CreatedJoint[q].transform.localRotation = newRotation;
                    }
                    if (typeJoint[q] == nuitrack.JointType.Neck) vectors[1] = newPosition;
                    if (typeJoint[q] == nuitrack.JointType.LeftCollar) vectors[2] = newPosition;
                    if (typeJoint[q] == nuitrack.JointType.Torso) vectors[3] = newPosition;
                    if (typeJoint[q] == nuitrack.JointType.LeftShoulder) vectors[4] = newPosition;
                    if (typeJoint[q] == nuitrack.JointType.RightShoulder) vectors[5] = newPosition;

                    CreatedJoint[q].transform.localPosition = newPosition;
                }


                //theta = 90-Vector3.Angle(vectors[7], vectors[0] - vectors[1]);
                thetaPrime = 90 - Vector3.Angle(vectors[7], vectors[0] - vectors[2]);
                //phi = Vector3.Angle(headOrient, vectors[0] - vectors[2]);
                //alpha = phi - theta;

                int index = (cnt_update / 2) % (delayTime * 30);
                sumTheta -= arrTheta[index];
                sumTheta += thetaPrime;
                arrTheta[index] = thetaPrime;

                if (sumTheta/(delayTime*30) < thetaAns) isTurtle = true;
                else isTurtle = false;


                if (isTurtle)
                {
                    status = "FORWARD HEAD POSTURE(FHP) WARNING";
                    //GameObject.Find("beepsound").GetComponent<AudioSource>().Play();
                }
                else
                {
                    status = "Good! You're doing great!";
                    //GameObject.Find("beepsound").GetComponent<AudioSource>().Stop();
                }
                
                if (cnt_update == 600)
                {
                    if (isTurtle) soundControl = 1;
                    else soundControl = 0;
                    playSound = true;
                }
                if(cnt_update > 600)
                {
                    if (isTurtle && !isTurtlePrev) soundControl = 1;
                    else if (!isTurtle && isTurtlePrev) soundControl = -1;
                    else soundControl = 0;
                }

                if (playSound)
                {
                    if (soundControl == 1) GameObject.Find("beepsound").GetComponent<AudioSource>().Play();
                    if (soundControl == -1) GameObject.Find("beepsound").GetComponent<AudioSource>().Stop();
                }

                isTurtlePrev = isTurtle;
                
                newHandleTextFile.WriteString(path, cnt_update / 2, thetaPrime, isTurtle);
                message = "Skeleton found\n" + "Your neck angle: " + thetaPrime + "\n" + status + "\n" + "floorNormal: " + floorNormal + "\n";
            }
            else
            {
                message = "Skeleton not found\n";
            }
        }
        cnt_update++;
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.skin.label.fontSize = 20;
        GUILayout.Label(message);
    }
}