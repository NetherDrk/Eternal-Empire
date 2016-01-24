// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.ColorBlock
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
  /// Structure to store the state of a color transition on a Selectable.
  /// </para>
  /// 
  /// </summary>
  [Serializable]
  public struct ColorBlock
  {
    [FormerlySerializedAs("normalColor")]
    [SerializeField]
    private Color m_NormalColor;
    [FormerlySerializedAs("m_SelectedColor")]
    [FormerlySerializedAs("highlightedColor")]
    [SerializeField]
    private Color m_HighlightedColor;
    [SerializeField]
    [FormerlySerializedAs("pressedColor")]
    private Color m_PressedColor;
    [SerializeField]
    [FormerlySerializedAs("disabledColor")]
    private Color m_DisabledColor;
    [SerializeField]
    [Range(1f, 5f)]
    private float m_ColorMultiplier;
    [SerializeField]
    [FormerlySerializedAs("fadeDuration")]
    private float m_FadeDuration;

    /// <summary>
    /// 
    /// <para>
    /// Normal Color.
    /// </para>
    /// 
    /// </summary>
    public Color normalColor
    {
      get
      {
        return this.m_NormalColor;
      }
      set
      {
        this.m_NormalColor = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Highlighted Color.
    /// </para>
    /// 
    /// </summary>
    public Color highlightedColor
    {
      get
      {
        return this.m_HighlightedColor;
      }
      set
      {
        this.m_HighlightedColor = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Pressed Color.
    /// </para>
    /// 
    /// </summary>
    public Color pressedColor
    {
      get
      {
        return this.m_PressedColor;
      }
      set
      {
        this.m_PressedColor = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Disabled Color.
    /// </para>
    /// 
    /// </summary>
    public Color disabledColor
    {
      get
      {
        return this.m_DisabledColor;
      }
      set
      {
        this.m_DisabledColor = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Multiplier applied to colors (allows brightening greater then base color).
    /// </para>
    /// 
    /// </summary>
    public float colorMultiplier
    {
      get
      {
        return this.m_ColorMultiplier;
      }
      set
      {
        this.m_ColorMultiplier = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// How long a color transition should take.
    /// </para>
    /// 
    /// </summary>
    public float fadeDuration
    {
      get
      {
        return this.m_FadeDuration;
      }
      set
      {
        this.m_FadeDuration = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Simple getter for the default ColorBlock.
    /// </para>
    /// 
    /// </summary>
    public static ColorBlock defaultColorBlock
    {
      get
      {
        return new ColorBlock()
        {
          m_NormalColor = (Color) new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue),
          m_HighlightedColor = (Color) new Color32((byte) 245, (byte) 245, (byte) 245, byte.MaxValue),
          m_PressedColor = (Color) new Color32((byte) 200, (byte) 200, (byte) 200, byte.MaxValue),
          m_DisabledColor = (Color) new Color32((byte) 200, (byte) 200, (byte) 200, (byte) 128),
          colorMultiplier = 1f,
          fadeDuration = 0.1f
        };
      }
    }
  }
}
