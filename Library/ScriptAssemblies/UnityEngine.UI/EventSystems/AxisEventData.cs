// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.AxisEventData
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine;

namespace UnityEngine.EventSystems
{
  /// <summary>
  /// 
  /// <para>
  /// Event Data associated with Axis Events (Controller / Keyboard).
  /// </para>
  /// 
  /// </summary>
  public class AxisEventData : BaseEventData
  {
    /// <summary>
    /// 
    /// <para>
    /// Raw input vector associated with this event.
    /// </para>
    /// 
    /// </summary>
    public Vector2 moveVector { get; set; }

    /// <summary>
    /// 
    /// <para>
    /// MoveDirection for this event.
    /// </para>
    /// 
    /// </summary>
    public MoveDirection moveDir { get; set; }

    public AxisEventData(EventSystem eventSystem)
      : base(eventSystem)
    {
      this.moveVector = Vector2.zero;
      this.moveDir = MoveDirection.None;
    }
  }
}
