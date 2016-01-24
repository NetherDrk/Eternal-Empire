// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.BaseVertexEffect
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI
{
  /// <summary>
  /// 
  /// <para>
  /// Base class for effects that modify the the generated Vertex Buffers.
  /// </para>
  /// 
  /// </summary>
  [Obsolete("Use BaseMeshEffect instead", true)]
  public abstract class BaseVertexEffect
  {
    [Obsolete("Use BaseMeshEffect.ModifyMeshes instead", true)]
    public abstract void ModifyVertices(List<UIVertex> vertices);
  }
}
