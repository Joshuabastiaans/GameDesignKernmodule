using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowTutorialBox : MonoBehaviour
{
    [SerializeField] private Image tutorialImage;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private int maxOccurrences = 2;

    private Coroutine fadeCoroutine;
    private int occurrenceCount = 0;
    private bool isScriptEnabled = true;

    private void OnTriggerEnter(Collider other)
    {
        if (isScriptEnabled && other.CompareTag("Player") && occurrenceCount < maxOccurrences)
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }

            fadeCoroutine = StartCoroutine(FadeInTutorialBox());
        }
    }

    private IEnumerator FadeInTutorialBox()
    {
        tutorialImage.color = new Color(tutorialImage.color.r, tutorialImage.color.g, tutorialImage.color.b, 0f);
        tutorialImage.gameObject.SetActive(true);

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float normalizedTime = elapsedTime / fadeDuration;
            float alpha = Mathf.Lerp(0f, 1f, normalizedTime);

            tutorialImage.color = new Color(tutorialImage.color.r, tutorialImage.color.g, tutorialImage.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        tutorialImage.color = new Color(tutorialImage.color.r, tutorialImage.color.g, tutorialImage.color.b, 1f);

        // Increment the occurrence count
        occurrenceCount++;

        // Disable the script if the maximum occurrences limit is reached
        if (occurrenceCount >= maxOccurrences)
        {
            isScriptEnabled = false;
        }

        fadeCoroutine = null;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }

            fadeCoroutine = StartCoroutine(FadeOutTutorialBox());
        }
    }

    private IEnumerator FadeOutTutorialBox()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float normalizedTime = elapsedTime / fadeDuration;
            float alpha = Mathf.Lerp(1f, 0f, normalizedTime);

            tutorialImage.color = new Color(tutorialImage.color.r, tutorialImage.color.g, tutorialImage.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        tutorialImage.color = new Color(tutorialImage.color.r, tutorialImage.color.g, tutorialImage.color.b, 0f);
        tutorialImage.gameObject.SetActive(false);
        fadeCoroutine = null;
    }
}