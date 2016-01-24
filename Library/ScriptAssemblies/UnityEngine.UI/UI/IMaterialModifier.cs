// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.IMaterialModifier
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine;

namespace UnityEngine.UI
{
  public interface IMaterialModifier
  {
    /// <summary>
    /// 
    /// <para>
    /// Perform material modification in this function.
    /// </para>
    /// 
    /// </summary>
    /// <param name="baseMaterial">Configured Material.</param>
    /// <returns>
    /// 
    /// <para>
    /// Modified material.
    /// </para>
    /// 
    /// </returns>
    Material GetModifiedMaterial(Material baseMaterial);
  }
}
