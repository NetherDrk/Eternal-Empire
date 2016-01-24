// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.RaycasterManager
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using System.Collections.Generic;

namespace UnityEngine.EventSystems
{
  internal static class RaycasterManager
  {
    private static readonly List<BaseRaycaster> s_Raycasters = new List<BaseRaycaster>();

    public static void AddRaycaster(BaseRaycaster baseRaycaster)
    {
      if (RaycasterManager.s_Raycasters.Contains(baseRaycaster))
        return;
      RaycasterManager.s_Raycasters.Add(baseRaycaster);
    }

    public static List<BaseRaycaster> GetRaycasters()
    {
      return RaycasterManager.s_Raycasters;
    }

    public static void RemoveRaycasters(BaseRaycaster baseRaycaster)
    {
      if (!RaycasterManager.s_Raycasters.Contains(baseRaycaster))
        return;
      RaycasterManager.s_Raycasters.Remove(baseRaycaster);
    }
  }
}
