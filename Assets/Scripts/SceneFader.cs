using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage; 
    public float fadeDuration = 1f;

    private bool isFaded = false;
    private Coroutine currentFade = null;

    private void Start()
    {
        isFaded = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (currentFade != null)
                StopCoroutine(currentFade);

            if (isFaded)
                currentFade = StartCoroutine(FadeOut());
            else
                currentFade = StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        isFaded = true;
        float t = 0f;
        Color color = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;
        currentFade = null;
    }

    IEnumerator FadeOut()
    {
        isFaded = false;
        float t = 0f;
        Color color = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0f;
        fadeImage.color = color;
        currentFade = null;
    }
}
