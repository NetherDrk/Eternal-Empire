﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.IEndDragHandler
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

namespace UnityEngine.EventSystems
{
  public interface IEndDragHandler : IEventSystemHandler
  {
    /// <summary>
    /// 
    /// <para>
    /// Called by a BaseInputModule when a drag is ended.
    /// </para>
    /// 
    /// </summary>
    /// <param name="eventData">Current event data.</param>
    void OnEndDrag(PointerEventData eventData);
  }
}
