using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogDisplay : MonoBehaviour
{
    [SerializeField] GameObject messageEntryPrefab;
    [SerializeField] Transform messageEntryRoot;

    public void DisplayAnalogs(Note note)
    {
        foreach (var analog in note.analogs)
        {
            SetAnalogData(analog);
        }
    }
    private void SetAnalogData(Note analog)
    {
        var analogView = Instantiate(messageEntryPrefab, Vector3.zero, Quaternion.identity, messageEntryRoot);
        analogView.GetComponent<AnalogFormation>().Bind(analog.description);
    }
}
