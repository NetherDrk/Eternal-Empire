// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.RectangularVertexClipper
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine;

namespace UnityEngine.UI
{
  internal class RectangularVertexClipper
  {
    private readonly Vector3[] m_WorldCorners = new Vector3[4];
    private readonly Vector3[] m_CanvasCorners = new Vector3[4];

    public Rect GetCanvasRect(RectTransform t, Canvas c)
    {
      t.GetWorldCorners(this.m_WorldCorners);
      Transform component = c.GetComponent<Transform>();
      for (int index = 0; index < 4; ++index)
        this.m_CanvasCorners[index] = component.InverseTransformPoint(this.m_WorldCorners[index]);
      return new Rect(this.m_CanvasCorners[0].x, this.m_CanvasCorners[0].y, this.m_CanvasCorners[2].x - this.m_CanvasCorners[0].x, this.m_CanvasCorners[2].y - this.m_CanvasCorners[0].y);
    }
  }
}
