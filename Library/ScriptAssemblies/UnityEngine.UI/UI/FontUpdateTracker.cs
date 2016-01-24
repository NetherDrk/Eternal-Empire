// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.FontUpdateTracker
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI
{
  /// <summary>
  /// 
  /// <para>
  /// Utility class that is used to help with Text update.
  /// </para>
  /// 
  /// </summary>
  public static class FontUpdateTracker
  {
    private static Dictionary<Font, List<Text>> m_Tracked = new Dictionary<Font, List<Text>>();

    /// <summary>
    /// 
    /// <para>
    /// Register a Text element for receiving texture atlas rebuild calls.
    /// </para>
    /// 
    /// </summary>
    /// <param name="t"/>
    public static void TrackText(Text t)
    {
      if ((UnityEngine.Object) t.font == (UnityEngine.Object) null)
        return;
      List<Text> list;
      FontUpdateTracker.m_Tracked.TryGetValue(t.font, out list);
      if (list == null)
      {
        if (FontUpdateTracker.m_Tracked.Count == 0)
          Font.textureRebuilt += new Action<Font>(FontUpdateTracker.RebuildForFont);
        list = new List<Text>();
        FontUpdateTracker.m_Tracked.Add(t.font, list);
      }
      if (list.Contains(t))
        return;
      list.Add(t);
    }

    private static void RebuildForFont(Font f)
    {
      List<Text> list;
      FontUpdateTracker.m_Tracked.TryGetValue(f, out list);
      if (list == null)
        return;
      for (int index = 0; index < list.Count; ++index)
        list[index].FontTextureChanged();
    }

    /// <summary>
    /// 
    /// <para>
    /// Deregister a Text element from receiving texture atlas rebuild calls.
    /// </para>
    /// 
    /// </summary>
    /// <param name="t"/>
    public static void UntrackText(Text t)
    {
      if ((UnityEngine.Object) t.font == (UnityEngine.Object) null)
        return;
      List<Text> list;
      FontUpdateTracker.m_Tracked.TryGetValue(t.font, out list);
      if (list == null)
        return;
      list.Remove(t);
      if (list.Count != 0)
        return;
      FontUpdateTracker.m_Tracked.Remove(t.font);
      if (FontUpdateTracker.m_Tracked.Count != 0)
        return;
      Font.textureRebuilt -= new Action<Font>(FontUpdateTracker.RebuildForFont);
    }
  }
}
