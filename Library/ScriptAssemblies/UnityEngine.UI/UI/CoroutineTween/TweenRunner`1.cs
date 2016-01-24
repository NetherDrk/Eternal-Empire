﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.CoroutineTween.TweenRunner`1
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace UnityEngine.UI.CoroutineTween
{
  internal class TweenRunner<T> where T : struct, ITweenValue
  {
    protected MonoBehaviour m_CoroutineContainer;
    protected IEnumerator m_Tween;

    [DebuggerHidden]
    private static IEnumerator Start(T tweenInfo)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new TweenRunner<T>.\u003CStart\u003Ec__Iterator0()
      {
        tweenInfo = tweenInfo,
        \u003C\u0024\u003EtweenInfo = tweenInfo
      };
    }

    public void Init(MonoBehaviour coroutineContainer)
    {
      this.m_CoroutineContainer = coroutineContainer;
    }

    public void StartTween(T info)
    {
      if ((Object) this.m_CoroutineContainer == (Object) null)
      {
        UnityEngine.Debug.LogWarning((object) "Coroutine container not configured... did you forget to call Init?");
      }
      else
      {
        if (this.m_Tween != null)
        {
          this.m_CoroutineContainer.StopCoroutine(this.m_Tween);
          this.m_Tween = (IEnumerator) null;
        }
        if (!this.m_CoroutineContainer.gameObject.activeInHierarchy)
        {
          info.TweenValue(1f);
        }
        else
        {
          this.m_Tween = TweenRunner<T>.Start(info);
          this.m_CoroutineContainer.StartCoroutine(this.m_Tween);
        }
      }
    }
  }
}
