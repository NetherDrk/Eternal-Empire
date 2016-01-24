// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.BaseRaycaster
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.EventSystems
{
  /// <summary>
  /// 
  /// <para>
  /// Base class for any RayCaster.
  /// </para>
  /// 
  /// </summary>
  public abstract class BaseRaycaster : UIBehaviour
  {
    /// <summary>
    /// 
    /// <para>
    /// The camera that will generate rays for this raycaster.
    /// </para>
    /// 
    /// </summary>
    public abstract Camera eventCamera { get; }

    /// <summary>
    /// 
    /// <para>
    /// Priority of the caster relative to other casters.
    /// </para>
    /// 
    /// </summary>
    [Obsolete("Please use sortOrderPriority and renderOrderPriority", false)]
    public virtual int priority
    {
      get
      {
        return 0;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Priority of the raycaster based upon sort order.
    /// </para>
    /// 
    /// </summary>
    public virtual int sortOrderPriority
    {
      get
      {
        return int.MinValue;
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Priority of the raycaster based upon render order.
    /// </para>
    /// 
    /// </summary>
    public virtual int renderOrderPriority
    {
      get
      {
        return int.MinValue;
      }
    }

    public abstract void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList);

    public override string ToString()
    {
      return "Name: " + (object) this.gameObject + "\neventCamera: " + (string) (object) this.eventCamera + "\nsortOrderPriority: " + (string) (object) this.sortOrderPriority + "\nrenderOrderPriority: " + (string) (object) this.renderOrderPriority;
    }

    protected override void OnEnable()
    {
      base.OnEnable();
      RaycasterManager.AddRaycaster(this);
    }

    /// <summary>
    /// 
    /// <para>
    /// See MonoBehaviour.OnDisable.
    /// </para>
    /// 
    /// </summary>
    protected override void OnDisable()
    {
      RaycasterManager.RemoveRaycasters(this);
      base.OnDisable();
    }
  }
}
