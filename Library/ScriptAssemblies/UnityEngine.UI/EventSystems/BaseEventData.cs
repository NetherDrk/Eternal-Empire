// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.BaseEventData
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine;

namespace UnityEngine.EventSystems
{
  /// <summary>
  /// 
  /// <para>
  /// A class that contains the base event data that is common to all event types in the new EventSystem.
  /// </para>
  /// 
  /// </summary>
  public class BaseEventData : AbstractEventData
  {
    private readonly EventSystem m_EventSystem;

    /// <summary>
    /// 
    /// <para>
    /// A reference to the BaseInputModule that sent this event.
    /// </para>
    /// 
    /// </summary>
    public BaseInputModule currentInputModule
    {
      get
      {
        return this.m_EventSystem.currentInputModule;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// The object currently considered selected by the EventSystem.
    /// </para>
    /// 
    /// </summary>
    public GameObject selectedObject
    {
      get
      {
        return this.m_EventSystem.currentSelectedGameObject;
      }
      set
      {
        this.m_EventSystem.SetSelectedGameObject(value, this);
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Construct a BaseEventData tied to the passed EventSystem.
    /// </para>
    /// 
    /// </summary>
    /// <param name="eventSystem"/>
    public BaseEventData(EventSystem eventSystem)
    {
      this.m_EventSystem = eventSystem;
    }
  }
}
