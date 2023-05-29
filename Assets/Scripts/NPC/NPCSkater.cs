using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheMoon {

    public class NPCSkater : NPCController
    {

        [SerializeField]
        protected Animator animator;

        void Start() {
            StartCoroutine(RandomJump());
        }

        void Update()
        {
            Move();
        }

        IEnumerator RandomJump() {

            float randomTime = Random.Range(1f, 3f);

            yield return new WaitForSeconds(1.5f + randomTime);

            // random jump
            animator.SetTrigger("Jump");
            

        }

        // Kills the NPC
        void OnTriggerEnter(Collider other) {

            if(other.CompareTag("NPCDestroyer")) {
                Destroy(gameObject);
            }

        }
    }
}