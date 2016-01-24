// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.IMeshModifier
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System;
using UnityEngine;

namespace UnityEngine.UI
{
  public interface IMeshModifier
  {
    /// <summary>
    /// 
    /// <para>
    /// Call used to modify mesh.
    /// </para>
    /// 
    /// </summary>
    /// <param name="mesh"/>
    [Obsolete("use IMeshModifier.ModifyMesh (VertexHelper verts) instead", false)]
    void ModifyMesh(Mesh mesh);

    void ModifyMesh(VertexHelper verts);
  }
}
