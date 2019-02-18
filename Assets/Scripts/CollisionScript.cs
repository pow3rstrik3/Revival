using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class CollisionScript : MonoBehaviour
    {

        public GameObject player;
        public Material color;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player");
            color = Resources.Load("Materials/Color") as Material;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter(Collision collision)
        { 
            if (collision.gameObject.tag == "Pickup")
            {
                Destroy(collision.gameObject);
                player.GetComponent<MeshRenderer>().material = color;
            }
        }
    }
}
