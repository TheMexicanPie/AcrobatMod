using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic;

namespace AcrobatPOC.Class.Features
{
    public class AcrobatProficiency
    {
        private static readonly string FeatureName = "AcrobatProficiencyFeature";
        private static readonly string FeatureGuid = "A7E1F749-81D8-485A-A0BA-F300F18620DD";

        private FactOwner factOwner;
        public static void Configure()
        {
            var FinesseBuff = FeatureConfigurator.New("AcrobatProficiencyFinesseBuff","B7538C90-B82D-4FAF-A7DF-620AFCA8ED79")
                .AddAttackStatReplacementFixed(new AttackStatReplacementFixed(StatType.Dexterity, WeaponTypeRefs.Quarterstaff.Reference.Get()))
                .AddAttackStatReplacementFixed(new AttackStatReplacementFixed(StatType.Dexterity, WeaponTypeRefs.Flail.Reference.Get()))
                .AddAttackStatReplacementFixed(new AttackStatReplacementFixed(StatType.Dexterity, WeaponTypeRefs.HeavyFlail.Reference.Get()))
                .AddAttackStatReplacementFixed(new AttackStatReplacementFixed(StatType.Dexterity, WeaponTypeRefs.DoubleSword.Reference.Get()))
                .AddAttackStatReplacementFixed(new AttackStatReplacementFixed(StatType.Dexterity, WeaponTypeRefs.Nunchaku.Reference.Get()))
                //.SetHideInUI(true)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(true)
                .Configure
                ;


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
                
                .AddAreaDidLoadTrigger
                (
                    ActionsBuilder.New()
                        .Conditional
                        (
                            ConditionsBuilder.New().HasFact(FeatureRefs.WeaponFinesse.Reference.Get()),
                            ifTrue : ActionsBuilder.New().AddFact("B7538C90-B82D-4FAF-A7DF-620AFCA8ED79" /* Finesse Buff */, unit: factOwner) //test
                        )
                )
                .Configure();
            //FeatureSelectionConfigurator.For(FeatureSelectionRefs.BasicFeatSelection).AddToAllFeatures(FeatName).Configure();

        }


    }

 
}
