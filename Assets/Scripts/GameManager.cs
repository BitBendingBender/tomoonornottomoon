using UnityEngine;
using System.Collections;

namespace TheMoon {
 
    /// <summary>
    /// TODO:   It would be nice looking into the unity EventSystem.
    ///         At the Moment, everything is very closely bound.
    ///         Using an EventBased System would make it possible to decouple a lot of functionality
    ///         For example changing the UISystem, resetting counters etc.
    /// </summary>
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance;

        public GameState currentGameState;

        public UIHelper uiHelper;

        public InputActions inputManager;

        public PlayerController player;

        public NPCSpawnerController spawnController;

        public DayAndNight dayAndNight;

        public float currentGameTime;

        public float maximumGameTime;

        /**
        * Basically sets up the game.
        */
        private void Awake()
        {

            // singleton
            if (instance == null) instance = this;
            else Destroy(gameObject);

            inputManager = new InputActions();

            // bind input manager menu space to start game
            inputManager.menu.startgame.started += (ctx) => { SetState(GameState.InGame); };
            inputManager.gameover.startgame.started += (ctx) => { SetState(GameState.InGame); };

            // at the beginning, we start with the currentGameState
            SetState(currentGameState);

        }

        /// <summary>
        /// The best possible way to implement this would be
        /// to actually make the game start at this point if needed.
        /// this way we could skip stuff.
        /// </summary>
        public void SetState(GameState state) {

            switch(state) {

                case GameState.Menu:

                        currentGameTime = 0f;

                        // set input state here.
                        // for another time, it would be nice
                        // if it was possible to do an interface for each stateable object/manager.
                        // now this will bloat and would get bigger for every state possible
                        inputManager.gameover.Disable();
                        inputManager.ingame.Disable();
                        inputManager.menu.Enable();

                    break;

                case GameState.InGame:

                        currentGameTime = 0f;
                        spawnController.timeSinceSpawnStart = 0f;

                        inputManager.gameover.Disable();
                        inputManager.menu.Disable();

                        // instantly moove all active 
                        StartCoroutine(player.InitializePlayer());

                    break;

                case GameState.GameOver:

                        // reset all settings here to slow game down.
                        // TODO: implement lerping for smoother transition.
                        currentGameTime = 0f;
                        spawnController.timeSinceSpawnStart = 0f;

                        inputManager.ingame.Disable();

                        StartCoroutine(LateGameOverEnabling());

                    break;
            }

            // set UI State
            uiHelper.SetState(state);

            currentGameState = state;

        }

        /// <summary>
        /// When game overing because of no more lives, pressing spaces immediately triggers restart.
        /// TODO: Is there a possibility to callback in next frame?
        /// </summary>
        public IEnumerator LateGameOverEnabling() {
            yield return new WaitForSeconds(1f);
            inputManager.gameover.Enable();
        } 

        void Update() {

               switch(currentGameState) {

                case GameState.InGame:

                        currentGameTime += Time.deltaTime;

                        dayAndNight.progression = Mathf.Clamp(currentGameTime / maximumGameTime, 0f, 1f);

                        if(currentGameTime >= maximumGameTime) {
                            SetState(GameState.GameOver);
                        }

                    break;
            } 

        }
        
    }

    /// <summary>
    /// Possible gamestates.
    /// </summary>
    public enum GameState {
        Menu,
        InGame,
        GameOver,
    }
}
