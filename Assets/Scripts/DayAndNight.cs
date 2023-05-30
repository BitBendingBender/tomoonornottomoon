using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheMoon {

    public class DayAndNight : MonoBehaviour
    {

        public Gradient skyGradient;

        public Camera backgroundCamera;

        public Light sunlight, lanternLight;

        public AnimationCurve lightCurve, lanternCurve;

        public Renderer lanternRenderer;

        [Range(0f, 1f)]
        public float progression = 0f;

        /// <summary>
        /// Updates a couple values given the progress of the game.
        /// </summary>
        void Update() {

            backgroundCamera.backgroundColor = skyGradient.Evaluate(progression);

            sunlight.intensity = lightCurve.Evaluate(progression);
            lanternLight.intensity = lanternCurve.Evaluate(progression) * 20f;

            // appearantly to get a HDR Color, you just multiply it by a factor.
            // ranges from -1 to 2
            Color HDRColor = new Color(191f / 255f, 134 / 255f, 80f / 255f) * ((3f * Mathf.Pow(lanternCurve.Evaluate(progression), 4)) - 1);

            lanternRenderer.material.SetColor("_EmissionColor", HDRColor);

        }
    }
}
