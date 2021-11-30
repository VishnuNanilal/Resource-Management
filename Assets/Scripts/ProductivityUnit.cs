using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    [SerializeField] float productivityMultiplier = 1f;

    ResourcePile m_currentPile = null;

    protected override void BuildingInRange()
    {
        if(m_currentPile != null) return;
        
        ResourcePile resourcePile = m_Target as ResourcePile;
        if(resourcePile != null)
        {
            resourcePile.ChangeProductionSpeed(productivityMultiplier);
            m_currentPile = resourcePile;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }

    void ResetProductivity()
    {
        if(m_currentPile != null)
        {
            m_currentPile.ChangeProductionSpeed(1/productivityMultiplier);
            m_currentPile = null;
        }
    }
}
