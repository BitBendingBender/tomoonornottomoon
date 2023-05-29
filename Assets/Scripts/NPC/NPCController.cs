using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheMoon {

    public class NPCController : MonoBehaviour
    {

        public float speed;

        public bool beenHit;

        // this is not used here but in the spawner to update speed by game progress
        public float maxSpeedUp;

        void Update()
        {
            Move();
        }

        protected void Move() {

            // if hit, drastically speed up the npc
            float calculatedSpeed = (Time.deltaTime * speed) * (beenHit ? 12f : 1f);

            transform.Translate(transform.forward * calculatedSpeed, Space.World);
            
        }

        // Kills the NPC
        void OnTriggerEnter(Collider other) {

            if(other.CompareTag("NPCDestroyer")) {
                Destroy(gameObject);
            }

        }
    }
}