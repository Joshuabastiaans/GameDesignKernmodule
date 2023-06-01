using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TeleportFall : MonoBehaviour
{
    public Transform teleportDestination;
    public Image fadeScreen;
    public float fadeDuration = 1f;

    private bool isFading;
    private GameObject playerObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered the teleporter");

        if (other.CompareTag("Player") && !isFading)
        {
            playerObject = other.gameObject;
            StartCoroutine(TeleportPlayer());
        }
    }

    private IEnumerator TeleportPlayer()
    {
        isFading = true;

        // Fade to black
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = timer / fadeDuration;
            fadeScreen.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        fadeScreen.color = Color.black;

        // Teleport the player to the destination
        playerObject.transform.position = teleportDestination.position;

        // Fade back to the game
        timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = 1f - (timer / fadeDuration);
            fadeScreen.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        fadeScreen.color = Color.clear;

        isFading = false;
    }
}
