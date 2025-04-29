using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Будет вызывать проигрывание анимации по её имени у указанного аниматора
/// </summary>
public class AnimPlayStateName : AbsStorageAnimPlay
{
    [SerializeField] 
    private Animator _animator;

    [SerializeField]
    private string _stateName;
    
    public override void PlayAnim(bool isReset = true)
    {
        if (isReset == true)
        {
            _animator.Play(_stateName, -1, 0);
            return;
        }
        
        _animator.Play(_stateName);
    }

    public override void StopAnim()
    {
        _animator.StopPlayback();
    }

    public override void BreakAnim()
    {
        //тут какая то логика, на случай если нужно именно прервать воспроизведение анимации
        StopAnim();
    }
}
