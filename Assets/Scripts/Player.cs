using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text coinsTxt;
    [SerializeField] public int coins;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Text healthTxt;
    [SerializeField] public int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private Slider manaSlider;
    [SerializeField] private Text manaTxt;
    [SerializeField] public int mana;
    [SerializeField] private int maxMana;
    [SerializeField] public float speed;
    [SerializeField] private Transform sprite;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = healthSlider.maxValue;

        mana = maxMana;
        manaSlider.maxValue = maxMana;
        manaSlider.value = manaSlider.maxValue;

        UpdateStatisticks();
    }
    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb.velocity = movement * speed;

        if (transform.localScale.x > 0 && movement.x < 0 || transform.localScale.x < 0 && movement.x > 0)
        {
            Flip();
        }
    }
    private void Flip()
    {
        Vector2 ls = transform.localScale;
        ls.x *= -1;
        transform.localScale = ls;
    }

//    считаем циферки статистики
    public void GetHealthAndMana(int health, int mana)
    {
        this.health += health;
        this.mana += mana;

        this.health = Mathf.Clamp(this.health, 0, maxHealth);
        this.mana = Mathf.Clamp(this.mana, 0, maxMana);

        UpdateStatisticks();
    }
    
    private void UpdateStatisticks()
    {
        //coinsTxt.text = coins.ToString();             //тут добавление монеток
//        отображаем статистику
        //healthTxt.text = $"{health}/{maxHealth}";
        //manaTxt.text = $"{mana}/{maxMana}";
    }
}
