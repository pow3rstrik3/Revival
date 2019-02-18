using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourController : MonoBehaviour
{
    public Material darkMaterial;
    private GameObject targetObject = null;

    void Update()
    {
        if (targetObject == null)
        {
            FindTargetObject();
        }
        Debug.Log("Target Object: " + targetObject);
    }

    private void FindTargetObject()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>() as GameObject[];
        foreach (GameObject obj in allObjects)
        {
            if (obj.GetComponent<MeshRenderer>().material != darkMaterial)
            {
                targetObject = gameObject;
                break;
            }
        }
    }
}
