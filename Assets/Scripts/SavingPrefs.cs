using Serializable = System.SerializableAttribute;
using UnityEngine;
namespace Claire
{
    public class SavingPrefs : MonoBehaviour
    {
        #region variables
        public NumberManager numberM;
        [Serializable] public struct Player
        {
            public string name;
            public int score;
        };
        public Player cHigh;
        #endregion
        #region blue voids
        private void Awake()
        {
            //find the player
            numberM = GameObject.FindGameObjectWithTag("Player").GetComponent<NumberManager>();
            //if data isn't avaliable
            if (!PlayerPrefs.HasKey("Name"))
            {
                //make a fresh save
                PlayerPrefs.DeleteAll();
                FirstLoad();
                Save();
            }
            //get saved high score for bragging rights
            cHigh.name = PlayerPrefs.GetString("Name");
            cHigh.score = PlayerPrefs.GetInt("Score");
        }
        public void Update()
        {
            //placeholder - make a new function to attach to button
            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
        }
        #endregion
        #region yellow voids
        private void FirstLoad()
        {
            //default variables for first time playing
            numberM.currentScore = 0;
        }
        public void Save()
        {   //if the player's score is higher than the saved score
            if ((int)transform.position.z > PlayerPrefs.GetInt("Score"))
            {   // save that as new high score
                PlayerPrefs.SetString("Name", numberM.playerName);
                PlayerPrefs.SetInt("Score", (int)transform.position.z);
                PlayerPrefs.Save();
            }
        }
        #endregion
    }
}
/* Main Menu
 * Save Score
 * High Score
 * -----
 * Collision - On Collision, remove 1HP
 * -----
 * Death - When HP = 0
 * New HS Name - if new HS allow Text Input, else Retry/Return to menu
 * Score Gain - if was new HS and name input filled then hit Save then load the Retry/Reload to menu
 * -----
 * Respawn/Restart Game (Reload scene) - this is the Retry/Return menu
 * -----
 * Animation Controller
 */