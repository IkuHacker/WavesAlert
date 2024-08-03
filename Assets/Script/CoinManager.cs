using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CoinManager : MonoBehaviour
{
    public int currentCoin;
    public int currentHealthPoint;
    public PlayerHealth playerHealthOne;

    [Space()]
    public Text healthPointText;
    public Text coinText;


    public static CoinManager instance;

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
        if (Input.GetKeyDown(KeyCode.H) && CanHeal())
        {
            RemoveHealthPoint(1);
            playerHealthOne.Heal(1);

        }

        if (currentHealthPoint == -1)
        {
            currentHealthPoint = 0;
        }
    }

    public bool CanHeal() 
    {
        if(currentHealthPoint >= 1) 
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
