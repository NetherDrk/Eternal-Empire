// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.AbstractEventData
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

namespace UnityEngine.EventSystems
{
  /// <summary>
  /// 
  /// <para>
  /// A class that can be used for sending simple events via the event system.
  /// </para>
  /// 
  /// </summary>
  public abstract class AbstractEventData
  {
    protected bool m_Used;

    /// <summary>
    /// 
    /// <para>
    /// Is the event used?
    /// </para>
    /// 
    /// </summary>
    public virtual bool used
    {
      get
      {
        return this.m_Used;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Reset the event.
    /// </para>
    /// 
    /// </summary>
    public virtual void Reset()
    {
      this.m_Used = false;
    }

    /// <summary>
    /// 
    /// <para>
    /// Use the event.
    /// </para>
    /// 
    /// </summary>
    public virtual void Use()
    {
      this.m_Used = true;
    }
  }
}
