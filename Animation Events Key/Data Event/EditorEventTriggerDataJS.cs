using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Нужен для простого способа получить js данные, которые нужно указать в Event Triggers у Animation Clip
/// ! не помещать в папку Editor т.к иначе не получиться на GameObject накинуть этот класс
/// </summary>
#if UNITY_EDITOR
public class EditorEventTriggerDataJS : MonoBehaviour
{
    [SerializeField] 
    private GetDataSO_KeyAnimPlay _keyAnimPlay;

    [SerializeField] 
    private GetDataSO_KeyAnimEvent _keyAnimEvent;

    [SerializeField] 
    private bool _click;

    [SerializeField]
    [TextArea]
    private string _jsData;

    private void OnValidate()
    {
        if (_click == false) 
        {
            _jsData = "";
            return;
        }

        if (_keyAnimPlay != null && _keyAnimEvent != null) 
        {
            DataEventClip data = new DataEventClip(_keyAnimPlay.GetData(), _keyAnimEvent.GetData());
            _jsData = JsonUtility.ToJson(data);    
        }
        
    }
}
#endif
