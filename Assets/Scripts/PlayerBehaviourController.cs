using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourController : MonoBehaviour
{
    private Vector3 newPosision;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    Transform objectHit = hit.transform;
                    newPosision = hit.point;
                    newPosision.y = 1;
                }
            }
        }

        transform.position = Vector3.Lerp(transform.position, newPosision, Time.deltaTime);
    }

    
}
