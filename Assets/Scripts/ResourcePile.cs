using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A subclass of Building that produce resource at a constant rate.
/// </summary>
public class ResourcePile : Building
{
    public ResourceItem Item;

    
    private float m_CurrentProduction = 0.0f;
    private float m_productionSpeed = 0.5f;

    private void Update()
    {
        if (m_CurrentProduction > 1.0f)
        {
            int amountToAdd = Mathf.FloorToInt(m_CurrentProduction);
            int leftOver = AddItem(Item.Id, amountToAdd);

            m_CurrentProduction = m_CurrentProduction - amountToAdd + leftOver;
        }
        
        if (m_CurrentProduction < 1.0f)
        {
            m_CurrentProduction += m_productionSpeed * Time.deltaTime;
        }
    }

    public override string GetData()
    {
        return $"Producing at the speed of {m_productionSpeed}/s";
    }

    public void ChangeProductionSpeed(float multiplier)
    {
        if(multiplier < 0f)
            Debug.Log ("Production multiplier cannot be negative");

        m_productionSpeed *= multiplier;
    }
}
