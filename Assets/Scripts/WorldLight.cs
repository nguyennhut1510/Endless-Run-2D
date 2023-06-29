using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;



namespace WorldTime
{
    [RequireComponent(typeof(Light2D))]
    public class WorldLight : MonoBehaviour
    {
        public float duration = 5f;

        [SerializeField] private Gradient gradient;
        private Light2D _light;
        private float _startTime;

        private void Awake()
        {
            _light = GetComponent<Light2D>();
            _startTime = Time.time;
            
        }


        // Update is called once per frame
        void Update()
        {
            float timeElapsed = Time.time - _startTime;
            float percentage = Mathf.Sin(timeElapsed / duration * Mathf.PI * 2) * 0.5f + 0.5f;

            percentage = Mathf.Clamp01(percentage);

            _light.color = gradient.Evaluate(percentage);
        }
    }

}
