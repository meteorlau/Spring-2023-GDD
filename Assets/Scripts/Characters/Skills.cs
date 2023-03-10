using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    protected int currentHealth;
    protected static List<Gun> skillsList;
    // index starts at 1
    private int currentGunIndex;

    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        currentGunIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Aquire(Gun obj)
    {
        skillsList.Add(obj);
    }

    public void SwitchGun(int key)
    {
        currentGunIndex = key;
    }

    public void Drop(int key)
    {
        skillsList.RemoveAt(key);
    }

    public Gun RetrieveBinding(int key)
    {
        return skillsList[key];
    }

    public Gun GetCurrentSkill()
    {
        if (currentGunIndex - 1 < skillsList.Count)
            return skillsList[currentGunIndex - 1];
        return null;
    }

    public void Shoot(int key)
    {
        Gun currentGun = GetCurrentSkill();
        currentGun.DecreaseAmo();

        // Not sure how to determine if shot hits enemy and which enemy it hits yet

        if (currentGun.ammoCount() == 0) {
            Drop(currentGunIndex);
            currentGunIndex = 1;
        }
    }
}
