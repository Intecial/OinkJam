using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectReactionConfig", menuName = "Scriptable Objects/EffectReactionConfig")]
public class EffectReactionConfig : ScriptableObject
{
    public HashSet<EffectConfig> reactions = new HashSet<EffectConfig>();
}
