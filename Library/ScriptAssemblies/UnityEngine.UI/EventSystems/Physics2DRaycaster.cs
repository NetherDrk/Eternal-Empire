// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.Physics2DRaycaster
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.EventSystems
{
  /// <summary>
  /// 
  /// <para>
  /// Raycaster for casting against 2D Physics components.
  /// </para>
  /// 
  /// </summary>
  [RequireComponent(typeof (Camera))]
  [AddComponentMenu("Event/Physics 2D Raycaster")]
  public class Physics2DRaycaster : PhysicsRaycaster
  {
    protected Physics2DRaycaster()
    {
    }

    public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
    {
      if ((Object) this.eventCamera == (Object) null)
        return;
      Ray ray = this.eventCamera.ScreenPointToRay((Vector3) eventData.position);
      float distance = this.eventCamera.farClipPlane - this.eventCamera.nearClipPlane;
      RaycastHit2D[] raycastHit2DArray = Physics2D.RaycastAll((Vector2) ray.origin, (Vector2) ray.direction, distance, this.finalEventMask);
      if (raycastHit2DArray.Length == 0)
        return;
      int index = 0;
      for (int length = raycastHit2DArray.Length; index < length; ++index)
      {
        SpriteRenderer component = raycastHit2DArray[index].collider.gameObject.GetComponent<SpriteRenderer>();
        RaycastResult raycastResult = new RaycastResult()
        {
          gameObject = raycastHit2DArray[index].collider.gameObject,
          module = (BaseRaycaster) this,
          distance = Vector3.Distance(this.eventCamera.transform.position, raycastHit2DArray[index].transform.position),
          worldPosition = (Vector3) raycastHit2DArray[index].point,
          worldNormal = (Vector3) raycastHit2DArray[index].normal,
          screenPosition = eventData.position,
          index = (float) resultAppendList.Count,
          sortingLayer = !((Object) component != (Object) null) ? 0 : component.sortingLayerID,
          sortingOrder = !((Object) component != (Object) null) ? 0 : component.sortingOrder
        };
        resultAppendList.Add(raycastResult);
      }
    }
  }
}
