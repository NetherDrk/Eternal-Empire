// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.VerticalLayoutGroup
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine;

namespace UnityEngine.UI
{
  /// <summary>
  /// 
  /// <para>
  /// Layout child layout elements below each other.
  /// </para>
  /// 
  /// </summary>
  [AddComponentMenu("Layout/Vertical Layout Group", 151)]
  public class VerticalLayoutGroup : HorizontalOrVerticalLayoutGroup
  {
    protected VerticalLayoutGroup()
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
      this.CalcAlongAxis(0, true);
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
      this.CalcAlongAxis(1, true);
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
      this.SetChildrenAlongAxis(0, true);
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
      this.SetChildrenAlongAxis(1, true);
    }
  }
}
