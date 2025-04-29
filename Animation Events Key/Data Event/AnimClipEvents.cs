using System;
using UnityEngine;

/// <summary>
/// Скрипт должен находиться на том же gameObject,что и аниматор
/// Метод у этого скрипта вызываеться из Event Triggers у Animation Clip и передаються в виде js данные об
/// - ключе клипа
/// - ключе event
/// (данные в виде js у каждого Event Triggers нужно задовать в ручную)
/// </summary>
public class AnimClipEvents : MonoBehaviour
{
    public event Action<DataEventClip> OnEventAnim;

    public void InvokeAnimClipEvent(string jsData)
    {
        DataEventClip data = JsonUtility.FromJson<DataEventClip>(jsData);

        if (data != null)
        {
            OnEventAnim?.Invoke(data);
        }
    }

}


