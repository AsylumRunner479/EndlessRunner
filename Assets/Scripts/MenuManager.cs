﻿using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Claire
{
    public class MenuManager : MonoBehaviour
    {
        public void ChangeScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        public void QuitGame()
        {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
        }
    }
}