using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Публичный метод нужен что бы Storage мог его вызвать
/// (и нет, тут нельзя делать так что бы Storage создавал класс и только он знал об нем, т.к нужен именно monobeh, т.к у каждого наследника будет своя уникальная логика, со своими ссылками
/// </summary>
public abstract class AbsStorageAnimPlay : AbsAnimPlay
{
    public override event Action<KeyAnimEvent> OnEventAnim;

    public void InvokeOnEventAnim(KeyAnimEvent keyAnimEvent)
    {
        OnEventAnim?.Invoke(keyAnimEvent);
    }
}
