using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class CollisionScript : MonoBehaviour
    {

        public GameObject player;
        public Material color;
        private float pickedUp;

        public Slider slider;

        // Create a property to handle the slider's value
        private float currentValue = 0f;
        public float CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                slider.value = currentValue;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player");
            color = Resources.Load("Materials/Color") as Material;
            slider = GameObject.Find("Slider").GetComponent<Slider>();
            CurrentValue = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            CurrentValue = (pickedUp / 10);
        }

        void OnCollisionEnter(Collision collision)
        { 
            if (collision.gameObject.tag == "Pickup")
            {
                Destroy(collision.gameObject);
                player.GetComponent<MeshRenderer>().material = color;
                pickedUp++;
            }
        }
    }
}
