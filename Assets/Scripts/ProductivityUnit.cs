using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;

    // protected values are like private values
    // but protected can be accessed by child classes
    protected override void BuildingInRange()
    {
        // it is possible for this code to rerun on consecutive frames
        // this condition checks to see if current pile is null
        // this is to prevent this code block from rerunning
        if (m_CurrentPile == null)
        {
            // the "as" notation will set pile to m_Target
            // but only if m_Target is a ResourcePile
            // if it's not, then it will be assigned null
            // hence the later check for null
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity(); // call your new method
        base.GoTo(target); // run the default GoTo method from the base class
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity(); // call your new method
        base.GoTo(position); // run the default GoTo method from the base class
    }
}
