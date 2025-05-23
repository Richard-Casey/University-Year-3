﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoisyFadeIn : MonoBehaviour
{
    public float fadeInTime = 2.0f; // Time for the fade-in to complete
    public float noiseFrequency = 18.31f; // How "noisy" the fade-in is
    public float startDelay = 4.0f; // Delay before the fade-in starts
    public float flickerRange = 0.5f; // Range of the flickering effect

    private Image image;
    private Color originalColor;
    private float timer = 0f;
    private bool fadeInComplete = false;

    void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
        image.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Start transparent
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(startDelay);

        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeInTime);
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        fadeInComplete = true;
    }

    void Update()
    {
        if (fadeInComplete)
        {
            // Post fade-in phase
            float noise = Mathf.PerlinNoise(Time.time * noiseFrequency, 0f);
            float alpha = Mathf.Lerp(1f - flickerRange, 1f, noise); // Flicker within the specified range
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
        }
    }
}