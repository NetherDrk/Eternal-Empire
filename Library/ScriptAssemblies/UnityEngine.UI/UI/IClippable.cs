// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.IClippable
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine;

namespace UnityEngine.UI
{
  public interface IClippable
  {
    /// <summary>
    /// 
    /// <para>
    /// RectTransform of the clippable.
    /// </para>
    /// 
    /// </summary>
    RectTransform rectTransform { get; }

    /// <summary>
    /// 
    /// <para>
    /// Called when the state of a parent IClippable changes.
    /// </para>
    /// 
    /// </summary>
    void RecalculateClipping();

    /// <summary>
    /// 
    /// <para>
    /// Clip and cull the IClippable given the clipRect.
    /// </para>
    /// 
    /// </summary>
    /// <param name="clipRect">Rectangle to clip against.</param><param name="validRect">Is the Rect valid. If not then the rect has 0 size.</param>
    void Cull(Rect clipRect, bool validRect);

    /// <summary>
    /// 
    /// <para>
    /// Set the clip rect for the IClippable.
    /// </para>
    /// 
    /// </summary>
    /// <param name="value"/><param name="validRect"/>
    void SetClipRect(Rect value, bool validRect);
  }
}
