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

    public void SwitchGun(Skill skill)
    {
        switch (skill)
        {
            case Skill.Pistol:
                activeGun = guns[0];
                break;
            case Skill.Minigun:
                activeGun = guns[1];
                break;
            case Skill.Shotgun:
                activeGun = guns[2];
                break;
            case Skill.Rocket:
                activeGun = guns[3];
                break;
            default:
                break;
        }
    }
}
