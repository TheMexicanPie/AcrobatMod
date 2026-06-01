using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.RuleSystem.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcrobatPOC.Feats
{
    public static class ImprovedGrapple
    {
        private static readonly string FeatName = "ImprovedGrappleFeature";
        private static readonly string FeatGuid = "34CF93AC-0C65-410B-9FDA-5B9C90D2148D";


        private static readonly string AbilityName1 = "ImprovedGrappleAbility";
        private static readonly string AbilityGuid1 = "4B546438-224A-4046-B4FF-B7D4A086D3CD";

        private static readonly string AbilityName2 = "ImprovedGrappleReleasAbility";
        private static readonly string AbilityGuid2 = "06B49FC7-8185-4916-A1E6-EC9A26614BD3";


        private static readonly string BuffName1 = "ImprovedGrappleInitiatorBuff";
        private static readonly string BuffGuid1 = "27F6B436-34F9-4BD7-93AE-3467E2044629";

        private static readonly string BuffName2 = "ImprovedGrappleTargetBuff";
        private static readonly string BuffGuid2 = "8FDEE8E1-5108-42A0-8246-253A018EA60F";

        public static void Configure()
        {
            BuffConfigurator.New(BuffName2, BuffGuid2)
                .SetDisplayName("GrappledBuff.Name")
                .SetDescription("GrappledBuff.Description")
                .AddRemoveBuffIfCasterIsMissing()
                .AddShifterGrabTargetBuff(-2, -4, pinnedACBonus: -4)
                .Configure();

            BuffConfigurator.New(BuffName1, BuffGuid1)
                .SetDisplayName("GrappledBuff.Name")
                .SetDescription("GrappledBuff.Description")
                .AddRemoveBuffIfCasterIsMissing()
                .AddManeuverTrigger
                    (
                        ActionsBuilder.New().MeleeAttack(autoHit: true, ignoreStatBonus: true),
                        CombatManeuver.Grapple,
                        true
                    )
                .AddShifterGrabInitiatorBuff(-2,-4)
                .AddCMBBonusForManeuver(maneuvers: [CombatManeuver.Grapple], descriptor: Kingmaker.Enums.ModifierDescriptor.Circumstance,value: 5)
                .AddStatBonus(stat: Kingmaker.EntitySystem.Stats.StatType.AdditionalCMD, value: 2)
                .Configure();


            AbilityConfigurator.New(AbilityName2, AbilityGuid2)
                .SetDisplayName("ImprovedGrappleRelease.Name")
                .SetDescription("ImprovedGrappleRelease.Description")
                .SetType(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.CombatManeuver)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Free)
                .AddAbilityEffectRunAction
                (
                    ActionsBuilder.New()
                        .ReleaseGrapple()
                )
                .SetAllowNonContextActions(false)
                .Configure();

            AbilityConfigurator.New(AbilityName1, AbilityGuid1)
                .SetDisplayName("ImprovedGrapple.Name")
                .SetDescription("ImprovedGrapple.Description")
                .SetType(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.CombatManeuver)
                .SetCanTargetEnemies(true)
                .SetCanTargetSelf(false)
                .SetShouldTurnToTarget(true)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .SetAnimation(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Special)
                .AddAbilityEffectRunAction
                (
                    ActionsBuilder.New()
                        .CombatManeuverCustom
                        (
                            CombatManeuver.Grapple,
                            success : ActionsBuilder.New()
                                .Grapple
                                (
                                    BuffGuid1,
                                    BuffGuid2
                                )
                        )
                    
                )
                .Configure();


            FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat)
                .SetDisplayName("ImprovedGrapple.Name")
                .SetDescription("ImprovedGrapple.Description")
                .AddFeatureTagsComponent(featureTags: Kingmaker.Blueprints.Classes.Selection.FeatureTag.CombatManeuver)
                .AddPrerequisiteFeature(FeatureRefs.ImprovedUnarmedStrike.Reference.Get())
                .AddPrerequisiteStatValue(Kingmaker.EntitySystem.Stats.StatType.Dexterity, 13)
                .AddCMBBonusForManeuver(maneuvers: [CombatManeuver.Grapple], value: 2)
                .AddCMDBonusAgainstManeuvers(maneuvers: [CombatManeuver.Grapple], value: 2)
                .AddFacts
                ([
                    AbilityGuid1, 
                    AbilityGuid2
                ])
                .Configure();
            //FeatureSelectionConfigurator.For(FeatureSelectionRefs.BasicFeatSelection).AddToAllFeatures(FeatName).Configure();

        }


    }
}
