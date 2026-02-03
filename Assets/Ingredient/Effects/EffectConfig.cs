using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectConfig", menuName = "Scriptable Objects/EffectConfig")]
public class EffectConfig : ScriptableObject
{
    public string EffectName;
    public Color Color;

    public List<ChainReaction> reactions = new List<ChainReaction>();
}

[System.Serializable]
public class ChainReaction
{
    public EffectConfig Catalyst;
    public EffectConfig Reaction;
}