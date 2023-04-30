using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum SkillType
{
    Pistol,
    Minigun,
    Shotgun,
    Rocket,
    BulletMeteor,
    BulletStream,
    None
}

[System.Serializable]
public struct Combination
{
    public SkillType[] operands;
    public SkillType result;
}

public class SkillInputManager : MonoBehaviour
{
    [SerializeField] private SkillType[] skillTypeKeyMapping;
    [SerializeField] private Combination[] skillCombinationTable;
    [SerializeField] private KeyCode actionKey = KeyCode.E;
    [SerializeField] private Skill[] projectiles;
    [SerializeField] private Transform firingOrigin = null;
    [SerializeField] private float bulletForce = 10f;
    [SerializeField] private float mouseFollowRotationSpeed = 360f;

    // UI
    [SerializeField] private Image[] armourySlots;
    [SerializeField] private GameObject armouryUI = null;
    [SerializeField] private GameObject elapsePanel = null;
    [SerializeField] private float selectedAlpha = 0.5f;

    private TurnInputManager turnInputManager;
    private List<SkillType> selectedSkills = new List<SkillType>();

    private void Start()
    {
        turnInputManager = GetComponent<TurnInputManager>();
    }

    private void Update()
    {
        bool justEnabled = false;
        if (Input.GetKeyDown(actionKey) && !turnInputManager.GetIsSlowed())
        {
            Time.timeScale = turnInputManager.GetTimeSlowMultiplier();
            elapsePanel.SetActive(true);
            armouryUI.SetActive(true);

            turnInputManager.SetIsSlowed(true);
            selectedSkills = new List<SkillType>();
            justEnabled = true;
        }

        if (armouryUI.activeSelf)
        {
            // check for skill keypress
            SelectSkill();
        }

        if (Input.GetKeyDown(actionKey) && turnInputManager.GetIsSlowed() && !justEnabled && 
            !turnInputManager.GetIsCharging())
        {
            ApplySelectedSkills();
        }
    }

    private void SelectSkill()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (selectedSkills.Contains(skillTypeKeyMapping[0]))
            {
                // deselect it
                selectedSkills.Remove(skillTypeKeyMapping[0]);
                Color prevColor = armourySlots[0].color;
                prevColor.a = 1f;
                armourySlots[0].color = prevColor;
            }
            else
            {
                selectedSkills.Add(skillTypeKeyMapping[0]);
                Color prevColor = armourySlots[0].color;
                prevColor.a = selectedAlpha;
                armourySlots[0].color = prevColor;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (selectedSkills.Contains(skillTypeKeyMapping[1])
                && skillTypeKeyMapping.Length > 1)
            {
                // deselect it
                selectedSkills.Remove(skillTypeKeyMapping[1]);
                Color prevColor = armourySlots[1].color;
                prevColor.a = 1f;
                armourySlots[1].color = prevColor;
            }
            else if (skillTypeKeyMapping.Length > 1)
            {
                selectedSkills.Add(skillTypeKeyMapping[1]);
                Color prevColor = armourySlots[1].color;
                prevColor.a = selectedAlpha;
                armourySlots[1].color = prevColor;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (selectedSkills.Contains(skillTypeKeyMapping[2])
                && skillTypeKeyMapping.Length > 2)
            {
                // deselect it
                selectedSkills.Remove(skillTypeKeyMapping[2]);
                Color prevColor = armourySlots[2].color;
                prevColor.a = 1f;
                armourySlots[2].color = prevColor;
            }
            else if (skillTypeKeyMapping.Length > 2)
            {
                selectedSkills.Add(skillTypeKeyMapping[2]);
                Color prevColor = armourySlots[2].color;
                prevColor.a = selectedAlpha;
                armourySlots[2].color = prevColor;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (selectedSkills.Contains(skillTypeKeyMapping[3])
                && skillTypeKeyMapping.Length > 3)
            {
                // deselect it
                selectedSkills.Remove(skillTypeKeyMapping[3]);
                Color prevColor = armourySlots[3].color;
                prevColor.a = 1f;
                armourySlots[3].color = prevColor;
            }
            else if (skillTypeKeyMapping.Length > 3)
            {
                selectedSkills.Add(skillTypeKeyMapping[3]);
                Color prevColor = armourySlots[3].color;
                prevColor.a = selectedAlpha;
                armourySlots[3].color = prevColor;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (selectedSkills.Contains(skillTypeKeyMapping[4])
                && skillTypeKeyMapping.Length > 4)
            {
                // deselect it
                selectedSkills.Remove(skillTypeKeyMapping[4]);
                Color prevColor = armourySlots[4].color;
                prevColor.a = 1f;
                armourySlots[4].color = prevColor;
            }
            else if (skillTypeKeyMapping.Length > 4)
            {
                selectedSkills.Add(skillTypeKeyMapping[4]);
                Color prevColor = armourySlots[4].color;
                prevColor.a = selectedAlpha;
                armourySlots[4].color = prevColor;
            }
        }
    }

    private void ApplySelectedSkills()
    {
        Time.timeScale = 1;
        elapsePanel.SetActive(false);
        armouryUI.SetActive(false);
        turnInputManager.SetIsSlowed(false);

        SkillType toApply = TranslateSkillCombination();
        if (toApply == SkillType.None)
        {
            return;
        }

        foreach (Skill projectile in projectiles)
        {
            if (projectile.GetSkillType() == toApply)
            {
                projectile.Apply(firingOrigin);
                break;
            }
        }
    }

    private SkillType TranslateSkillCombination()
    {
        for (int i = 0; i < armourySlots.Length; ++i) 
        {
            Color prevColor = armourySlots[i].color;
            prevColor.a = 1f;
            armourySlots[i].color = prevColor;
        }

        SkillType resultingSkill = SkillType.None;
        for (int i = 0; i < skillCombinationTable.Length; ++i)
        {
            if (skillCombinationTable[i].operands.Length != selectedSkills.Count)
            {
                continue;
            }

            bool invalidCombination = false;
            foreach (SkillType skill in skillCombinationTable[i].operands)
            {
                if (!selectedSkills.Contains(skill))
                {
                    invalidCombination = true;
                    break;
                }
            }

            if (invalidCombination)
            {
                continue;
            }
            else
            {
                resultingSkill = skillCombinationTable[i].result;
                break;
            }
        }
        return resultingSkill;
    }
}
