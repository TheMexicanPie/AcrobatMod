using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Root;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcrobatPOC.Class
{
    public class AcrobatClass
    {
        private static readonly string ClassName = "AcrobatClass";
        private static readonly string ClassGuid = "08636672-3547-4DC5-AE9B-BAA8DCF4164B";

        public static void Configure() 
        {

            var x = CharacterClassConfigurator.New(ClassName, ClassGuid)
                .SetLocalizedName("AcrobatClass.Name")
                .SetLocalizedDescription("AcrobatClass.Description")
                .SetLocalizedDescriptionShort("AcrobatClass.DescriptionShort")
                .SetSkillPoints(4)
                .SetHitDie(Kingmaker.RuleSystem.DiceType.D8)
                .SetHideIfRestricted(false)
                .SetHideInUI(false)
                .SetBaseAttackBonus("4c936de4249b61e419a3fb775b9f2581")
                .SetFortitudeSave("ff4662bde9e75f145853417313842751")
                .SetReflexSave("ff4662bde9e75f145853417313842751")
                .SetWillSave("dc0c7c1aba755c54f96c089cdf7d14a3")
                .SetProgression("57F31351-8FBC-470B-A455-C3F19798BED6")
                .SetClassSkills
                (
                    Kingmaker.EntitySystem.Stats.StatType.SkillAthletics,
                    Kingmaker.EntitySystem.Stats.StatType.SkillMobility,
                    Kingmaker.EntitySystem.Stats.StatType.SkillThievery,
                    Kingmaker.EntitySystem.Stats.StatType.SkillKnowledgeWorld,
                    Kingmaker.EntitySystem.Stats.StatType.SkillPerception,
                    Kingmaker.EntitySystem.Stats.StatType.SkillPersuasion,
                    Kingmaker.EntitySystem.Stats.StatType.SkillUseMagicDevice
                )
                .SetArchetypes()
                .SetStartingGold(411)
                .SetStartingItems
                (
                "629736dabac7f9f4a819dc854eaed2d6", //quarterstaff
                "afbe88d27a0eb544583e00fa78ffb2c7", //studded leather
                "d52566ae8cbe8dc4dae977ef51c27d91", //potion of cure light
                "5bb722fed5172ed48baa2139246bc355" // potion of blur
                )
                .SetPrimaryColor(46)
                .SetSecondaryColor(25)
                .SetEquipmentEntities("21d733c2019c4db780a172680e16198c")
                .SetMaleEquipmentEntities("eb4318c808dcb2e45a7184db61ab1c29", "cddd5bd766c85af40ab49d38eaf5bdea")
                .SetFemaleEquipmentEntities("436762cf39551fb48a0c540430666c18", "7a1655ab75173f74a93b6b369618f013")
                .SetDifficulty(3)
                .SetRecommendedAttributes(Kingmaker.EntitySystem.Stats.StatType.Dexterity, Kingmaker.EntitySystem.Stats.StatType.Charisma)
                .SetNotRecommendedAttributes(Kingmaker.EntitySystem.Stats.StatType.Strength)
                .SetSignatureAbilities("7C8B00CA-69D9-4F14-957B-1D9542A204DB", "95F5A426-8B4D-4F1D-AE7E-0B0C8813CC5F", "C596DF10-04A8-48D2-85F4-D10041585D51")
               
                ;

            BlueprintCharacterClass cclass = x.Configure();
            BlueprintCharacterClassReference classref = cclass.ToReference<BlueprintCharacterClassReference>();
            BlueprintRoot root = BlueprintTool.Get<BlueprintRoot>("2d77316c72b9ed44f888ceefc2a131f6");
            root.Progression.m_CharacterClasses = CommonTool.Append(root.Progression.m_CharacterClasses, classref);

        }
    }
}
