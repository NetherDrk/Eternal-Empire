// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.IVertexModifier
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI
{
  [Obsolete("Use IMeshModifier instead", true)]
  public interface IVertexModifier
  {
    [Obsolete("use IMeshModifier.ModifyMesh (VertexHelper verts)  instead", true)]
    void ModifyVertices(List<UIVertex> verts);
  }
}
