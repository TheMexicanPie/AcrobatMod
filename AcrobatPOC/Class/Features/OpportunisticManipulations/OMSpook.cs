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
    public static class OMSpook
    {
        private static readonly string FeatureName = "OMSpookFeature";
        private static readonly string FeatureGuid = "B47EDADB-478E-4F7E-8052-1FECFE987A77";

        private static readonly string AbilityName = "OMSpookAbility";
        private static readonly string AbilityGuid = "EB344A3C-B160-4253-B873-E58DF7F08476";

        private static readonly string ActiveAbilityName = "OMSpookActiveAbility";
        private static readonly string ActiveAbilityGuid = "06ADEAF7-6353-48ED-AD32-37BF229A4A5B";

        private static readonly string BuffName = "OMSpookBuff";
        private static readonly string BuffGuid = "A98B12CF-CF5D-42CF-ABA1-92E095928F58";


        public static void Configure()
        {
            BuffConfigurator.New(BuffName, BuffGuid)
                .SetDisplayName(FeatureName + ".Name")
                .SetDescription(FeatureName + ".Description")
                .AddContextRankConfig
                    (
                        ContextRankConfigs
                            .ClassLevel(["08636672-3547-4DC5-AE9B-BAA8DCF4164B"], false, AbilityRankType.SpeedBonus)
                            .WithDiv2Progression()
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

                                                    BuffRefs.Shaken.Reference.Get(),
                                                    ContextDuration.Variable(ContextValues.Rank(AbilityRankType.SpeedBonus), DurationRate.Rounds)
                                                )

                                    )
                        )

                )
                .AddInitiatorAttackWithWeaponTrigger
                (
                    onlyHit: true, rangeType: Kingmaker.Enums.WeaponRangeType.MeleeNormal,
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

                                                            BuffRefs.Shaken.Reference.Get(),
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
                            .WithDiv2Progression()
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

                                                    BuffRefs.Shaken.Reference.Get(),
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
                /*.AddIncreaseSpellDC
                (
                    value: ContextValues.Property(UnitProperty.StatBonusCharisma),
                    spell: ActiveAbilityGuid,
                    spellsOnly: false,
                    useContextBonus: true
                )
                .AddIncreaseSpellDC
                (
                    value: ContextValues.Property(UnitProperty.StatBonusCharisma),
                    spell: BuffGuid,
                    spellsOnly: false,
                    useContextBonus: true
                )*/
                .AddFacts
                ([
                    AbilityGuid,
                    ActiveAbilityGuid
                ])
                .Configure();

            

            

        }

        
    }
}
