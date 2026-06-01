using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.RuleSystem.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;

namespace AcrobatPOC.Feats
{
    public class GreaterGrapple
    {
        private static readonly string FeatName = "GreaterGrapple";
        private static readonly string FeatGuid = "0A250137-6ECA-49B8-939B-60843D96BA66";

        private static readonly string BuffName = "GreaterGrappleBuff";
        private static readonly string BuffGuid = "28A47D2B-43B9-4EEE-9AE6-572E57C2C148";

        public static void Configure() 
        {
            BuffConfigurator.New(BuffName, BuffGuid)
                .SetDisplayName("GreaterGrappleBuff.Name")
                .SetDescription("GreaterGrappleBuff.Description")
                .AddManeuverTrigger
                    (
                        ActionsBuilder.New().MeleeAttack(),
                        CombatManeuver.Grapple,
                        false
                    )
                .Configure();

            FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat)
                .SetDisplayName("GreaterGrappleFeat.Name")
                .SetDescription("GreaterGrappleFeat.Description")
                .AddPrerequisiteFeature(FeatureRefs.ImprovedUnarmedStrike.Reference.Get())
                .AddPrerequisiteStatValue(Kingmaker.EntitySystem.Stats.StatType.Dexterity, 13)
                .AddPrerequisiteFeature("34CF93AC-0C65-410B-9FDA-5B9C90D2148D")
                .AddPrerequisiteStatValue(Kingmaker.EntitySystem.Stats.StatType.BaseAttackBonus, 6)
                .AddCMBBonusForManeuver(maneuvers: [CombatManeuver.Grapple], value: 2)
                .AddFactsChangeTrigger
                (
                    ["27F6B436-34F9-4BD7-93AE-3467E2044629"], // Grapple Initiator Buff
                    onFactGainedActions: ActionsBuilder.New().ApplyBuffPermanent(BuffGuid), 
                    onFactLostActions: ActionsBuilder.New().RemoveBuff(BuffGuid)
                )
                .Configure();
            //FeatureSelectionConfigurator.For(FeatureSelectionRefs.BasicFeatSelection).AddToAllFeatures(FeatName).Configure();

        }
    }
}
