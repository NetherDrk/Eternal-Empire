﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.GraphicRaycaster
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
  /// <summary>
  /// 
  /// <para>
  /// A BaseRaycaster to raycast against Graphic elements.
  /// </para>
  /// 
  /// </summary>
  [AddComponentMenu("Event/Graphic Raycaster")]
  [RequireComponent(typeof (Canvas))]
  public class GraphicRaycaster : BaseRaycaster
  {
    [NonSerialized]
    private static readonly List<Graphic> s_SortedGraphics = new List<Graphic>();
    [FormerlySerializedAs("ignoreReversedGraphics")]
    [SerializeField]
    private bool m_IgnoreReversedGraphics = true;
    [SerializeField]
    protected LayerMask m_BlockingMask = (LayerMask) -1;
    [NonSerialized]
    private List<Graphic> m_RaycastResults = new List<Graphic>();
    protected const int kNoEventMaskSet = -1;
    [SerializeField]
    [FormerlySerializedAs("blockingObjects")]
    private GraphicRaycaster.BlockingObjects m_BlockingObjects;
    private Canvas m_Canvas;

    public override int sortOrderPriority
    {
      get
      {
        if (this.canvas.renderMode == RenderMode.ScreenSpaceOverlay)
          return this.canvas.sortingOrder;
        return base.sortOrderPriority;
      }
    }

    public override int renderOrderPriority
    {
      get
      {
        if (this.canvas.renderMode == RenderMode.ScreenSpaceOverlay)
          return this.canvas.renderOrder;
        return base.renderOrderPriority;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Should graphics facing away from the raycaster be considered?
    /// </para>
    /// 
    /// </summary>
    public bool ignoreReversedGraphics
    {
      get
      {
        return this.m_IgnoreReversedGraphics;
      }
      set
      {
        this.m_IgnoreReversedGraphics = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Type of objects that will block graphic raycasts.
    /// </para>
    /// 
    /// </summary>
    public GraphicRaycaster.BlockingObjects blockingObjects
    {
      get
      {
        return this.m_BlockingObjects;
      }
      set
      {
        this.m_BlockingObjects = value;
      }
    }

    private Canvas canvas
    {
      get
      {
        if ((UnityEngine.Object) this.m_Canvas != (UnityEngine.Object) null)
          return this.m_Canvas;
        this.m_Canvas = this.GetComponent<Canvas>();
        return this.m_Canvas;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// See: BaseRaycaster.
    /// </para>
    /// 
    /// </summary>
    public override Camera eventCamera
    {
      get
      {
        if (this.canvas.renderMode == RenderMode.ScreenSpaceOverlay || this.canvas.renderMode == RenderMode.ScreenSpaceCamera && (UnityEngine.Object) this.canvas.worldCamera == (UnityEngine.Object) null)
          return (Camera) null;
        if ((UnityEngine.Object) this.canvas.worldCamera != (UnityEngine.Object) null)
          return this.canvas.worldCamera;
        return Camera.main;
      }
    }

    protected GraphicRaycaster()
    {
    }

    public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
    {
      if ((UnityEngine.Object) this.canvas == (UnityEngine.Object) null)
        return;
      Vector2 vector2;
      if ((UnityEngine.Object) this.eventCamera == (UnityEngine.Object) null)
      {
        int targetDisplay = this.canvas.targetDisplay;
        float num1 = (float) Screen.width;
        float num2 = (float) Screen.height;
        if (Screen.fullScreen && targetDisplay < Display.displays.Length)
        {
          num1 = (float) Display.displays[targetDisplay].systemWidth;
          num2 = (float) Display.displays[targetDisplay].systemHeight;
        }
        vector2 = new Vector2(eventData.position.x / num1, eventData.position.y / num2);
      }
      else
        vector2 = (Vector2) this.eventCamera.ScreenToViewportPoint((Vector3) eventData.position);
      if ((double) vector2.x < 0.0 || (double) vector2.x > 1.0 || ((double) vector2.y < 0.0 || (double) vector2.y > 1.0))
        return;
      float num3 = float.MaxValue;
      Ray ray = new Ray();
      if ((UnityEngine.Object) this.eventCamera != (UnityEngine.Object) null)
        ray = this.eventCamera.ScreenPointToRay((Vector3) eventData.position);
      if (this.canvas.renderMode != RenderMode.ScreenSpaceOverlay && this.blockingObjects != GraphicRaycaster.BlockingObjects.None)
      {
        float num1 = 100f;
        if ((UnityEngine.Object) this.eventCamera != (UnityEngine.Object) null)
          num1 = this.eventCamera.farClipPlane - this.eventCamera.nearClipPlane;
        RaycastHit hitInfo;
        if ((this.blockingObjects == GraphicRaycaster.BlockingObjects.ThreeD || this.blockingObjects == GraphicRaycaster.BlockingObjects.All) && Physics.Raycast(ray, out hitInfo, num1, (int) this.m_BlockingMask))
          num3 = hitInfo.distance;
        if (this.blockingObjects == GraphicRaycaster.BlockingObjects.TwoD || this.blockingObjects == GraphicRaycaster.BlockingObjects.All)
        {
          RaycastHit2D raycastHit2D = Physics2D.Raycast((Vector2) ray.origin, (Vector2) ray.direction, num1, (int) this.m_BlockingMask);
          if ((UnityEngine.Object) raycastHit2D.collider != (UnityEngine.Object) null)
            num3 = raycastHit2D.fraction * num1;
        }
      }
      this.m_RaycastResults.Clear();
      GraphicRaycaster.Raycast(this.canvas, this.eventCamera, eventData.position, this.m_RaycastResults);
      for (int index = 0; index < this.m_RaycastResults.Count; ++index)
      {
        GameObject gameObject = this.m_RaycastResults[index].gameObject;
        bool flag = true;
        if (this.ignoreReversedGraphics)
          flag = !((UnityEngine.Object) this.eventCamera == (UnityEngine.Object) null) ? (double) Vector3.Dot(this.eventCamera.transform.rotation * Vector3.forward, gameObject.transform.rotation * Vector3.forward) > 0.0 : (double) Vector3.Dot(Vector3.forward, gameObject.transform.rotation * Vector3.forward) > 0.0;
        if (flag)
        {
          float num1;
          if ((UnityEngine.Object) this.eventCamera == (UnityEngine.Object) null || this.canvas.renderMode == RenderMode.ScreenSpaceOverlay)
          {
            num1 = 0.0f;
          }
          else
          {
            Transform transform = gameObject.transform;
            Vector3 forward = transform.forward;
            num1 = Vector3.Dot(forward, transform.position - ray.origin) / Vector3.Dot(forward, ray.direction);
            if ((double) num1 < 0.0)
              continue;
          }
          if ((double) num1 < (double) num3)
          {
            RaycastResult raycastResult = new RaycastResult()
            {
              gameObject = gameObject,
              module = (BaseRaycaster) this,
              distance = num1,
              screenPosition = eventData.position,
              index = (float) resultAppendList.Count,
              depth = this.m_RaycastResults[index].depth,
              sortingLayer = this.canvas.sortingLayerID,
              sortingOrder = this.canvas.sortingOrder
            };
            resultAppendList.Add(raycastResult);
          }
        }
      }
    }

    private static void Raycast(Canvas canvas, Camera eventCamera, Vector2 pointerPosition, List<Graphic> results)
    {
      IList<Graphic> graphicsForCanvas = GraphicRegistry.GetGraphicsForCanvas(canvas);
      for (int index = 0; index < graphicsForCanvas.Count; ++index)
      {
        Graphic graphic = graphicsForCanvas[index];
        if (graphic.depth != -1 && graphic.raycastTarget && (RectTransformUtility.RectangleContainsScreenPoint(graphic.rectTransform, pointerPosition, eventCamera) && graphic.Raycast(pointerPosition, eventCamera)))
          GraphicRaycaster.s_SortedGraphics.Add(graphic);
      }
      GraphicRaycaster.s_SortedGraphics.Sort((Comparison<Graphic>) ((g1, g2) => g2.depth.CompareTo(g1.depth)));
      for (int index = 0; index < GraphicRaycaster.s_SortedGraphics.Count; ++index)
        results.Add(GraphicRaycaster.s_SortedGraphics[index]);
      GraphicRaycaster.s_SortedGraphics.Clear();
    }

    /// <summary>
    /// 
    /// <para>
    /// List of Raycasters to check for canvas blocking elements.
    /// </para>
    /// 
    /// </summary>
    public enum BlockingObjects
    {
      None,
      TwoD,
      ThreeD,
      All,
    }
  }
}
