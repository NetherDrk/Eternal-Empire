// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.ListPool`1
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System.Collections.Generic;
using UnityEngine.Events;

namespace UnityEngine.UI
{
  internal static class ListPool<T>
  {
    private static readonly ObjectPool<List<T>> s_ListPool = new ObjectPool<List<T>>((UnityAction<List<T>>) null, (UnityAction<List<T>>) (l => l.Clear()));

    public static List<T> Get()
    {
      return ListPool<T>.s_ListPool.Get();
    }

    public static void Release(List<T> toRelease)
    {
      ListPool<T>.s_ListPool.Release(toRelease);
    }
  }
}
