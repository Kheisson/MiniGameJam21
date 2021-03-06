using UnityEngine;

namespace LevelLoading
{
    public class LevelExit : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                SceneLoader.Instance.LoadNextLevel();
            }
        }
    }
}
