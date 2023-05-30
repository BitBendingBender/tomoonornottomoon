using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheMoon  {


    /// <summary>
    /// Adds a bit of camera movement. So it's a little more dynamic.
    /// </summary>
    public class CameraController : MonoBehaviour
    {

        public GameObject pivotPoint;

        [Range(0f, 10f)]
        public float cursorFollow;

        Quaternion rotationToLerpTo;

        Vector3 startingPos;

        void Awake() {
            startingPos = pivotPoint.transform.position;
        }
        
        void Update() {

            // add a bit of mouse follow
            // interpolate from -1 to 1 x and y
            Vector3 interpolatedMousePos = new Vector3(
                (Input.mousePosition.y / (Screen.width * .5f)) - 1,
                (Input.mousePosition.x / (Screen.width * .5f)) - 1,
                0f
            ) * cursorFollow;

            rotationToLerpTo = Quaternion.Euler(
                interpolatedMousePos.x,
                interpolatedMousePos.y,
                interpolatedMousePos.z
            );

            pivotPoint.transform.rotation = Quaternion.Lerp(pivotPoint.transform.rotation, rotationToLerpTo, .01f);

            // slow down time...
            float t = Time.time / 10f;

            // add just a tiny bit of movement, maybe sine combined with noise
            pivotPoint.transform.position = startingPos + new Vector3(
                Mathf.Sin(t * Mathf.PI),
                Mathf.Sin((t + 100f) * Mathf.PI), // move phase a bit
                0f
            ) * .1f;
            
        }

    }
}

