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

        [Range(0f, 1f)]
        public float progression = 0f;

        void Update() {

            backgroundCamera.backgroundColor = skyGradient.Evaluate(progression);
            
            sunlight.intensity = lightCurve.Evaluate(progression);
            lanternLight.intensity = lanternCurve.Evaluate(progression);

        }
    }
}
