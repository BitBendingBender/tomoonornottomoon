using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheMoon {

    public class NPCSkater : NPCController
    {

        // should not be accessible from outside.
        [SerializeField]
        protected Animator animator;

        void Start() {
            StartCoroutine(RandomJump());
        }

        void Update()
        {
            Move();
        }

        /// <summary>
        /// Let's skaters do a random fucking Ollie Yeeeeeahhh!
        /// </summary>
        IEnumerator RandomJump() {

            float randomTime = Random.Range(1f, 3f);

            yield return new WaitForSeconds(1.5f + randomTime);

            // random jump
            animator.SetTrigger("Jump");

        }

        /// <summary>
        /// Currently destroy when entering. Entity pooling could be a better solution.
        /// Maybe for another project where infinite amounts of critters are spawned.
        /// </summary>
        void OnTriggerEnter(Collider other) {

            if(other.CompareTag("NPCDestroyer")) {
                Destroy(gameObject);
            }
        }
    }
}