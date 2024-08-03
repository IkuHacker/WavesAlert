using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBow : MonoBehaviour
{
    public Bow currentBow;
    public BowController currentBowController;

    public static GetBow instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GetBow dans la scene");
            return;
        }

        instance = this;
    }
    
}
