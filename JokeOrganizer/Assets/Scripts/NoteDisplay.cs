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
        Debug.Log("Note to show: " + note.name);

        var dimensions = noteContent.GetPreferredValues(note.description, noteContentRoot.rect.width, noteContentRoot.rect.height);

        noteContentRoot.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, dimensions.y);
        noteContent.text = note.description;
    }
}
