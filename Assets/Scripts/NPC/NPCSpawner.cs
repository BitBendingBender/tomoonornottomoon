using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheMoon {

    public class NPCSpawner : MonoBehaviour
    {

        // This field is here to tell the spawner controller which
        // spawners actually exist.
        [SerializeField]
        protected NPCSpawnerController spawnerController;

        public GameObject spawnable;

        void Start() {
            spawnerController.spawners.Add(this);
        }

        /// <summary>
        /// Short wrapper for coupling game progression to entity spawning.
        /// </summary>
        public NPCController SpawnEntity() {
            return SpawnEntity(Mathf.Clamp(GameManager.instance.dayAndNight.progression + .1f, .0f, .8f));
        }

        /// <summary>
        /// Spawns an entity and uses the progress to calculate speed up and stuff.
        /// </summary>
        public NPCController SpawnEntity(float gameProgress) {

            GameObject newlySpawned = Instantiate(spawnable);

            NPCController controller = newlySpawned.GetComponent<NPCController>();

            // lets speed up game Progess by the power Of 4
            controller.speed += controller.maxSpeedUp * Mathf.Pow(gameProgress, 4);

            // add a bit of random speed
            controller.speed += Random.Range(controller.speed * -.2f, controller.speed * .2f);

            // set rotation and position according to this GO
            newlySpawned.transform.position = transform.position;
            newlySpawned.transform.rotation = transform.rotation;

            return controller;

        }

    }

}
