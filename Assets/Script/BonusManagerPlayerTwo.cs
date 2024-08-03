using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BonusManagerPlayerTwo : MonoBehaviour
{
    public bool isInRange;
    public BonusType bonusType;

    private int priceSword;
    private int priceBow;
    private int pricePlateform;

    public int basePriceSword;
    public int basePriceBow;
    public int basePricePlateform;

    public TextMeshProUGUI textPrice;
    public Text lvlText;

    public BowController bow;
    public AttackController attack;
    public PlateformHealthTwo plateformHealth;

    public enum BonusType { Sword, Bow, Plateform }

    void Start()
    {
        // Initialize base prices
        priceSword = basePriceSword;
        priceBow = basePriceBow;
        pricePlateform = basePricePlateform;
    }

    public bool canBuy()
    {
        int price = GetCurrentPrice();
        return price <= CoinManagerPlayerTwo.instance.currentCoin && CanIncreaseLevel();
    }

    void Update()
    {
        lvlText.text = "LV :" + attack.currentLevel.ToString();

        if (Input.GetButtonDown("Interact") && isInRange && canBuy())
        {
            InitializeBonus();
        }

        textPrice.text = GetCurrentPrice().ToString();
    }

    void InitializeBonus()
    {
        if (!CanIncreaseLevel())
            return;

        switch (bonusType)
        {
            case BonusType.Sword:
                attack.AddBonus(attack.currentLevel + 1);
                CoinManagerPlayerTwo.instance.RemoveCoin(priceSword);
                priceSword = CalculateNewPrice(basePriceSword, attack.currentLevel + 1);
                break;
            case BonusType.Bow:
                bow.AddBonus(bow.currentLevel + 1);
                CoinManagerPlayerTwo.instance.RemoveCoin(priceBow);
                priceBow = CalculateNewPrice(basePriceBow, bow.currentLevel + 1);
                break;
            case BonusType.Plateform:
                plateformHealth.AddBonus(plateformHealth.currentLevel + 1);
                CoinManagerPlayerTwo.instance.RemoveCoin(pricePlateform);
                pricePlateform = CalculateNewPrice(basePricePlateform, plateformHealth.currentLevel + 1);
                break;
        }
    }

    int GetCurrentPrice()
    {
        switch (bonusType)
        {
            case BonusType.Sword:
                return priceSword;
            case BonusType.Bow:
                return priceBow;
            case BonusType.Plateform:
                return pricePlateform;
            default:
                return 0;
        }
    }

    int CalculateNewPrice(int basePrice, int level)
    {
        return Mathf.RoundToInt(basePrice * level * 0.5f);
    }

    bool CanIncreaseLevel()
    {
        switch (bonusType)
        {
            case BonusType.Sword:
                return attack.currentLevel < 3;
            case BonusType.Bow:
                return bow.currentLevel < 3;
            case BonusType.Plateform:
                return plateformHealth.currentLevel < 3;
            default:
                return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            isInRange = false;

        }
    }
}
