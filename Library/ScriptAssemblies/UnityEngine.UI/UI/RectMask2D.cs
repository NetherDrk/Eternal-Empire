// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.RectMask2D
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
  /// <summary>
  /// 
  /// <para>
  /// A 2D rectangular mask that allows for clipping / masking of areas outside the mask.
  /// </para>
  /// 
  /// </summary>
  [ExecuteInEditMode]
  [DisallowMultipleComponent]
  [RequireComponent(typeof (RectTransform))]
  [AddComponentMenu("UI/2D Rect Mask", 13)]
  public class RectMask2D : UIBehaviour, ICanvasRaycastFilter, IClipper
  {
    [NonSerialized]
    private readonly RectangularVertexClipper m_VertexClipper = new RectangularVertexClipper();
    [NonSerialized]
    private List<IClippable> m_ClipTargets = new List<IClippable>();
    [NonSerialized]
    private List<RectMask2D> m_Clippers = new List<RectMask2D>();
    [NonSerialized]
    private RectTransform m_RectTransform;
    [NonSerialized]
    private bool m_ShouldRecalculateClipRects;
    [NonSerialized]
    private Rect m_LastClipRectCanvasSpace;
    [NonSerialized]
    private bool m_LastClipRectValid;

    /// <summary>
    /// 
    /// <para>
    /// Get the Rect for the mask in canvas space.
    /// </para>
    /// 
    /// </summary>
    public Rect canvasRect
    {
      get
      {
        Canvas c = (Canvas) null;
        List<Canvas> list = ListPool<Canvas>.Get();
        this.gameObject.GetComponentsInParent<Canvas>(false, list);
        if (list.Count > 0)
          c = list[0];
        ListPool<Canvas>.Release(list);
        return this.m_VertexClipper.GetCanvasRect(this.rectTransform, c);
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Get the RectTransform for the mask.
    /// </para>
    /// 
    /// </summary>
    public RectTransform rectTransform
    {
      get
      {
        return this.m_RectTransform ?? (this.m_RectTransform = this.GetComponent<RectTransform>());
      }
    }

    protected RectMask2D()
    {
    }

    protected override void OnEnable()
    {
      base.OnEnable();
      this.m_ShouldRecalculateClipRects = true;
      ClipperRegistry.Register((IClipper) this);
      MaskUtilities.Notify2DMaskStateChanged((Component) this);
    }

    protected override void OnDisable()
    {
      base.OnDisable();
      this.m_ClipTargets.Clear();
      this.m_Clippers.Clear();
      ClipperRegistry.Unregister((IClipper) this);
      MaskUtilities.Notify2DMaskStateChanged((Component) this);
    }

    protected override void OnValidate()
    {
      base.OnValidate();
      this.m_ShouldRecalculateClipRects = true;
      if (!this.IsActive())
        return;
      MaskUtilities.Notify2DMaskStateChanged((Component) this);
    }

    /// <summary>
    /// 
    /// <para>
    /// See:ICanvasRaycastFilter.
    /// </para>
    /// 
    /// </summary>
    /// <param name="sp"/><param name="eventCamera"/>
    public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
      if (!this.isActiveAndEnabled)
        return true;
      return RectTransformUtility.RectangleContainsScreenPoint(this.rectTransform, sp, eventCamera);
    }

    /// <summary>
    /// 
    /// <para>
    /// See: IClipper.PerformClipping.
    /// </para>
    /// 
    /// </summary>
    public virtual void PerformClipping()
    {
      if (this.m_ShouldRecalculateClipRects)
      {
        MaskUtilities.GetRectMasksForClip(this, this.m_Clippers);
        this.m_ShouldRecalculateClipRects = false;
      }
      bool validRect = true;
      Rect andClipWorldRect = Clipping.FindCullAndClipWorldRect(this.m_Clippers, out validRect);
      if (andClipWorldRect != this.m_LastClipRectCanvasSpace)
      {
        for (int index = 0; index < this.m_ClipTargets.Count; ++index)
          this.m_ClipTargets[index].SetClipRect(andClipWorldRect, validRect);
        this.m_LastClipRectCanvasSpace = andClipWorldRect;
        this.m_LastClipRectValid = validRect;
      }
      for (int index = 0; index < this.m_ClipTargets.Count; ++index)
        this.m_ClipTargets[index].Cull(this.m_LastClipRectCanvasSpace, this.m_LastClipRectValid);
    }

    /// <summary>
    /// 
    /// <para>
    /// Add a [IClippable]] to be tracked by the mask.
    /// </para>
    /// 
    /// </summary>
    /// <param name="clippable"/>
    public void AddClippable(IClippable clippable)
    {
      if (clippable == null)
        return;
      if (!this.m_ClipTargets.Contains(clippable))
        this.m_ClipTargets.Add(clippable);
      clippable.SetClipRect(this.m_LastClipRectCanvasSpace, this.m_LastClipRectValid);
      clippable.Cull(this.m_LastClipRectCanvasSpace, this.m_LastClipRectValid);
    }

    /// <summary>
    /// 
    /// <para>
    /// Remove an IClippable from being tracked by the mask.
    /// </para>
    /// 
    /// </summary>
    /// <param name="clippable"/>
    public void RemoveClippable(IClippable clippable)
    {
      if (clippable == null)
        return;
      clippable.SetClipRect(new Rect(), false);
      this.m_ClipTargets.Remove(clippable);
    }

    protected override void OnTransformParentChanged()
    {
      base.OnTransformParentChanged();
      this.m_ShouldRecalculateClipRects = true;
    }

    protected override void OnCanvasHierarchyChanged()
    {
      base.OnCanvasHierarchyChanged();
      this.m_ShouldRecalculateClipRects = true;
    }
  }
}
