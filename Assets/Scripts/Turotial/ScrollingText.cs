using System.Collections;
using Audio;
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
        
        public void ShowFinalText(AudioClip final)
        {
            AudioManager.Instance.GetComponent<AudioSource>().Stop();
            AudioManager.Instance.GetComponent<AudioSource>().PlayOneShot(final);
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

            while (AudioManager.Instance.GetComponent<AudioSource>().isPlaying)
                yield return null;
            AudioManager.Instance.GetComponent<AudioSource>().Play();
        }
    }
}
