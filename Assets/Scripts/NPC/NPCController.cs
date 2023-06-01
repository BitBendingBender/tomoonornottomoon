using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheMoon {

    public class NPCController : MonoBehaviour
    {

        public float speed;

        public bool beenHit;

        public GameObject timeEmitter;
        public GameObject copHat;

        // this is not used here but in the spawner to update speed by game progress
        public float maxSpeedUp;

        bool isTimePowerup;

        bool isCop;

        void Update()
        {
            Move();
        }

        /// <summary>
        /// Moves the NPC.
        /// </summary>
        protected void Move() {

            // if hit, drastically speed up the npc
            float calculatedSpeed = (Time.deltaTime * speed) * (beenHit ? 12f : 1f);

            transform.Translate(transform.forward * calculatedSpeed, Space.World);
            
        }

        /// <summary>
        /// Short wrapper allways setting actve.
        /// </summary>  
        public void SetToTimePowerUp() {
            SetToTimePowerUp(true);
        }

        /// <summary>
        /// Short Wrapper to set to cop
        /// </summary>  
        public void SetToCop() {
            SetToCop(true);
        }

        /// <summary>
        /// Sets the NPC to a time power up.
        /// </summary>
        public void SetToCop(bool active) {
            
            if(copHat != null) {
                isCop = active;
                copHat.SetActive(active);
            }

        }

        /// <summary>
        /// Sets the NPC to a time power up.
        /// </summary>
        public void SetToTimePowerUp(bool active) {
            
            if(timeEmitter != null) {
                isTimePowerup = active;
                timeEmitter.SetActive(active);
            }

        }

        /// <summary>
        /// Returns wether the current NPC is a time power.
        /// </summary>
        public bool IsTimePowerUp() {
            return isTimePowerup;
        }

        /// <summary>
        /// Returns wether the current NPC is a cop.
        /// </summary>
        public bool IsCop() {
            return isCop;
        }


        /// <summary>
        /// Kills the NPC.
        /// TODO:   Implement NPC poooling.
        /// </summary>
        void OnTriggerEnter(Collider other) {

            if(other.CompareTag("NPCDestroyer")) {
                Destroy(gameObject);
            }

        }
    }
}