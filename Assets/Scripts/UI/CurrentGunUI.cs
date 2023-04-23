using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentGunUI : MonoBehaviour
{
    [SerializeField] public Sprite[] guns;
    [SerializeField] private Image display;
    private Sprite activeGun;

    private void Update() {
        display.sprite = activeGun;
    }

    public void SwitchGun(SkillType skill)
    {
        switch (skill)
        {
            case SkillType.Pistol:
                activeGun = guns[0];
                break;
            case SkillType.Minigun:
                activeGun = guns[1];
                break;
            case SkillType.Shotgun:
                activeGun = guns[2];
                break;
            case SkillType.Rocket:
                activeGun = guns[3];
                break;
            default:
                break;
        }
    }
}
