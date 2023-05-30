using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheMoon {
    public class HitController : MonoBehaviour
    {
        
        // I know, this is nasty as fuck but i don't
        // know how else to solve this atm.
        public Texture moontastic, nice, okay, close, duh;

        [SerializeField]
        protected AnimationCurve curve;
    
        float tStart = 0f;

        Vector3 startPos;

        Renderer meshRenderer;

        public enum TextureType {
            Moontastic,
            Nice,
            Okay,
            Close,
            Duh
        }

        void Awake() {
            meshRenderer = GetComponent<Renderer>();
            StartCoroutine(DestroyAfter());
        }

        IEnumerator DestroyAfter() {
            yield return new WaitForSeconds(1.33f);
            Destroy(gameObject);
        }

        void Update() {
            transform.localPosition = startPos + (Vector3.up * .5f * curve.Evaluate(tStart));
            tStart += Time.deltaTime;
        }

        /// <summary>
        /// Set's the Texture of the hit.
        /// TODO: If theres still time left, add particle effect.
        ///</summary>
        public void SetTexture(TextureType type) {

            switch(type) {
                case TextureType.Moontastic:
                    meshRenderer.material.SetTexture("_BaseMap", moontastic);
                    break;
                case TextureType.Nice:
                    meshRenderer.material.SetTexture("_BaseMap", nice);
                    break;
                case TextureType.Okay:
                    meshRenderer.material.SetTexture("_BaseMap", okay);
                    break;
                case TextureType.Close:
                    meshRenderer.material.SetTexture("_BaseMap", close);
                    break;
                case TextureType.Duh:
                    meshRenderer.material.SetTexture("_BaseMap", duh);
                    break;
            }

        }

    }

}
