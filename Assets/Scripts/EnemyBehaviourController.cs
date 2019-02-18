using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourController : MonoBehaviour
{
    public Material darkMaterial;
    public float moveSpeed;
    public float distanceToTransform;
    private GameObject targetObject = null;

    void Update()
    {
        if (!CheckIfGameFinished())
        {
            if (targetObject == null)
            {
                FindTargetObject();
            }
            else
            {
                if (Vector3.Distance(transform.position, targetObject.transform.position) >= distanceToTransform)
                {
                    var heading = targetObject.transform.position - transform.position;
                    var distance = heading.magnitude;
                    var direction = heading / distance;
                    direction.y = 0;
                    transform.Translate(direction * moveSpeed * Time.deltaTime);
                }
                else
                {
                    targetObject.GetComponent<Renderer>().material = darkMaterial;
                    targetObject = null;
                }
            }
        }
    }

    private void FindTargetObject()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>() as GameObject[];
        foreach (GameObject obj in allObjects)
        {

            if ((obj.tag != "Enemy") && (obj.tag != "Player"))
            {
                if (obj.GetComponent<Renderer>() != null)
                {
                    if (obj.GetComponent<Renderer>().sharedMaterial != darkMaterial)
                    {
                        targetObject = obj;
                        break;
                    }
                }
            }
        }
    }

    private bool CheckIfGameFinished()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>() as GameObject[];
        foreach (GameObject obj in allObjects)
        {
            if (obj.GetComponent<Renderer>() != null)
            {
                if (obj.GetComponent<Renderer>().sharedMaterial == darkMaterial)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
