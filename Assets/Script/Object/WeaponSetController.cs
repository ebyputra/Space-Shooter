using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetController : MonoBehaviour
{

    public GameObject[] WeaponSet;
    
    void Start()
    {
        deactivateAllWeapons();
        activateWeaponSet(0);

        weaponUpgradeCheck();
    }

    private void deactivateAllWeapons()
    {
        foreach(GameObject go in WeaponSet)
        {
            go.SetActive(false);
        }
    }

    public void activateWeaponSet(int upgradeLevel)
    {
        for(int i=0;i<WeaponSet.Length;i++)
        {
            if (i == upgradeLevel)
            {
                WeaponSet[i].SetActive(true);
            } else
            {
                WeaponSet[i].SetActive(false);
            }
        }
    }

    public void weaponUpgradeCheck()
    {
        int upgradeLevel = GetComponents<WeaponUpgrade>().Length;
        if (upgradeLevel >= WeaponSet.Length)
        {
            upgradeLevel = WeaponSet.Length - 1;
        }
        activateWeaponSet(upgradeLevel);
        fireRateUpdate();
    }

    private void fireRateUpdate()
    {
        foreach(Weapon w in GetComponentsInChildren<Weapon>())
        {
            w.clearModifier();
            foreach(FireRateModifier f in GetComponents<FireRateModifier>())
            {
                w.addFireRateModifier(f.modifier);
            }
            
        }
    }

    void Update()
    {
        
    }
}
