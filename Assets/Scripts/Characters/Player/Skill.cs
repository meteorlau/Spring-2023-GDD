using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Skill")]
public class Skill : ScriptableObject
{
    [SerializeField] private SkillType type;
    [SerializeField] private GameObject skillPrefab = null;
    [SerializeField] private float skillSpeed = 15f;

    public void Apply(Transform spawnPosition)
    {
        switch (type)
        {
            case SkillType.Pistol:
                ApplyPistol(spawnPosition);
                break;
            case SkillType.Minigun:
                ApplyMinigun(spawnPosition);
                break;
            case SkillType.Shotgun:
                ApplyShotgun(spawnPosition);
                break;
            case SkillType.Rocket:
                ApplyRocket(spawnPosition);
                break;
            case SkillType.BulletMeteor:
                ApplyBulletMeteor(spawnPosition);
                break;
            case SkillType.BulletStream:
                ApplyBulletStream(spawnPosition);
                break;
            case SkillType.Pulse:
                ApplyPulse(spawnPosition);
                break;
            case SkillType.PulseSpread:
                ApplyPulseSpread(spawnPosition);
                break;
            default:
                break;
        }
    }

    #region SKILL SPECIFIC
    private void ApplyPistol(Transform firingOrigin)
    {
        GameObject bulletInstance = Instantiate(skillPrefab,
                    firingOrigin.position, firingOrigin.rotation);
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.AddForce(-1 * firingOrigin.up * skillSpeed, ForceMode2D.Impulse);
    }

    private void ApplyMinigun(Transform firingOrigin)
    {
        Instantiate(skillPrefab, firingOrigin.position, firingOrigin.rotation);
    }

    private void ApplyShotgun(Transform firingOrigin)
    {
        Instantiate(skillPrefab, firingOrigin.position, firingOrigin.rotation);
    }

    private void ApplyRocket(Transform firingOrigin)
    {
        GameObject bulletInstance = Instantiate(skillPrefab,
                    firingOrigin.position, firingOrigin.rotation);
        var currentRotation = bulletInstance.transform.rotation;
        bulletInstance.transform.rotation = currentRotation * Quaternion.AngleAxis(90, Vector3.forward);
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.AddForce(-1 * firingOrigin.up * skillSpeed, ForceMode2D.Impulse);
    }

    private void ApplyBulletMeteor(Transform firingOrigin)
    {
        GameObject bulletInstance = Instantiate(skillPrefab,
                    firingOrigin.position, firingOrigin.rotation);
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.AddForce(-1 * firingOrigin.up * skillSpeed, ForceMode2D.Impulse);
    }

    private void ApplyBulletStream(Transform firingOrigin)
    {
        Instantiate(skillPrefab, firingOrigin.position, firingOrigin.rotation);
    }

    private void ApplyPulse(Transform firingOrigin)
    {
        GameObject bulletInstance = Instantiate(skillPrefab,
                    firingOrigin.position, firingOrigin.rotation);
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.AddForce(-1 * firingOrigin.up * skillSpeed, ForceMode2D.Impulse);
    }

    private void ApplyPulseSpread(Transform firingOrigin)
    {
        Instantiate(skillPrefab, firingOrigin.position, firingOrigin.rotation);
    }
    #endregion

    public SkillType GetSkillType()
    {
        return type;
    }
}
