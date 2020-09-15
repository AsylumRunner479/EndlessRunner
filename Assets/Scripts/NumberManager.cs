using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Claire
{
    [RequireComponent(typeof(Collider))]
    public class NumberManager : MonoBehaviour
    {
        #region variables
        [Header("Score")]
        static int highScore;
        public int currentScore;
        public string playerName;
        public float now;
        [Header("Health")]
        public int maxHealth = 3;
        public int currentHealth;
        static bool isDead = false;
        [Header("User Interface")]
        public Text cScore;
        #endregion
        void Start()
        {
            Debug.Log("What?");
            currentHealth = maxHealth;
            currentHealth = 0;
            now = Time.time;
        }
        private void Update()
        {
            currentScore = (int)transform.position.z;
            cScore.text = currentScore.ToString();
        }
        void FixedUpdate()
        {
          
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Trigger"))
            {
                currentHealth--;
            }
        }
    }
}