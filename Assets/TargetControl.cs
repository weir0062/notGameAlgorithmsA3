using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject targetWayPointPrefab;
    public GameObject[] Waypoints;
    public float radius = 25;
    // Start is called before the first frame update
    void Start()
    {
        Waypoints = new GameObject[36];
        for (int i = 0; i < Waypoints.Length; i++)
        {
            Waypoints[i] = GameObject.Instantiate(targetWayPointPrefab);
            float angle = (2.0f * Mathf.PI / 36.0f * i);
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius + transform.position;
            Waypoints[i].transform.position = pos;
        }
        SpawnTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnTarget();
        }
    }


    void SpawnTarget()
    {

        GameObject target = GameObject.Instantiate(targetPrefab, Waypoints[0].transform.position, Quaternion.identity);
        target.tag = "Target";
        PatrolAI ai = target.GetComponent<PatrolAI>();
        ai.Speed = 5.0f;
        ai.waypoints = Waypoints;
    }
}
