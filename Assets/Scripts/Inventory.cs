using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> weapons;
    [SerializeField] private Transform hand;
    [SerializeField] private int hotWeapon;
    [SerializeField] private int maxWeapons = 2;
    private void Update()
    {
        int scroll = Convert.ToInt32(Input.GetAxisRaw("Mouse ScrollWheel") * 10);

        if (weapons.Count > 0 && scroll != 0)
        {
            hotWeapon += scroll;

            if (hotWeapon > weapons.Count - 1)
                hotWeapon = 0;
            if (hotWeapon < 0)
                hotWeapon = weapons.Count - 1;

            SetHotWeapon(hotWeapon);
        }
    }
    private void SetHotWeapon(int hot)
    {
        hotWeapon = hot;
        foreach (GameObject g in weapons)
            g.SetActive(false);

        weapons[hotWeapon].SetActive(true);
    }
    public void AddWeapon(GameObject weapon)
    {
        if (weapons.Count < maxWeapons)
        {
            GameObject w = Instantiate(weapon, hand);
            w.GetComponent<Weapon>().isPlayer = true;
            weapons.Add(w);
            SetHotWeapon(weapons.IndexOf(w));
        }
        else
        {
            RemoveWeapon(weapons[hotWeapon]);
            AddWeapon(weapon);
        }
    }
    public void RemoveWeapon(GameObject weapon)
    {
        Instantiate(weapon.GetComponent<Weapon>().item, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        weapons.Remove(weapon);
        Destroy(weapon);
    }
}