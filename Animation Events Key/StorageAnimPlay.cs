using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageAnimPlay : MonoBehaviour
{
    public event Action OnInit;
    public bool IsInit => _isInit;
    private bool _isInit = false;
    
    [SerializeField]
    private List<AbsKeyData<GetDataSO_KeyAnimPlay, AbsStorageAnimPlay>> _inspectorData;
    private Dictionary<string, AbsStorageAnimPlay> _data = new Dictionary<string, AbsStorageAnimPlay>();

    [SerializeField] 
    private AnimClipEvents _animClipEvents;

    private void Awake()
    {
        foreach (var VARIABLE in _inspectorData)
        {
            _data.Add(VARIABLE.Key.GetData().GetKey(), VARIABLE.Data);
        }

        _animClipEvents.OnEventAnim += OnEventAnim;

        _isInit = true;
        OnInit?.Invoke();
    }

    private void OnEventAnim(DataEventClip dataKey)
    {
        string key = dataKey.KeyAnimPlay.GetKey();
        if (_data.ContainsKey(key))
        {
            _data[key].InvokeOnEventAnim(dataKey.KeyAnimEvent);
        } 
    }

    public AbsAnimPlay GetAnim(KeyAnimPlay key)
    {
        return _data[key.GetKey()];
    }

    private void OnDestroy()
    {
        _animClipEvents.OnEventAnim -= OnEventAnim;
    }
}
