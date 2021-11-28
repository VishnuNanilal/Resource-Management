using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    [SerializeField] float productivityMultiplier = 1f;

    ResourcePile resourcePile = null;

    protected override void BuildingInRange()
    {
        if(isAssigned) return;
        isAssigned = true;
        
        resourcePile = m_Target as ResourcePile;
        if(resourcePile != null)
        {
            resourcePile.ChangeProductionSpeed(productivityMultiplier);
            isAssigned = true;
        }
    }

    protected override void Update() 
    {
        base.Update();
        if(m_Target == null && isAssigned)
        {
            isAssigned = false;
            resourcePile.ChangeProductionSpeed(1/productivityMultiplier);
        }
    
    }
}
