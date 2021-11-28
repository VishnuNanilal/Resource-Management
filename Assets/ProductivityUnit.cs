using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    [SerializeField] float productivityMultiplier = 1f;
    
    protected override void BuildingInRange()
    {
        throw new System.NotImplementedException();
    }

}
