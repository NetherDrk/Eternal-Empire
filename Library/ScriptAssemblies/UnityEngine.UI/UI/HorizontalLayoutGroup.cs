// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.HorizontalLayoutGroup
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine;

namespace UnityEngine.UI
{
  /// <summary>
  /// 
  /// <para>
  /// Layout child layout elements side by side.
  /// </para>
  /// 
  /// </summary>
  [AddComponentMenu("Layout/Horizontal Layout Group", 150)]
  public class HorizontalLayoutGroup : HorizontalOrVerticalLayoutGroup
  {
    protected HorizontalLayoutGroup()
    {
    }

    /// <summary>
    /// 
    /// <para>
    /// Called by the layout system.
    /// </para>
    /// 
    /// </summary>
    public override void CalculateLayoutInputHorizontal()
    {
      base.CalculateLayoutInputHorizontal();
      this.CalcAlongAxis(0, false);
    }

    /// <summary>
    /// 
    /// <para>
    /// Called by the layout system.
    /// </para>
    /// 
    /// </summary>
    public override void CalculateLayoutInputVertical()
    {
      this.CalcAlongAxis(1, false);
    }

    /// <summary>
    /// 
    /// <para>
    /// Called by the layout system.
    /// </para>
    /// 
    /// </summary>
    public override void SetLayoutHorizontal()
    {
      this.SetChildrenAlongAxis(0, false);
    }

    /// <summary>
    /// 
    /// <para>
    /// Called by the layout system.
    /// </para>
    /// 
    /// </summary>
    public override void SetLayoutVertical()
    {
      this.SetChildrenAlongAxis(1, false);
    }
  }
}
