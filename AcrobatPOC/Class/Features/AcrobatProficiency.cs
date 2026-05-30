using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcrobatPOC.Class.Features
{
    public class AcrobatProficiency
    {
        private static readonly string FeatureName = "AcrobatProficiencyFeature";
        private static readonly string FeatureGuid = "A7E1F749-81D8-485A-A0BA-F300F18620DD";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, FeatureGuid)
                .SetDisplayName("AcrobatProficiencyFeature.Name")
                .SetDescription("AcrobatProficiencyFeature.Description")
                .AddFacts(new() 
                { 
                    FeatureRefs.SimpleWeaponProficiency.Reference.Get(),
                    FeatureRefs.FlailProficiency.Reference.Get(),
                    FeatureRefs.HeavyFlailProficiency.Reference.Get(),
                    FeatureRefs.DoubleSwordProficiency.Reference.Get(),
                    FeatureRefs.NunchakuProficiency.Reference.Get(),
                    FeatureRefs.LightArmorProficiency.Reference.Get()
                })
                .SetIsClassFeature(true)
                
                //Check type of held weapon to add finessable subtype.
                
                


                .Configure();
            //FeatureSelectionConfigurator.For(FeatureSelectionRefs.BasicFeatSelection).AddToAllFeatures(FeatName).Configure();

        }
    }

 
}
