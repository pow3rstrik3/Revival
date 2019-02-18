using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourController : MonoBehaviour
{
    private Vector3 newPosision;
    public Material fillColor;

    // Start is called before the first frame update
    void Start()
    {
        newPosision = transform.position;
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction* 100f, Color.red, 1f);
                if (hit.transform.tag == "Moveable")
                {
                    print("hitFound");
                    Transform objectHit = hit.transform;
                    newPosision = hit.point;
                    newPosision.y = 1;
                }
            }
        }
        if (Input.GetButtonDown("FillColor"))
        {
            Debug.DrawRay(transform.position, -transform.up*10 , Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0f))
            {
                if (hit.transform.tag == "Moveable")
                {
                    hit.transform.GetComponent<Renderer>().material = fillColor;
                }
            }
        }

        transform.position = Vector3.Lerp(transform.position, newPosision, Time.deltaTime);
    }

    
}
