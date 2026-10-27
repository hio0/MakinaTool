using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeriveValue
{
    public float baseValue { get; private set; }
    public List<ValueModifier> modifierList { get; private set; } = new();

    public DeriveValue(float value)
    {
        baseValue = value;
    }

    public void AddModifier(ValueModifierType type, float value)
    {
        ValueModifier modifier = new ValueModifier
        {
            value = value,
            valueType = type
        };

        modifierList.Add(modifier);
    }

    public float GetValue()
    {
        float finalFlat = 0;
        float finalPercentAdd = 0;
        float finalPercentMult = 1;

        foreach (ValueModifier modifier in modifierList)
        {
            switch(modifier.valueType)
            {
                case ValueModifierType.Flat:
                    finalFlat += modifier.value;
                    break;
                case ValueModifierType.PercentAdd:
                    finalPercentAdd += modifier.value;
                    break;
                case ValueModifierType.PercentMult:
                    finalPercentMult += modifier.value;
                    break;
            }
        }

        return (baseValue * (1 + finalPercentAdd)) + (baseValue * finalPercentMult) + finalFlat;
    }
}
