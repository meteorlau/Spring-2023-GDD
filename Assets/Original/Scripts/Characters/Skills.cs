using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Skill
{
    Pistol,
    Minigun,
    Shotgun,
    Rocket
}

public class Skills : MonoBehaviour
{
    [SerializeField] private List<GameObject> skillsList =  new List<GameObject>();

    // index starts at 0
    private int currentGunIndex;
    private CurrentGunUI gunUI;
    private TurnManager turnManager;

    void Start()
    {
        currentGunIndex = 0;
        gunUI = FindObjectOfType<CurrentGunUI>();
        turnManager = GetComponent<TurnManager>();
    }

    private void Update()
    {
        // check for skill keypress
        SelectSkill();
        ApplyCurrentSkill();
    }

    private Gun RetrieveBinding(int key)
    {
        return skillsList[key].GetComponent<Gun>();
    }

    private void SelectSkill()
    {
        // use mouse wheel scrolling to select the weapon skill we are using
        bool changed = false;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            // scrolling up
            if (currentGunIndex + 1 < skillsList.Count)
            {
                currentGunIndex += 1;
                changed = true;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentGunIndex - 1 >= 0)
            {
                currentGunIndex -= 1;
                changed = true;
            }
        }

        if (changed)
        {
            gunUI.SwitchGun(RetrieveBinding(currentGunIndex).GetSkillType());
        }
    }

    public void Reload()
    {
        if (RetrieveBinding(currentGunIndex) == null)
        {
            Debug.LogError("Current skill does not have Gun.cs");
        }
        RetrieveBinding(currentGunIndex).Reload();
    }

    // Called whenever player picks up a new weapon
    public void Acquire(GameObject obj, Skill skill)
    {
        skillsList.Add(obj);
        currentGunIndex = skillsList.Count - 1;
        gunUI.SwitchGun(skill);
    }

    public bool HasSkill()
    {
        return skillsList.Count > 0;
    }

    public int GetAmmoCount()
    {
        return RetrieveBinding(currentGunIndex).ammoCount();
    }

    public int GetMaxAmmoCount()
    {
        return RetrieveBinding(currentGunIndex).maxAmmoCount();
    }

    public Gun GetCurrentSkill()
    {
        if (currentGunIndex < skillsList.Count)
        {
            return RetrieveBinding(currentGunIndex);
        }
        return null;
    }

    public void ApplyCurrentSkill()
    {
        if (GetCurrentSkill() == null || turnManager.GetIsSlowed()) { return; }
        GetCurrentSkill().Apply();
    }
}
