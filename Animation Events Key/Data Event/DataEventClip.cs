using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataEventClip
{
    public DataEventClip(KeyAnimPlay keyAnimPlay, KeyAnimEvent keyAnimEvent)
    {
        _keyAnimPlay = keyAnimPlay;
        _keyAnimEvent = keyAnimEvent;
    }
    
    [SerializeField]
    private KeyAnimPlay _keyAnimPlay;
    [SerializeField]
    private KeyAnimEvent _keyAnimEvent;


    public KeyAnimPlay KeyAnimPlay => _keyAnimPlay;
    public KeyAnimEvent KeyAnimEvent => _keyAnimEvent;
}