

using System.Collections.Generic;
using UnityEngine;

public class EffectModel
{
    private EffectConfig effectConfig;

    public EffectConfig Config => effectConfig;


    public EffectModel(EffectConfig effectConfig)
    {
        this.effectConfig = effectConfig;
        Debug.Log("Effect Created: " + this.effectConfig.EffectName);
    }

    public EffectModel ApplyEffect(EffectConfig appliedConfig)
    {
        List<ChainReaction> chainReactions = this.effectConfig.reactions;
        ChainReaction chainReaction = chainReactions.Find(x => x.Catalyst == appliedConfig);
        
        if(chainReaction != null)
        {
            return new EffectModel(chainReaction.Reaction);
        }
        return null;
    }


    public override string ToString()
    {
        return "EffectModel{\n" + this.effectConfig.name + "\n}";
    }
}