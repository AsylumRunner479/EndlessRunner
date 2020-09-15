using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Claire
{
    public class DamageManager : MonoBehaviour
    {
        #region variables
        [Header("Life")]
        private int health = 3;
       public static bool isDead = false;
        [Header("Canvas")]
        [SerializeField] Image pannel;
        public float waitTime = 10f;
        #endregion
        #region blue voids
        private void Start()
        {
            health = 3;
        }
        private void Update()
        {
        #if UNITY_EDITOR
            if (Input.GetKey(KeyCode.J))
            {
                Death();
            }
        #endif
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Segment"))
            {
                Debug.Log("Segment");
                Damage(1);
            }
            if (collision.gameObject.CompareTag("Prop"))
            {
                Debug.Log("Prop");
                Damage(1);
                collision.gameObject.SetActive(false);
            }
        }
        #endregion
        #region yellow voids
        public void Damage(int damage)
        {
            health -= damage;
            if (health <= 0 && isDead)
            {
                Death();
            }
        }
        public void Death()
        {
            isDead = true;
            pannel.color = Color.Lerp(Color.clear, Color.black, waitTime);
            
        }
        #endregion
    }
}