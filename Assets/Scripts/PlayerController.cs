using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheMoon {
    
    public class PlayerController : MonoBehaviour
    {

        public Transform raycastOrigin;

        public Animator animator;

        public LayerMask raycastMask;

        InputActions actions;

        public GameObject hitContainer;

        public GameObject hitPrefab;

        public int moontasticHit;
        protected int points, lives = 3;

        // TODO: remodel this curve, or simply remove it.
        [SerializeField]
        AnimationCurve hitCalculation;

        void Awake()
        {
            
            GameManager.instance.inputManager.ingame.mooning.started += DoMooning;
            GameManager.instance.inputManager.ingame.mooning.canceled += (ctx) => { IsStanding(false); };

        }

        /// <summary>
        /// Delays player activation after opening menu
        /// </summary>
        public IEnumerator InitializePlayer() {

            points = 0;
            lives = 3;

            GameManager.instance.uiHelper.UpdatePoints(points);
            GameManager.instance.uiHelper.UpdateLives(lives);

            yield return new WaitForSeconds(2f);

            GameManager.instance.inputManager.ingame.Enable();

        }


        /// <summary>
        /// Handles the Mooning. Shoots a ray to
        /// Get distance to NPC.
        /// TODO:   Is Raycasting really necessary? Maybe we could just take X position.
        ///         But then, we would need to loop thorugh every instance and have a reference to them.
        /// TODO:   Add Moontastic Streak.
        /// </summary>
        void DoMooning(InputAction.CallbackContext context) {
            
            IsStanding(true);

            Ray ray = new Ray(raycastOrigin.position, raycastOrigin.forward * 5);

            bool hasHit = Physics.Raycast(ray, out RaycastHit hitInfo, 100f, raycastMask);

            GameObject newHit = Instantiate(hitPrefab);

            newHit.transform.parent = hitContainer.transform;
            newHit.transform.localPosition = Vector3.zero;

            // bail if no hits
            if(!hasHit) {
                
                newHit.GetComponent<HitController>().SetTexture(HitController.TextureType.Duh);
                RemoveLive();

                return;
            }

            // check if the NPC has been hit
            NPCController npc = hitInfo.collider.GetComponent<NPCController>();

            if(!npc) {
                Debug.LogError("An Object without NPCController was hit. That's simply impossible.");
            }

            // bail if no hits or if cop
            if(npc.beenHit || npc.IsCop()) {

                npc.beenHit = true;
                
                newHit.GetComponent<HitController>().SetTexture(HitController.TextureType.Duh);
                RemoveLive();

                return;
            }

            // get distance between hit point and actual object
            // half the size of the collider is the maximum witch currently is 3.
            // TODO: make this dynamic and harder targets.
            float distance = Mathf.Abs(hitInfo.point.x - hitInfo.transform.position.x) / 1.5f;

            npc.beenHit = true;

            int calculatedPoints = Mathf.RoundToInt(moontasticHit * hitCalculation.Evaluate(distance));

            if(calculatedPoints >= 75) {
                calculatedPoints = 100;
                newHit.GetComponent<HitController>().SetTexture(HitController.TextureType.Moontastic);
            } else if(calculatedPoints >= 50) {
                calculatedPoints = 75;
                newHit.GetComponent<HitController>().SetTexture(HitController.TextureType.Nice);
            } else if(calculatedPoints >= 25) {
                calculatedPoints = 50;
                newHit.GetComponent<HitController>().SetTexture(HitController.TextureType.Okay);
            } else if(calculatedPoints >= 0) {
                calculatedPoints = 25;
                newHit.GetComponent<HitController>().SetTexture(HitController.TextureType.Close);
            }
            
            UpdatePoints(calculatedPoints);

            // if the NPC Controller is time power up, count back time
            if(npc.IsTimePowerUp()) {
                npc.SetToTimePowerUp(false);
                GameManager.instance.currentGameTime -= 10f;
            }

        }

        /// <summary>
        /// Removes a live and updates UI.
        /// TODO:   Add Loosing screen.
        /// </summary>
        public void RemoveLive() {
            
            lives--;
            GameManager.instance.uiHelper.UpdateLives(lives);

            if(lives == 0) {
                GameManager.instance.SetState(GameState.GameOver);
            }
        }

        /// <summary>
        /// Updates points and UI.
        /// </summary>
        public void UpdatePoints(int calculatedPoints) {
            points += calculatedPoints;
            GameManager.instance.uiHelper.UpdatePoints(points);
        }

        /// <summary>
        /// Set's the Characters Animation state.
        /// </summary>
        void IsStanding(bool isStanding) {
            animator.SetBool("Standing", isStanding);
        }
        
    }

}
