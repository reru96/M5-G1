using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class ChangeColor : MonoBehaviour
{
    public Renderer redLight, yellowLight, greenLight;
    public TextMeshProUGUI countdownText;
    public float greenDuration = 3f, yellowDuration = 1f, redDuration = 3f;

    private void Start()
    {
        StartCoroutine(ChangeLight());
    }

    IEnumerator ChangeLight()
    {
        while (true)
        {
            SetLight(Color.red);
            yield return StartCoroutine(Countdown(redDuration));

            SetLight(Color.yellow);
            yield return StartCoroutine(Countdown(yellowDuration));

            SetLight(Color.green);
            yield return StartCoroutine(Countdown(greenDuration));
        }
    }

    void SetLight(Color color)
    {
        redLight.material.color = (color == Color.red) ? Color.red : Color.white;
        yellowLight.material.color = (color == Color.yellow) ? Color.yellow : Color.white;
        greenLight.material.color = (color == Color.green) ? Color.green : Color.white;
    }

    IEnumerator Countdown(float duration)
    {
        float timer = duration;
        while (timer > 0)
        {
            if (countdownText != null)
                countdownText.text = $"Il semaforo si aggiorna tra {timer:F1} secondi";
            yield return new WaitForSeconds(0.1f);
            timer -= 0.1f;
        }
    }
}
