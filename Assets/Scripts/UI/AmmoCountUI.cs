using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCountUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoDisplay;

    private Skills shooter;

    private void Start() 
    {
        shooter = FindObjectOfType<Skills>();
    }

    private void Update() 
    {
        if (!shooter.HasSkill()) { return; }
        ammoDisplay.text = "Ammo: " + shooter.GetAmmoCount().ToString()
            + "/" + shooter.GetMaxAmmoCount().ToString();
    }
}

