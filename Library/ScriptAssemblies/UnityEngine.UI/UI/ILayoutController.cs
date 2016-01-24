// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.ILayoutController
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

namespace UnityEngine.UI
{
  public interface ILayoutController
  {
    /// <summary>
    /// 
    /// <para>
    /// Callback invoked by the auto layout system which handles horizontal aspects of the layout.
    /// </para>
    /// 
    /// </summary>
    void SetLayoutHorizontal();

    /// <summary>
    /// 
    /// <para>
    /// Callback invoked by the auto layout system which handles vertical aspects of the layout.
    /// </para>
    /// 
    /// </summary>
    void SetLayoutVertical();
  }
}
