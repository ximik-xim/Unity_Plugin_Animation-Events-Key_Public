using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Пример подписки на срабатывание event у конкретного обьекта с анимациями
/// Поочерёдно произведет анимации из списка.
/// Понимает когда анимация закончилась, по ключи который приходит от even по анимации
/// </summary>
public class ExampleStartAnimPlay : MonoBehaviour
{
    [SerializeField]
    private StorageAnimPlay _storageAnimPlay;

    /// <summary>
    /// Список анимаций которые будут воспроизводиться друг за другом
    /// По окнончанию списка воспроизведение начнеться с начало.
    /// </summary>
    [SerializeField]
    private List<GetDataSO_KeyAnimPlay> _keyAnimPlays;
    private List<KeyAnimPlay> _bufferKey = new List<KeyAnimPlay>();
    
    [SerializeField]
    private GetDataSO_KeyAnimEvent _keyAnimEventComlited;
    
    private AbsAnimPlay _absAnimCurrent;
    private KeyAnimPlay _keyAnimPlayCurrent;

    private void OnEnable()
    {
        CheckInitStorage();
    }

    private void CheckInitStorage()
    {
        if (_storageAnimPlay.IsInit == false)
        {
            _storageAnimPlay.OnInit -= OnInitStorage;
            _storageAnimPlay.OnInit += OnInitStorage;
            
            return;
        }

        InitStorage();
    }

    private void OnInitStorage()
    {
        _storageAnimPlay.OnInit -= OnInitStorage;
        InitStorage();
    }
    
    private void InitStorage()
    {
        ReloadAnim();
    }
    
    private void ReloadAnim()
    {
        foreach (var VARIABLE in _keyAnimPlays)
        {
            _bufferKey.Add(VARIABLE.GetData());
        }

        AnimNextPlay();
    }

    private void AnimNextPlay()
    {
        if (_bufferKey.Count == 0)
        {
            if (_keyAnimPlays.Count > 0)
            {
                ReloadAnim();
            }
            
            return;
        }

        _keyAnimPlayCurrent = _bufferKey[0];
        _bufferKey.RemoveAt(0);
        
        _absAnimCurrent = _storageAnimPlay.GetAnim(_keyAnimPlayCurrent);
        _absAnimCurrent.OnEventAnim += OnEventAnim;
        _absAnimCurrent.PlayAnim();
    }
    
    private void OnEventAnim(KeyAnimEvent key)
    {
        Debug.Log("У анимации " + _keyAnimPlayCurrent.GetKey() + " Стработал event " + key.GetKey());
        
        if (key.GetKey() == _keyAnimEventComlited.GetData().GetKey()) 
        {
            _absAnimCurrent.OnEventAnim -= OnEventAnim;
            AnimNextPlay();
        }
    }
    
    private void OnDestroy()
    {
        if (_absAnimCurrent != null)
        {
            _absAnimCurrent.OnEventAnim -= OnEventAnim;
        }
    }
}
