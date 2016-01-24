// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.ICanvasElement
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine;

namespace UnityEngine.UI
{
  public interface ICanvasElement
  {
    /// <summary>
    /// 
    /// <para>
    /// Get the transform associated with the ICanvasElement.
    /// </para>
    /// 
    /// </summary>
    Transform transform { get; }

    /// <summary>
    /// 
    /// <para>
    /// Rebuild the element for the given stage.
    /// </para>
    /// 
    /// </summary>
    /// <param name="executing">Stage being rebuild.</param>
    void Rebuild(CanvasUpdate executing);

    /// <summary>
    /// 
    /// <para>
    /// Callback sent when this ICanvasElement has completed layout.
    /// </para>
    /// 
    /// </summary>
    void LayoutComplete();

    /// <summary>
    /// 
    /// <para>
    /// Callback sent when this ICanvasElement has completed Graphic rebuild.
    /// </para>
    /// 
    /// </summary>
    void GraphicUpdateComplete();

    /// <summary>
    /// 
    /// <para>
    /// Return true if the element is considered destroyed.
    /// Used if the native representation has been destroyed.
    /// </para>
    /// 
    /// </summary>
    bool IsDestroyed();
  }
}
