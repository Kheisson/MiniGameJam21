using System.Collections;
using PlayerControl;
using UnityEngine;
using TMPro;

namespace Turotial
{
    public class ScrollingText : MonoBehaviour
    {
        [SerializeField] private TMP_Text textBox;
        [SerializeField] [TextArea(15,20)] private string tutorialText;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private GameObject player;
        
        private void Start()
        {
            Time.timeScale = 0f;
            canvasGroup.alpha = 0;
            player.GetComponent<PlayerInput>().enabled = false;
            StartCoroutine(ShowDialogue());
        }

        private IEnumerator ShowDialogue()
        {
            canvasGroup.alpha = 1;
            foreach (var c in tutorialText.ToCharArray())
            {
                textBox.text += c;
                yield return new WaitForSecondsRealtime(0.025f);
            }
            Time.timeScale = 1f;
            player.GetComponent<PlayerInput>().enabled = true;
        }
    }
}
