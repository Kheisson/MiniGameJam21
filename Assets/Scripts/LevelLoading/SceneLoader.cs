using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelLoading
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private float levelRestartDelay = 1f;
        public static SceneLoader Instance { get; private set; }


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public IEnumerator GameOver()
        {
            yield return new WaitForSecondsRealtime(levelRestartDelay);
            RestartScene();
        }


        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }

        public void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}