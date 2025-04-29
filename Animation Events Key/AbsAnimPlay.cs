using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsAnimPlay : MonoBehaviour
{
  // будет на у отображаймой части оружи, отвечать за то что бы проигралась анимация.
  // И при этом через event буду получать инвормацию об event стработавших на клипе анимации(у каждого event на клипе будет закрепленный ключ, именно его и в event и буду передовать)

  public abstract event Action<KeyAnimEvent> OnEventAnim;

  public abstract void PlayAnim(bool isReset = true);
  public abstract void StopAnim();
  public abstract void BreakAnim();
}
