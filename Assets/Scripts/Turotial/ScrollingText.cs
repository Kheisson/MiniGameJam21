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

        public void ShowText()
        {
            StartCoroutine(ShowDialogue());
        }
        
        private IEnumerator ShowDialogue()
        {
            textBox.color = new Color(255,255,255,255);
            foreach (var c in tutorialText.ToCharArray())
            {
                textBox.text += c;
                yield return new WaitForSecondsRealtime(0.025f);
            }
        }
    }
}
