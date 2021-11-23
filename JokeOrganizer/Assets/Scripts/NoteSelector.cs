using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class NoteSelectedEvent : UnityEvent<Note> { }
public class NoteSelector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _linkedText;

    public NoteSelectedEvent OnNoteSelected = new NoteSelectedEvent();

    Note _linkedNote;

    public void Bind(Note note)
    {
        _linkedText.text = note.title;
        _linkedNote = note;
    }

    public void OnSelected()
    {
        OnNoteSelected.Invoke(_linkedNote);
    }
}
