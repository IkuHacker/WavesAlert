using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InventoryOne : MonoBehaviour
{
    public GameObject bow;
    public GameObject sword;
    public WeaponType currentWeapon;
    public bool isOnGamePad;
    public enum WeaponType { Bow, Sword }

    private void Start()
    {
        UpdateCurrentWeapon();
    }

    public void SelectBow()
    {
 
        currentWeapon = WeaponType.Bow;
        UpdateCurrentWeapon();
    }

    public void SelectSword()
    {
   
        currentWeapon = WeaponType.Sword;
        UpdateCurrentWeapon();
    }

    private void UpdateCurrentWeapon()
    {
        switch (currentWeapon) 
        {
            case WeaponType.Bow:
                bow.SetActive(true);
                sword.SetActive(false);
                break;

            case WeaponType.Sword:
                sword.SetActive(true);
                bow.SetActive(false);
                break;

            default:
                bow.SetActive(true);
                sword.SetActive(false);
                break;
        }
    }
}
