using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public GameObject tankPrefab;
    public GameObject tankWayPointPrefab;
    public GameObject[] Waypoints;
    public float radius = 20;
    // Start is called before the first frame update
    void Start()
    {
        Waypoints = new GameObject[36];
        for (int i = 0; i < Waypoints.Length; i++)
        {
            Waypoints[i] = GameObject.Instantiate(tankWayPointPrefab);
            float angle = (2.0f * Mathf.PI / 36.0f * i);
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius + transform.position;
            Waypoints[i].transform.position = pos;
        }
        CreateTank();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            CreateTank();
        }
    }

void CreateTank()
    {
        GameObject target = GameObject.Instantiate(tankPrefab, Waypoints[0].transform.position, Quaternion.identity);
        PatrolAI ai = target.GetComponent<PatrolAI>();
        ai.Speed = 5.0f;
        ai.waypoints = Waypoints;
    }
}
