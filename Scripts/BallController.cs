using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public int cnt = 0;
    Vector3 positionZero = new Vector3(-70, 100, -180);
    Vector3 velocityZero = new Vector3(0, -200, 350);
    public GameObject Ghost;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cnt % 300 == 0)
        {
            Rigidbody Rgd = GetComponent<Rigidbody>();
            Rgd.position = positionZero;
            Rgd.velocity = velocityZero;
            Rgd.angularVelocity = Vector3.zero;
        }
        cnt++;
    }
    
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Table" || col.gameObject.name == "Net")
        {
            Instantiate(Ghost);
            Ghost.transform.position = this.GetComponent<Rigidbody>().position;
        }
    }
    
}
