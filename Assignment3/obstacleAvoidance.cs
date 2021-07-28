using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform tr;
    public float freq = 30.0f;
    public float speed = 0.01f;

    [Header("Sensors")]
    public float sensorLength = 3f;
    public float frontSensorPosition = 0.5f;
    public float frontSideSensorPosition = 0.2f;
    public bool avoiding = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.Translate(5*speed * Mathf.Sin(Time.time * freq), 0f, speed);
        Sensors();
    }
    private void Sensors()
    {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position;
        sensorStartPos.z += frontSensorPosition;
        //float avoidMultiplier = 0;
        avoiding = false;

        // front center sensor
        if(Physics.Raycast(sensorStartPos, transform.forward, out hit , sensorLength))
        {
            Debug.DrawLine(sensorStartPos, hit.point);
            if(hit.collider.CompareTag("Obstacle 1"))
            {
                avoiding = true;
            }
        }

        // front right sensor
        sensorStartPos.x += frontSideSensorPosition;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
        {
            Debug.DrawLine(sensorStartPos, hit.point);
            if (hit.collider.CompareTag("Obstacle 1"))
            {
                avoiding = true;
                //transform.position += new Vector3(1f, 0, 0);
                tr.Translate(-0.5f, 0, 0);
            }

        }
        

        // front left sensor
        sensorStartPos.x -= 2*frontSideSensorPosition;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
        {
            Debug.DrawLine(sensorStartPos, hit.point);
            if (hit.collider.CompareTag("Obstacle 1"))
            {
                avoiding = true;
                //transform.position += new Vector3(-1f, 0, 0);
                tr.Translate(0.5f, 0, 0);
            }

        }
        Debug.DrawLine(sensorStartPos, hit.point);
    }
}
