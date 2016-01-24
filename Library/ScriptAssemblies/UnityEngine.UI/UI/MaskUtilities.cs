// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.MaskUtilities
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
  /// <summary>
  /// 
  /// <para>
  /// Mask related utility class.
  /// </para>
  /// 
  /// </summary>
  public class MaskUtilities
  {
    /// <summary>
    /// 
    /// <para>
    /// Notify all IClippables under the given component that they need to recalculate clipping.
    /// </para>
    /// 
    /// </summary>
    /// <param name="mask"/>
    public static void Notify2DMaskStateChanged(Component mask)
    {
      List<Component> list = ListPool<Component>.Get();
      mask.GetComponentsInChildren<Component>(list);
      for (int index = 0; index < list.Count; ++index)
      {
        if (!((Object) list[index] == (Object) null) && !((Object) list[index].gameObject == (Object) mask.gameObject))
        {
          IClippable clippable = list[index] as IClippable;
          if (clippable != null)
            clippable.RecalculateClipping();
        }
      }
      ListPool<Component>.Release(list);
    }

    /// <summary>
    /// 
    /// <para>
    /// Notify all IMaskable under the given component that they need to recalculate masking.
    /// </para>
    /// 
    /// </summary>
    /// <param name="mask"/>
    public static void NotifyStencilStateChanged(Component mask)
    {
      List<Component> list = ListPool<Component>.Get();
      mask.GetComponentsInChildren<Component>(list);
      for (int index = 0; index < list.Count; ++index)
      {
        if (!((Object) list[index] == (Object) null) && !((Object) list[index].gameObject == (Object) mask.gameObject))
        {
          IMaskable maskable = list[index] as IMaskable;
          if (maskable != null)
            maskable.RecalculateMasking();
        }
      }
      ListPool<Component>.Release(list);
    }

    /// <summary>
    /// 
    /// <para>
    /// Find a root Canvas.
    /// </para>
    /// 
    /// </summary>
    /// <param name="start">Search start.</param>
    /// <returns>
    /// 
    /// <para>
    /// Canvas transform.
    /// </para>
    /// 
    /// </returns>
    public static Transform FindRootSortOverrideCanvas(Transform start)
    {
      Transform transform1 = start;
      Transform transform2 = (Transform) null;
      for (; (Object) transform1 != (Object) null; transform1 = transform1.parent)
      {
        Canvas component = transform1.GetComponent<Canvas>();
        if ((Object) component != (Object) null && component.overrideSorting)
          return transform1;
        if ((Object) component != (Object) null)
          transform2 = transform1;
      }
      return transform2;
    }

    /// <summary>
    /// 
    /// <para>
    /// Find the stencil depth for a given element.
    /// </para>
    /// 
    /// </summary>
    /// <param name="transform"/><param name="stopAfter"/>
    public static int GetStencilDepth(Transform transform, Transform stopAfter)
    {
      int num = 0;
      if ((Object) transform == (Object) stopAfter)
        return num;
      Transform parent = transform.parent;
      List<Component> list = ListPool<Component>.Get();
      for (; (Object) parent != (Object) null; parent = parent.parent)
      {
        parent.GetComponents(typeof (Mask), list);
        for (int index = 0; index < list.Count; ++index)
        {
          if ((Object) list[index] != (Object) null && ((UIBehaviour) list[index]).IsActive() && ((Mask) list[index]).graphic.IsActive())
          {
            ++num;
            break;
          }
        }
        if ((Object) parent == (Object) stopAfter)
          break;
      }
      ListPool<Component>.Release(list);
      return num;
    }

    /// <summary>
    /// 
    /// <para>
    /// Find the correct RectMask2D for a given IClippable.
    /// </para>
    /// 
    /// </summary>
    /// <param name="transform">Clippable to search from.</param>
    public static RectMask2D GetRectMaskForClippable(IClippable transform)
    {
      Transform parent = transform.rectTransform.parent;
      List<Component> list = ListPool<Component>.Get();
      for (; (Object) parent != (Object) null; parent = parent.parent)
      {
        parent.GetComponents(typeof (RectMask2D), list);
        for (int index = 0; index < list.Count; ++index)
        {
          if ((Object) list[index] != (Object) null && ((UIBehaviour) list[index]).IsActive())
          {
            RectMask2D rectMask2D = (RectMask2D) list[index];
            ListPool<Component>.Release(list);
            return rectMask2D;
          }
        }
        if ((bool) ((Object) parent.GetComponent<Canvas>()))
          break;
      }
      ListPool<Component>.Release(list);
      return (RectMask2D) null;
    }

    public static void GetRectMasksForClip(RectMask2D clipper, List<RectMask2D> masks)
    {
      masks.Clear();
      Transform transform = clipper.transform;
      List<Component> list = ListPool<Component>.Get();
      for (; (Object) transform != (Object) null; transform = transform.parent)
      {
        transform.GetComponents(typeof (RectMask2D), list);
        for (int index = 0; index < list.Count; ++index)
        {
          if ((Object) list[index] != (Object) null && ((UIBehaviour) list[index]).IsActive())
            masks.Add((RectMask2D) list[index]);
        }
        if ((bool) ((Object) transform.GetComponent<Canvas>()))
          break;
      }
      ListPool<Component>.Release(list);
    }
  }
}
