using UnityEngine;
using UnityEngine.UI;


public class CoinManagerPlayerTwo : MonoBehaviour
{
    public int currentCoin;
    public int currentHealthPoint;
    public PlayerHealth playerHealthTwo;

    [Space()]
    public Text healthPointText;
    public Text coinText;


    public static CoinManagerPlayerTwo instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        healthPointText.text = currentHealthPoint.ToString();
        coinText.text = currentCoin.ToString();
        if (Input.GetButtonDown("Heal") && CanHeal())
        {
            RemoveHealthPoint(1);
            playerHealthTwo.Heal(1);

        }

        if(currentHealthPoint == -1) 
        {
            currentHealthPoint = 0;
        }
    }

    public bool CanHeal()
    {
        if (currentHealthPoint >= 1)
        {
            return true;
        }

        else
        {
            return false;
        }

    }
    public void AddCoin(int coinToAdd)
    {
        currentCoin += coinToAdd;
    }

    public void RemoveCoin(int coinToRemove)
    {
        currentCoin -= coinToRemove;
    }


    public void AddHealthPoint(int healthToAdd)
    {
        currentHealthPoint += healthToAdd;
    }

    public void RemoveHealthPoint(int healthToAdd)
    {
        currentHealthPoint -= healthToAdd;
    }


}
