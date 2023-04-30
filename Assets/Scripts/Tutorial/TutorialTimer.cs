using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTimer : MonoBehaviour
{
    [SerializeField] private float tutorialTime = 10f;
    [SerializeField] private GameObject nextButton = null;

    private float timer;

    private void Start()
    {
        timer = tutorialTime;
    }

    private void Update()
    {
        if (timer <= 0f)
        {
            nextButton.SetActive(true);
            return;
        }
        timer -= Time.deltaTime;
    }
}
