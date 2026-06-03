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
    public static class OMStupefy
    {
        private static readonly string FeatureName = "OMStupefyFeature";
        private static readonly string FeatureGuid = "80F02A11-4464-4C3A-A326-B9ECCD097621";

        private static readonly string AbilityName = "OMStupefyAbility";
        private static readonly string AbilityGuid = "B65E512B-71F2-42E8-BB66-4660C19A5D41";

        private static readonly string ActiveAbilityName = "OMStupefyActiveAbility";
        private static readonly string ActiveAbilityGuid = "AA4D9828-8443-4FB3-9652-B3D0B4BC8ED9";

        private static readonly string BuffName = "OMStupefyBuff";
        private static readonly string BuffGuid = "0E6CC398-5937-4374-AEDF-FDD41845D2F8";


        public static void Configure()
        {
            BuffConfigurator.New(BuffName, BuffGuid)
                .SetDisplayName(FeatureName + ".Name")
                .SetDescription(FeatureName + ".Description")
                .AddContextRankConfig
                    (
                        ContextRankConfigs
                            .ClassLevel(["08636672-3547-4DC5-AE9B-BAA8DCF4164B"], false, AbilityRankType.SpeedBonus)
                            .WithDivStepProgression(9)
                    )
                .AddContextCalculateAbilityParams(statType: Kingmaker.EntitySystem.Stats.StatType.Charisma)
                .AddInitiatorAttackWithWeaponTrigger
                (
                    onlyHit: false, onMiss: true, rangeType: Kingmaker.Enums.WeaponRangeType.MeleeNormal,
                    action : ActionsBuilder.New()
                        .SavingThrow
                        (
                            Kingmaker.EntitySystem.Stats.SavingThrowType.Fortitude,                            
                            onResult: ActionsBuilder.New()
                                .ConditionalSaved
                                    (
                                        failed: ActionsBuilder.New()
                                            .ApplyBuff
                                                (

                                                    BuffRefs.Paralyzed.Reference.Get(),
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

                                                            BuffRefs.Paralyzed.Reference.Get(),
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
                            .WithDivStepProgression(9)
                    )
                
                .AddContextCalculateAbilityParams(statType: Kingmaker.EntitySystem.Stats.StatType.Charisma)
                .AddAbilityEffectRunAction
                (
                    ActionsBuilder.New()
                        .SavingThrow
                        (
                            Kingmaker.EntitySystem.Stats.SavingThrowType.Fortitude,
                            onResult: ActionsBuilder.New()
                                .ConditionalSaved
                                    (
                                        failed: ActionsBuilder.New()
                                            .ApplyBuff
                                                (

                                                    BuffRefs.Paralyzed.Reference.Get(),
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
                .AddPrerequisiteFeature("B203288F-118C-451C-8416-3289260BC98A")
                .AddPrerequisiteClassLevel("08636672-3547-4DC5-AE9B-BAA8DCF4164B", 14)
                .AddFacts
                ([
                    AbilityGuid,
                    ActiveAbilityGuid
                ])
                .Configure();

            

            

        }

        
    }
}
