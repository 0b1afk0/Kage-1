using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum CollectableType
{
    Weapon,
    Potion
}

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableType type;
    [SerializeField] private Text priceTxt;
    [SerializeField] public int price;
    [Header("PotionSettings")]
    [SerializeField] public int health;
    [SerializeField] public int ammo;
    [Header("WeaponSettings")]
    [SerializeField] private GameObject weapon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            if (price > 0)
            {
                priceTxt.text = price.ToString();
            }

            if (Input.GetKeyDown(KeyCode.E) && other.GetComponent<Player>().coins >= price)
            {
                Player p = other.GetComponent<Player>();
                p.coins -= price;

                switch (type)
                {
                    case CollectableType.Potion:
                        //тут логика выпивания зелья
                        other.GetComponent<Player>().GetHealthAndMana(health, ammo);
                        break;

                    case CollectableType.Weapon:
                        //тут логика добавления оружия
                        weapon.GetComponent<Inventory>().AddWeapon(weapon);
                        break;
                }

                priceTxt.text = string.Empty;
            }
        }
    }
}
