using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheMoon {

    public class NPCSpawnerController : MonoBehaviour
    {
    
        public List<NPCSpawner> spawners;

        public float startSpawnSpeed;

        public float minimumSpawnSpeed;

        public float maximumSpeedAfterSeconds;

        [SerializeField]
        float spawnSpeed;

        public float timeSinceSpawnStart = 0f;

        [SerializeField]
        AnimationCurve spawnSpeedUpCurve;

        // on start, we invoke spawning
        void OnEnable() {
            StartCoroutine(Spawn());
        }

        void OnDisable() {
            StopCoroutine(Spawn());
        }

        void Update() {
            
            if(GameManager.instance.currentGameState == GameState.InGame) {
                
                timeSinceSpawnStart += Time.deltaTime;
                spawnSpeed = minimumSpawnSpeed + startSpawnSpeed * (1f - spawnSpeedUpCurve.Evaluate(timeSinceSpawnStart / maximumSpeedAfterSeconds)); 

            }

        }


        IEnumerator Spawn() {
            
            // this wile loop looks INSANLY weird.
            // but appearently that how you you coroutines.
            while(true) {
            
                // add 50% random +- to spawn time
                float tenPercentOfSpawnSpeed = spawnSpeed * 0.5f;
                float randomDifference = Random.Range(-1 * tenPercentOfSpawnSpeed, tenPercentOfSpawnSpeed);
                
                // lets delay at start
                yield return new WaitForSeconds(spawnSpeed + randomDifference);

                // get a random spawner
                NPCSpawner randomSelected = spawners[Random.Range(0, spawners.Count)];

                // SPAWN!
                randomSelected.SpawnEntity();

            }
        }
    }
}