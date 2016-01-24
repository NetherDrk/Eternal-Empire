// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.Navigation
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
  /// <summary>
  /// 
  /// <para>
  /// Structure storing details related to navigation.
  /// </para>
  /// 
  /// </summary>
  [Serializable]
  public struct Navigation
  {
    [FormerlySerializedAs("mode")]
    [SerializeField]
    private Navigation.Mode m_Mode;
    [SerializeField]
    [FormerlySerializedAs("selectOnUp")]
    private Selectable m_SelectOnUp;
    [SerializeField]
    [FormerlySerializedAs("selectOnDown")]
    private Selectable m_SelectOnDown;
    [FormerlySerializedAs("selectOnLeft")]
    [SerializeField]
    private Selectable m_SelectOnLeft;
    [SerializeField]
    [FormerlySerializedAs("selectOnRight")]
    private Selectable m_SelectOnRight;

    /// <summary>
    /// 
    /// <para>
    /// Navitation mode.
    /// </para>
    /// 
    /// </summary>
    public Navigation.Mode mode
    {
      get
      {
        return this.m_Mode;
      }
      set
      {
        this.m_Mode = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Selectable to select on up.
    /// </para>
    /// 
    /// </summary>
    public Selectable selectOnUp
    {
      get
      {
        return this.m_SelectOnUp;
      }
      set
      {
        this.m_SelectOnUp = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Selectable to select on down.
    /// </para>
    /// 
    /// </summary>
    public Selectable selectOnDown
    {
      get
      {
        return this.m_SelectOnDown;
      }
      set
      {
        this.m_SelectOnDown = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Selectable to select on left.
    /// </para>
    /// 
    /// </summary>
    public Selectable selectOnLeft
    {
      get
      {
        return this.m_SelectOnLeft;
      }
      set
      {
        this.m_SelectOnLeft = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Selectable to select on right.
    /// </para>
    /// 
    /// </summary>
    public Selectable selectOnRight
    {
      get
      {
        return this.m_SelectOnRight;
      }
      set
      {
        this.m_SelectOnRight = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Return a Navigation with sensible default values.
    /// </para>
    /// 
    /// </summary>
    public static Navigation defaultNavigation
    {
      get
      {
        return new Navigation()
        {
          m_Mode = Navigation.Mode.Automatic
        };
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Navigation mode. Used by Selectable.
    /// </para>
    /// 
    /// </summary>
    [Flags]
    public enum Mode
    {
      None = 0,
      Horizontal = 1,
      Vertical = 2,
      Automatic = Vertical | Horizontal,
      Explicit = 4,
    }
  }
}
