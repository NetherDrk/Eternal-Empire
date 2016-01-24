// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.CoroutineTween.ITweenValue
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

namespace UnityEngine.UI.CoroutineTween
{
  internal interface ITweenValue
  {
    bool ignoreTimeScale { get; }

    float duration { get; }

    void TweenValue(float floatPercentage);

    bool ValidTarget();
  }
}
