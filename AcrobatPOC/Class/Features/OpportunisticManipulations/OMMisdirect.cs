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
    public static class OMMisdirect
    {
        private static readonly string FeatureName = "OMMisdirectFeature";
        private static readonly string FeatureGuid = "BFA02F63-1DEF-4E19-AD0D-41C36EFF18F5";


        private static readonly string AbilityName1 = "OMMisdirectAbilitySicken";
        private static readonly string AbilityGuid1 = "F1A75DB1-77AA-4347-8A80-253F12B82F0F";

        private static readonly string AbilityName2 = "OMMisdirectAbilityBlind";
        private static readonly string AbilityGuid2 = "8E686EBB-435B-41C2-B7DA-C03035E84C3F";

        private static readonly string AbilityName3 = "OMMisdirectAbilityEntangle";
        private static readonly string AbilityGuid3 = "C2A9E35B-31B0-49DA-82D0-1682E4035761";


        private static readonly string BuffName1 = "OMMisdirectBuffSicken";
        private static readonly string BuffGuid1 = "F61E17D1-1862-44CB-A89D-325C7CBBAA9E";

        private static readonly string BuffName2 = "OMMisdirectBuffBlind";
        private static readonly string BuffGuid2 = "78D6FF58-69F9-4543-B13E-8A83ED799BE0";

        private static readonly string BuffName3 = "OMMisdirectBuffEntangle";
        private static readonly string BuffGuid3 = "5B48E4CD-52F9-4F53-969E-65759056DF16";


        public static void Configure() // OMSnowflake
        {
            BuffConfigurator.New(BuffName3, BuffGuid3)
                .SetDisplayName(AbilityName3 + ".Name")
                .SetDescription(AbilityName3 + ".Description")
                .AddInitiatorAttackWithWeaponTrigger
                (
                    onlyHit: false, onMiss: true, rangeType: Kingmaker.Enums.WeaponRangeType.MeleeNormal,
                    action: ActionsBuilder.New()
                        .CombatManeuver(onSuccess: null, type: CombatManeuver.DirtyTrickEntangle)
                )
                .AddInitiatorAttackWithWeaponTrigger
                (
                    onlyHit: true, rangeType: Kingmaker.Enums.WeaponRangeType.MeleeNormal, onlyOnFirstAttack: true,
                    action: ActionsBuilder.New()
                        .Conditional
                        (
                            conditions: ConditionsBuilder.New()
                                .CasterHasFact("C92D6486-4DDF-47B6-8FAD-C13ECAC68C10"),
                            ifTrue: ActionsBuilder.New()
                                .CombatManeuver(onSuccess: null, type: CombatManeuver.DirtyTrickEntangle)
                        )
                )
                .Configure();

            ActivatableAbilityConfigurator.New(AbilityName3, AbilityGuid3)
                .SetDisplayName(AbilityName3 + ".Name")
                .SetDescription(AbilityName3 + ".Description")
                .SetGroup(OpportunisticManipulationSelection.OpportunisticManipulationAbilityGroup)
                .SetBuff(BuffGuid3)
                .Configure();


            BuffConfigurator.New(BuffName2, BuffGuid2)
                .SetDisplayName(AbilityName2 + ".Name")
                .SetDescription(AbilityName2 + ".Description")
                .AddInitiatorAttackWithWeaponTrigger
                (
                    onlyHit: false, onMiss: true, rangeType: Kingmaker.Enums.WeaponRangeType.MeleeNormal,
                    action: ActionsBuilder.New()
                        .CombatManeuver(onSuccess: null, type: CombatManeuver.DirtyTrickBlind)
                )
                .AddInitiatorAttackWithWeaponTrigger
                (
                    onlyHit: true, rangeType: Kingmaker.Enums.WeaponRangeType.MeleeNormal, onlyOnFirstAttack: true,
                    action: ActionsBuilder.New()
                        .Conditional
                        (
                            conditions: ConditionsBuilder.New()
                                .CasterHasFact("C92D6486-4DDF-47B6-8FAD-C13ECAC68C10"),
                            ifTrue: ActionsBuilder.New()
                                .CombatManeuver(onSuccess: null, type: CombatManeuver.DirtyTrickBlind)
                        )
                )
                .Configure();

            ActivatableAbilityConfigurator.New(AbilityName2, AbilityGuid2)
                .SetDisplayName(AbilityName2 + ".Name")
                .SetDescription(AbilityName2 + ".Description")
                .SetGroup(OpportunisticManipulationSelection.OpportunisticManipulationAbilityGroup)
                .SetBuff(BuffGuid2)
                .Configure();


            BuffConfigurator.New(BuffName1, BuffGuid1)
                .SetDisplayName(AbilityName1 + ".Name")
                .SetDescription(AbilityName1 + ".Description")
                .AddInitiatorAttackWithWeaponTrigger
                (
                    onlyHit: false, onMiss: true, rangeType: Kingmaker.Enums.WeaponRangeType.MeleeNormal,
                    action: ActionsBuilder.New()
                        .CombatManeuver(onSuccess: null, type: CombatManeuver.DirtyTrickSickened)
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
                                .CombatManeuver(onSuccess: null, type: CombatManeuver.DirtyTrickSickened)
                        )
                )
                .Configure();

            ActivatableAbilityConfigurator.New(AbilityName1, AbilityGuid1)
                .SetDisplayName(AbilityName1 + ".Name")
                .SetDescription(AbilityName1 + ".Description")
                .SetGroup(OpportunisticManipulationSelection.OpportunisticManipulationAbilityGroup)
                .SetBuff(BuffGuid1)
                .Configure();


            FeatureConfigurator.New(FeatureName, FeatureGuid)
                .SetDisplayName(FeatureName + ".Name")
                .SetDescription(FeatureName + ".Description")
                .AddPrerequisiteFeature(FeatureRefs.ImprovedDirtyTrick.Reference.Get())
                .AddFacts
                ([
                    AbilityGuid1,
                    AbilityGuid2, 
                    AbilityGuid3
                ])
                .Configure();

            

            

        }

        
    }
}
