using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using TMPro;
using UnityEngine.UI;

public class TurnInputManager : MonoBehaviour
{
    [SerializeField] private KeyCode preparationKey = KeyCode.Q;
    [SerializeField] private float actionInterval = 2.0f;
    [SerializeField] private float launchSpeed = 10f;
    [SerializeField] private float timeSlowMultiplier = 0.5f;
    // UI
    [SerializeField] private GameObject elapsePanel = null;
    [SerializeField] private Image powerBar = null;
    [SerializeField] private float powerBarSpeed = 0.1f;

    private bool slowed = false;
    private bool resetKey = true;
    private bool charging = false;

    public static Action onActionPrepare;
    public static Action onSkillExecute;


    private void OnEnable()
    {
        onActionPrepare += StartPowerGauge;
    }

    private void OnDisable()
    {
        onActionPrepare -= StartPowerGauge;
    }

    private void Update()
    {
        if (Input.GetKeyDown(preparationKey))
        {
            resetKey = true;
        }

        if (Input.GetKey(preparationKey) && onActionPrepare != null && !slowed && resetKey)
        {
            // time slows
            onActionPrepare.Invoke();
        }
    }

    private void StartPowerGauge()
    {
        slowed = true;
        charging = true;
        Time.timeScale = timeSlowMultiplier;
        resetKey = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        StartCoroutine(RaiseBar());
        elapsePanel.SetActive(true);
    }

    private IEnumerator RaiseBar()
    {
        float xScale = 0f;
        while (xScale <= 1f)
        {
            yield return null;

            xScale += powerBarSpeed;
            Vector3 currentScale = powerBar.GetComponent<RectTransform>().localScale;
            powerBar.GetComponent<RectTransform>().localScale = new Vector3(
                xScale, currentScale.y, currentScale.z);
            
            // if released Space key, launch
            if (Input.GetKeyUp(preparationKey))
            {
                break;
            }
        }

        // mandatory launch
        Launch(xScale);
    }

    private void Launch(float power)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        slowed = false;
        charging = false;
        Time.timeScale = 1f;
        elapsePanel.SetActive(false);
        Vector3 currentScale = powerBar.GetComponent<RectTransform>().localScale;
        powerBar.GetComponent<RectTransform>().localScale = new Vector3(
                0, currentScale.y, currentScale.z);

        float angle = transform.rotation.eulerAngles.z;
        Vector3 direction = new Vector3(-Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad), 0);
        GetComponent<Rigidbody2D>().AddForce(direction * launchSpeed * power);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public float GetTimeSlowMultiplier()
    {
        return timeSlowMultiplier;
    }

    public bool GetIsSlowed()
    {
        return slowed;
    }

    public void SetIsSlowed(bool isSlowed)
    {
        slowed = isSlowed;
    }

    public bool GetIsCharging()
    {
        return charging;
    }
}