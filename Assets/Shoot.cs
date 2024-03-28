using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Material[] mats;
    public GameObject target;
    LineRenderer line;
    public int segmentCount = 4;
    public float chaos = 0.3f;
    private float lastShotTime = 0;
    float shotDelay = 0.69f;
    public float shootingRange = 10000f;
    float timesincestart = 0.0f;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }

    void Update()
    {
        timesincestart += Time.deltaTime;

        if (timesincestart > lastShotTime + shotDelay)
        {
            TakeShot();
        }
    }

    void TakeShot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, shootingRange))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.gameObject.tag == "Target")
            {

                line.material = mats[0]; // Consider setting this once if it doesn't need to change every shot
                line.positionCount = 2; // Start and end points
                line.SetPosition(0, transform.position); // Starting at the shooter
                line.SetPosition(1, hit.point); // Ending at the target

                StartCoroutine(DisableLine()); // Reset the line after a short duration


                Target target = hit.collider.gameObject.GetComponent<Target>();
                if(target)
                {
                    target.takehit();
                }
            }
        }
    }

    IEnumerator DisableLine()
    {
        lastShotTime = timesincestart;
        yield return new WaitForSeconds(0.1f); 
        line.positionCount = 0;
    }
}
