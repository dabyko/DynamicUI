using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteDisplay : MonoBehaviour
{
    [SerializeField] List<Note> notes;

    [SerializeField] GameObject noteSelectorPrefab;
    [SerializeField] Transform noteSelectorRoot;

    [SerializeField] TextMeshProUGUI noteContent;
    [SerializeField] RectTransform noteContentRoot;

    [SerializeField] GameObject analogPrefab;
    [SerializeField] Transform analogRoot;


    private void Start()
    {
        foreach (var note in notes)
        {
            var selector = Instantiate(noteSelectorPrefab, Vector3.zero, Quaternion.identity, noteSelectorRoot);
            selector.name = "Note_" + note.name;

            var selectorScript = selector.GetComponent<NoteSelector>();
            selectorScript.Bind(note);

            selectorScript.OnNoteSelected.AddListener(OnNoteSelected);
        }
    }

 
    public void OnNoteSelected(Note note)
    {
        SetNoteDescription(note);
        SetAnalogsData(note);
    } 

    private void SetNoteDescription(Note note)
    {
        var dimensions = noteContent.GetPreferredValues(note.description, noteContentRoot.rect.width, noteContentRoot.rect.height);

        noteContentRoot.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, dimensions.y);
        noteContent.text = note.description;
    }

    private void SetAnalogsData(Note note)
    {
        ClearAnalogsData();

        foreach (var analog in note.analogs)
        {
            var analogView = Instantiate(analogPrefab, Vector3.zero, Quaternion.identity, analogRoot);
            analogView.GetComponent<AnalogFormation>().Bind(analog.description);
        }
    }

    private void ClearAnalogsData()
    {
        if(analogRoot.childCount > 0)

        foreach (Transform analog in analogRoot)
        {
            GameObject.Destroy(analog.gameObject);
        }
    }
}
