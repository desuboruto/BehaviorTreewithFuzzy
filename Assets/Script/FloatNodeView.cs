using GraphProcessor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[NodeCustomEditor(typeof(FloatNode))]
public class FloatNodeView : BaseNodeView
{
    public override void Enable()
    {
        var floatNode = nodeTarget as FloatNode;

        DoubleField floatField = new DoubleField
        {
            value = floatNode.input
        };

        floatNode.onProcessed += () => floatField.value = floatNode.input;

        floatField.RegisterValueChangedCallback((v) =>
        {
            owner.RegisterCompleteObjectUndo("Updated floatNode");
            floatNode.input = (float)v.newValue;
        });

        controlsContainer.Add(floatField);
    }
}
