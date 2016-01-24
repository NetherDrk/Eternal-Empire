// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.SpriteState
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
  /// Structure to store the state of a sprite transition on a Selectable.
  /// </para>
  /// 
  /// </summary>
  [Serializable]
  public struct SpriteState
  {
    [SerializeField]
    [FormerlySerializedAs("highlightedSprite")]
    [FormerlySerializedAs("m_SelectedSprite")]
    private Sprite m_HighlightedSprite;
    [SerializeField]
    [FormerlySerializedAs("pressedSprite")]
    private Sprite m_PressedSprite;
    [SerializeField]
    [FormerlySerializedAs("disabledSprite")]
    private Sprite m_DisabledSprite;

    /// <summary>
    /// 
    /// <para>
    /// Highlighted sprite.
    /// </para>
    /// 
    /// </summary>
    public Sprite highlightedSprite
    {
      get
      {
        return this.m_HighlightedSprite;
      }
      set
      {
        this.m_HighlightedSprite = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Pressed sprite.
    /// </para>
    /// 
    /// </summary>
    public Sprite pressedSprite
    {
      get
      {
        return this.m_PressedSprite;
      }
      set
      {
        this.m_PressedSprite = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Disabled sprite.
    /// </para>
    /// 
    /// </summary>
    public Sprite disabledSprite
    {
      get
      {
        return this.m_DisabledSprite;
      }
      set
      {
        this.m_DisabledSprite = value;
      }
    }
  }
}
