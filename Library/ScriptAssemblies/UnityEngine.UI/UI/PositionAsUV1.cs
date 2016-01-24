// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.PositionAsUV1
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine;

namespace UnityEngine.UI
{
  /// <summary>
  /// 
  /// <para>
  /// An IVertexModifier which sets the raw vertex position into UV1 of the generated verts.
  /// </para>
  /// 
  /// </summary>
  [AddComponentMenu("UI/Effects/Position As UV1", 16)]
  public class PositionAsUV1 : BaseMeshEffect
  {
    protected PositionAsUV1()
    {
    }

    public override void ModifyMesh(VertexHelper vh)
    {
      UIVertex vertex = new UIVertex();
      for (int i = 0; i < vh.currentVertCount; ++i)
      {
        vh.PopulateUIVertex(ref vertex, i);
        vertex.uv1 = new Vector2(vertex.position.x, vertex.position.y);
        vh.SetUIVertex(vertex, i);
      }
    }
  }
}
