using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseResource : Building
{
    [SerializeField] int baseSpace;
    private void Update() 
    {
        print(m_CurrentAmount);
        if(m_CurrentAmount > baseSpace)
        {
            GetComponentInParent<TruckMovement>().StartMovement();
        }
    }
}
