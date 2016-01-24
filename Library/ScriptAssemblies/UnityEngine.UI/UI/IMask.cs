// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.IMask
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System;
using UnityEngine;

namespace UnityEngine.UI
{
  [Obsolete("Not supported anymore.", true)]
  public interface IMask
  {
    /// <summary>
    /// 
    /// <para>
    /// Return the RectTransform associated with this mask.
    /// </para>
    /// 
    /// </summary>
    RectTransform rectTransform { get; }

    /// <summary>
    /// 
    /// <para>
    /// Is the mask enabled.
    /// </para>
    /// 
    /// </summary>
    bool Enabled();
  }
}
