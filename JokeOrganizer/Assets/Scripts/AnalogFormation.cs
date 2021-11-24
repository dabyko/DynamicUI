using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnalogFormation : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI analogContent;

    public void Bind(string analog)
    {
        analogContent.text = analog;

        var dimensions = analogContent.GetPreferredValues();

       ((RectTransform)analogContent.transform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, dimensions.y);
    }
}
