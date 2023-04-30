using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangosteenDotManager : MonoBehaviour
{
    [SerializeField] private GameObject dots = null;
    [SerializeField] private float dotPersistanceTime = 5f;

    private float timer;
    private bool startCountdown = false;

    public void EnableDots()
    {
        timer = dotPersistanceTime;
        dots.SetActive(true);
        startCountdown = true;
    }

    private void Update()
    {
        if (!startCountdown) { return; }

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            // disable dots
            dots.SetActive(false);
            startCountdown = false;
        }
    }
}
