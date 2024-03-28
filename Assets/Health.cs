using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 0.0f;
    public float maxhealth = 20.0f;
    public float healthLength = 1.0f;
    public LineRenderer green;
    public LineRenderer red;
    public GameObject offset;
    float leftside;
    float rightside;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        leftside = healthLength / 2.0f;
        rightside = healthLength / 2.0f;
        Vector3 pos = offset.transform.position;
        if (health <= 0.0f)
        {
            green.positionCount = 0;
            red.positionCount = 2;

            red.SetPosition(0, pos - Vector3.left * leftside);
            red.SetPosition(1, pos + Vector3.left * rightside);
        }
        else if (health >= maxhealth)
        {
            green.positionCount = 2;
            red.positionCount = 0;
            green.SetPosition(0, pos - Vector3.left * leftside);
            green.SetPosition(1, pos + Vector3.left * rightside);
        }
        else
        {
            green.positionCount = 2;
            red.positionCount = 2;
            float scale = (health / maxhealth) - 0.5f;
            green.SetPosition(0, pos + Vector3.left * leftside);
            green.SetPosition(1, pos - Vector3.left * scale * healthLength );
            red.SetPosition(0, pos - Vector3.left * scale * healthLength );
            red.SetPosition(1, pos - Vector3.left * rightside);
        }
    }
}
