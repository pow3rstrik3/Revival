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
        if (targetObject == null)
        {
            FindTargetObject();
        }
        Debug.Log(Vector3.Distance(transform.position, targetObject.transform.position));
        if (Vector3.Distance(transform.position, targetObject.transform.position) >= distanceToTransform)
        {
            transform.LookAt(targetObject.transform);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
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
}
