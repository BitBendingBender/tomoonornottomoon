using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace TheMoon {

    public class UIHelper : MonoBehaviour
    {
        
        public UIDocument document;

        public AnimationCurve curveForFade;

        protected VisualElement fadingText, fadingTextGameOver, mainContainer, livesContainer;

        protected TextElement pointsText, gameOverText;

        protected readonly GameState currentGameState;

        void Awake() {

            fadingText = document.rootVisualElement.Q("start-game");
            fadingTextGameOver = document.rootVisualElement.Q("restart-game");
            mainContainer = document.rootVisualElement.Q("main-container");
            livesContainer = document.rootVisualElement.Q("lives-container");
            pointsText = document.rootVisualElement.Q<TextElement>("points");
            gameOverText = document.rootVisualElement.Q<TextElement>("final-score");

        }

        void Update() {

            // lets see how we can do this only when state X
            // maybe we can use GameManagerState?
            // Or Should we rather duplicate the state? But that doesnt make sense to me.
            fadingText.style.opacity = curveForFade.Evaluate(Time.time);
            fadingTextGameOver.style.opacity = curveForFade.Evaluate(Time.time);

        }

        /// <summary>
        /// Update the UI according to the game state.
        /// </summary>
        public void SetState(GameState state) {
            
            switch(state) {

                case GameState.Menu:
                        mainContainer.RemoveFromClassList("state-gameover");
                        mainContainer.RemoveFromClassList("state-ingame");
                        mainContainer.AddToClassList("state-menu");
                    break;

                case GameState.InGame:

                        // make sure the lives container is on three lives
                        mainContainer.RemoveFromClassList("state-gameover");
                        mainContainer.RemoveFromClassList("state-menu");
                        mainContainer.AddToClassList("state-ingame");

                    break;
                case GameState.GameOver:

                        // update points, this hacky af
                        gameOverText.text = "FINAL SCORE: " + pointsText.text;

                        mainContainer.RemoveFromClassList("state-menu");
                        mainContainer.RemoveFromClassList("state-ingame");
                        mainContainer.AddToClassList("state-gameover");

                    break;

                default:
                    Debug.Log("GameState " + state + " is not implemented.");
                    break;

            }

        }

        /// <summary>
        /// Update lives in UI by fading in/out lives images by setting class accordingly
        /// </summary>
        public void UpdateLives(int lives) {

            switch(lives) {
                case 3:
                
                        if(!livesContainer.ClassListContains("three-lives")) {
                            livesContainer.ClearClassList();
                            livesContainer.AddToClassList("three-lives");
                        }

                    break;
                case 2:
                
                        livesContainer.ClearClassList();
                        livesContainer.AddToClassList("two-lives");

                    break;
                case 1:
                
                        livesContainer.ClearClassList();
                        livesContainer.AddToClassList("one-live");

                    break;
                case 0:
                
                        livesContainer.ClearClassList();
                        livesContainer.AddToClassList("no-lives");

                    break;
            }

        }

        /// <summary>
        /// Update points in UI
        /// </summary>
        public void UpdatePoints(int points) {

            // add preceeding 0
            int pointsTextLength = points.ToString("D").Length;

            if(pointsTextLength < 7) {
                pointsText.text = points.ToString("D" + (pointsTextLength + (7 - pointsTextLength)));
            } else {
                pointsText.text = points.ToString("D");
            }
        } 

    }
}
