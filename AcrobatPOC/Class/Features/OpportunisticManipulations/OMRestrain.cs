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
using Kingmaker.Localization;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
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
    public static class OMRestrain
    {
        private static readonly string FeatureName = "OMRestrainFeature";
        private static readonly string FeatureGuid = "0B96C20B-47B2-421A-8CDB-251953EE7DF3";

        private static readonly string AbilityName = "OMRestrainAbility";
        private static readonly string AbilityGuid = "F2ED9EEA-7A31-4C15-8E28-E452411233AF";

        private static readonly string BuffName = "OMRestrainBuff";
        private static readonly string BuffGuid = "53F995A4-D1B1-46BF-B167-B84A29C1FEEC";


        public static void Configure()
        {
            BuffConfigurator.New(BuffName, BuffGuid)
                .SetDisplayName(FeatureName + ".Name")
                .SetDescription(FeatureName + ".Description")
                .AddInitiatorAttackWithWeaponTrigger
                (
                    onlyHit: false, onMiss: true, rangeType: Kingmaker.Enums.WeaponRangeType.MeleeNormal,
                    action :ActionsBuilder.New()
                        .CombatManeuverCustom
                        (
                            CombatManeuver.Grapple,
                            success: ActionsBuilder.New()
                                .Grapple
                                (
                                    "27F6B436-34F9-4BD7-93AE-3467E2044629", // Grapple Initiator Buff
                                    "8FDEE8E1-5108-42A0-8246-253A018EA60F"  // Grapple Target Buff
                                )
                        )
                ).AddInitiatorAttackWithWeaponTrigger
                (
                    onlyHit: true, rangeType: Kingmaker.Enums.WeaponRangeType.MeleeNormal, onlyOnFirstHit: true,
                    action: ActionsBuilder.New()
                        .Conditional
                        (
                            conditions: ConditionsBuilder.New()
                                .CasterHasFact("C92D6486-4DDF-47B6-8FAD-C13ECAC68C10"),
                            ifTrue: ActionsBuilder.New()
                                .CombatManeuverCustom
                                (
                                    CombatManeuver.Grapple,
                                    success: ActionsBuilder.New()
                                        .Grapple
                                        (
                                            "27F6B436-34F9-4BD7-93AE-3467E2044629", // Grapple Initiator Buff
                                            "8FDEE8E1-5108-42A0-8246-253A018EA60F"  // Grapple Target Buff
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
                .AddPrerequisiteFeature("34CF93AC-0C65-410B-9FDA-5B9C90D2148D") // Improved Grapple
                .AddFacts
                ([
                    AbilityGuid
                ])
                .Configure();

            

            

        }

        
    }
}
