// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.Outline
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI
{
  /// <summary>
  /// 
  /// <para>
  /// Adds an outline to a graphic using IVertexModifier.
  /// </para>
  /// 
  /// </summary>
  [AddComponentMenu("UI/Effects/Outline", 15)]
  public class Outline : Shadow
  {
    protected Outline()
    {
    }

    public override void ModifyMesh(VertexHelper vh)
    {
      if (!this.IsActive())
        return;
      List<UIVertex> list = ListPool<UIVertex>.Get();
      vh.GetUIVertexStream(list);
      int num = list.Count * 5;
      if (list.Capacity < num)
        list.Capacity = num;
      int start1 = 0;
      int count1 = list.Count;
      this.ApplyShadowZeroAlloc(list, (Color32) this.effectColor, start1, list.Count, this.effectDistance.x, this.effectDistance.y);
      int start2 = count1;
      int count2 = list.Count;
      this.ApplyShadowZeroAlloc(list, (Color32) this.effectColor, start2, list.Count, this.effectDistance.x, -this.effectDistance.y);
      int start3 = count2;
      int count3 = list.Count;
      this.ApplyShadowZeroAlloc(list, (Color32) this.effectColor, start3, list.Count, -this.effectDistance.x, this.effectDistance.y);
      int start4 = count3;
      int count4 = list.Count;
      this.ApplyShadowZeroAlloc(list, (Color32) this.effectColor, start4, list.Count, -this.effectDistance.x, -this.effectDistance.y);
      vh.Clear();
      vh.AddUIVertexTriangleStream(list);
      ListPool<UIVertex>.Release(list);
    }
  }
}
