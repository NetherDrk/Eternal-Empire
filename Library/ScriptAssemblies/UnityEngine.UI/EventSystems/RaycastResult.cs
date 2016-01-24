// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.RaycastResult
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine;

namespace UnityEngine.EventSystems
{
  /// <summary>
  /// 
  /// <para>
  /// A hit result from a BaseRaycastModule.
  /// </para>
  /// 
  /// </summary>
  public struct RaycastResult
  {
    private GameObject m_GameObject;
    /// <summary>
    /// 
    /// <para>
    /// BaseInputModule that raised the hit.
    /// </para>
    /// 
    /// </summary>
    public BaseRaycaster module;
    /// <summary>
    /// 
    /// <para>
    /// Distance to the hit.
    /// </para>
    /// 
    /// </summary>
    public float distance;
    /// <summary>
    /// 
    /// <para>
    /// Hit index.
    /// </para>
    /// 
    /// </summary>
    public float index;
    /// <summary>
    /// 
    /// <para>
    /// The relative depth of the element.
    /// </para>
    /// 
    /// </summary>
    public int depth;
    /// <summary>
    /// 
    /// <para>
    /// The SortingLayer of the hit object.
    /// </para>
    /// 
    /// </summary>
    public int sortingLayer;
    /// <summary>
    /// 
    /// <para>
    /// The SortingOrder for the hit object.
    /// </para>
    /// 
    /// </summary>
    public int sortingOrder;
    /// <summary>
    /// 
    /// <para>
    /// The world position of the where the raycast has hit.
    /// </para>
    /// 
    /// </summary>
    public Vector3 worldPosition;
    /// <summary>
    /// 
    /// <para>
    /// The normal at the hit location of the raycast.
    /// </para>
    /// 
    /// </summary>
    public Vector3 worldNormal;
    /// <summary>
    /// 
    /// <para>
    /// The screen position from which the raycast was generated.
    /// </para>
    /// 
    /// </summary>
    public Vector2 screenPosition;

    /// <summary>
    /// 
    /// <para>
    /// The GameObject that was hit by the raycast.
    /// </para>
    /// 
    /// </summary>
    public GameObject gameObject
    {
      get
      {
        return this.m_GameObject;
      }
      set
      {
        this.m_GameObject = value;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Is there an associated module and a hit GameObject.
    /// </para>
    /// 
    /// </summary>
    public bool isValid
    {
      get
      {
        if ((Object) this.module != (Object) null)
          return (Object) this.gameObject != (Object) null;
        return false;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Reset the result.
    /// </para>
    /// 
    /// </summary>
    public void Clear()
    {
      this.gameObject = (GameObject) null;
      this.module = (BaseRaycaster) null;
      this.distance = 0.0f;
      this.index = 0.0f;
      this.depth = 0;
      this.sortingLayer = 0;
      this.sortingOrder = 0;
      this.worldNormal = Vector3.up;
      this.worldPosition = Vector3.zero;
      this.screenPosition = Vector2.zero;
    }

    public override string ToString()
    {
      if (!this.isValid)
        return string.Empty;
      return "Name: " + (object) this.gameObject + "\nmodule: " + (string) (object) this.module + "\nmodule camera: " + (string) (object) this.module.GetComponent<Camera>() + "\ndistance: " + (string) (object) this.distance + "\nindex: " + (string) (object) this.index + "\ndepth: " + (string) (object) this.depth + "\nworldNormal: " + (string) (object) this.worldNormal + "\nworldPosition: " + (string) (object) this.worldPosition + "\nscreenPosition: " + (string) (object) this.screenPosition + "\nmodule.sortOrderPriority: " + (string) (object) this.module.sortOrderPriority + "\nmodule.renderOrderPriority: " + (string) (object) this.module.renderOrderPriority + "\nsortingLayer: " + (string) (object) this.sortingLayer + "\nsortingOrder: " + (string) (object) this.sortingOrder;
    }
  }
}
