// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.Misc
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine;

namespace UnityEngine.UI
{
  internal static class Misc
  {
    public static void Destroy(Object obj)
    {
      if (!(obj != (Object) null))
        return;
      if (Application.isPlaying)
      {
        if (obj is GameObject)
          (obj as GameObject).transform.parent = (Transform) null;
        Object.Destroy(obj);
      }
      else
        Object.DestroyImmediate(obj);
    }

    public static void DestroyImmediate(Object obj)
    {
      if (!(obj != (Object) null))
        return;
      if (Application.isEditor)
        Object.DestroyImmediate(obj);
      else
        Object.Destroy(obj);
    }
  }
}
