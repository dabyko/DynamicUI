using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Note", menuName = "Note item")]
public class Note : ScriptableObject
{
    public string title;
    
    public string category;

    [TextArea]
    public string description;

    public List<Note> analogs;
}
