using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Root.Fx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using MicroWrath.Extensions;

//using MicroWrath.BlueprintInitializationContext;
//using MicroWrath.BlueprintsDb;
//using MicroWrath.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Kingmaker.Designers.AbilitiesHelper;

namespace AcrobatPOC.Class.Features.OpportunisticManipulations
{
    public static class OMBefuddle
    {
        private static readonly string FeatureName = "OMBefuddleFeature";
        private static readonly string FeatureGuid = "BC522267-9C21-4D47-B085-9DF90536887D";

        private static readonly string AbilityName = "OMBefuddleAbility";
        private static readonly string AbilityGuid = "B26A28E0-D475-4AC6-9E78-962CF732E147";

        private static readonly string ActiveAbilityName = "OMBefuddleActiveAbility";
        private static readonly string ActiveAbilityGuid = "D03FA45D-8462-4AF6-9DE9-7211C7F6E374";

        private static readonly string BuffName = "OMBefuddleBuff";
        private static readonly string BuffGuid = "6091C36C-D873-439D-B836-911913D6F5AF";


        public static void Configure()
        {
            BuffConfigurator.New(BuffName, BuffGuid)
                .SetDisplayName(FeatureName + ".Name")
                .SetDescription(FeatureName + ".Description")
                .AddContextRankConfig
                    (
                        ContextRankConfigs
                            .ClassLevel(["08636672-3547-4DC5-AE9B-BAA8DCF4164B"], false, AbilityRankType.SpeedBonus)
                            .WithDivStepProgression(5)
                    )
                .AddContextCalculateAbilityParams(statType: Kingmaker.EntitySystem.Stats.StatType.Charisma)
                .AddInitiatorAttackWithWeaponTrigger
                (
                    onlyHit: false, onMiss: true, rangeType: Kingmaker.Enums.WeaponRangeType.MeleeNormal,
                    action : ActionsBuilder.New()
                        .SavingThrow
                        (
                            Kingmaker.EntitySystem.Stats.SavingThrowType.Will,                            
                            onResult: ActionsBuilder.New()
                                .ConditionalSaved
                                    (
                                        failed: ActionsBuilder.New()
                                            .ApplyBuff
                                                (

                                                    BuffRefs.Confusion.Reference.Get(),
                                                    ContextDuration.Variable(ContextValues.Rank(AbilityRankType.SpeedBonus), DurationRate.Rounds)
                                                )

                                    )
                        )

                )
                .AddInitiatorAttackWithWeaponTrigger
                (
                    onlyHit: true, rangeType: Kingmaker.Enums.WeaponRangeType.MeleeNormal, onlyOnFirstHit: true,
                    action: ActionsBuilder.New()
                        .Conditional
                        (
                            conditions: ConditionsBuilder.New()
                                .CasterHasFact("C92D6486-4DDF-47B6-8FAD-C13ECAC68C10"),
                            ifTrue: ActionsBuilder.New()
                                .SavingThrow
                                (
                                    Kingmaker.EntitySystem.Stats.SavingThrowType.Will,
                                    onResult: ActionsBuilder.New()
                                        .ConditionalSaved
                                            (
                                                failed: ActionsBuilder.New()
                                                    .ApplyBuff
                                                        (

                                                            BuffRefs.Confusion.Reference.Get(),
                                                            ContextDuration.Variable(ContextValues.Rank(AbilityRankType.SpeedBonus), DurationRate.Rounds)
                                                        )

                                            )
                                )
                        )
                )
                .Configure();


            AbilityConfigurator.New(ActiveAbilityName, ActiveAbilityGuid)
                .SetDisplayName(ActiveAbilityName + ".Name")
                .SetDescription(ActiveAbilityName + ".Description")
                .SetType(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary)
                .SetCanTargetEnemies(true)
                .SetCanTargetSelf(false)
                .SetShouldTurnToTarget(true)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .SetAnimation(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Special)
                .AddContextRankConfig
                    (
                        ContextRankConfigs
                            .ClassLevel(["08636672-3547-4DC5-AE9B-BAA8DCF4164B"], false,AbilityRankType.SpeedBonus)
                            .WithDivStepProgression(5)
                    )
                
                .AddContextCalculateAbilityParams(statType: Kingmaker.EntitySystem.Stats.StatType.Charisma)
                .AddAbilityEffectRunAction
                (
                    ActionsBuilder.New()
                        .SavingThrow
                        (
                            Kingmaker.EntitySystem.Stats.SavingThrowType.Will,
                            onResult: ActionsBuilder.New()
                                .ConditionalSaved
                                    (
                                        failed: ActionsBuilder.New()
                                            .ApplyBuff
                                                (

                                                    BuffRefs.Confusion.Reference.Get(),
                                                    ContextDuration.Variable(ContextValues.Rank(AbilityRankType.SpeedBonus), DurationRate.Rounds)
                                                )

                                    )
                        )

                )
                .Configure();

            ActivatableAbilityConfigurator.New(AbilityName, AbilityGuid)
                .SetDisplayName(FeatureName + ".Name")
                .SetDescription(FeatureName + ".Description")
                .SetGroup(OpportunisticManipulationSelection.OpportunisticManipulationAbilityGroup)
                .SetBuff(BuffGuid)
                .Configure();

            FeatureConfigurator.New(FeatureName, FeatureGuid)
                .SetDisplayName(FeatureName + ".Name")
                .SetDescription(FeatureName + ".Description")
                //.AddPrerequisiteFeature(FeatureRefs.ImprovedSunder.Reference.Get())
                .AddPrerequisiteClassLevel("08636672-3547-4DC5-AE9B-BAA8DCF4164B", 8)
                .AddFacts
                ([
                    AbilityGuid,
                    ActiveAbilityGuid
                ])
                .Configure();

            

            

        }

        
    }
}
