using System.Collections;
using UnityEngine;
using TMPro;

namespace Turotial
{
    public class ScrollingText : MonoBehaviour
    {
        [SerializeField] private TMP_Text textBox;
        [SerializeField] private string tutorialText;
        [SerializeField] private CanvasGroup canvasGroup;

        private float _defaultTimer = 1f;
        private void Start()
        {
            Time.timeScale = 0f;
            canvasGroup.alpha = 0;
            StartCoroutine(ShowDialogue());
        }

        private IEnumerator ShowDialogue()
        {
            yield return new WaitForSecondsRealtime(_defaultTimer);
            canvasGroup.alpha = 1;
            foreach (var c in tutorialText.ToCharArray())
            {
                textBox.text += c;
                yield return new WaitForSecondsRealtime(0.05f);
            }
            yield return new WaitForSecondsRealtime(_defaultTimer);
            Time.timeScale = 1f;
        }
    }
}
