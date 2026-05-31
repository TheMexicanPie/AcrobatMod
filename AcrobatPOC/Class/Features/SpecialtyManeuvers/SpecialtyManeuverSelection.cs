using AcrobatPOC.Features.SpecialtyManeuvers;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcrobatPOC.Class.Features
{
    public class SpecialtyManeuverSelection
    {
       
            private static readonly string FeatureName = "SpecialtyManeuverSelection";
            private static readonly string FeatureGuid = "95F5A426-8B4D-4F1D-AE7E-0B0C8813CC5F";

            public static void Configure()
            {

                SpecialtyManeuverBullRush.Configure();
                SpecialtyManeuverDirtyTrick.Configure();
                SpecialtyManeuverDisarm.Configure();
                SpecialtyManeuverGrapple.Configure();
                SpecialtyManeuverSunder.Configure();
                SpecialtyManeuverTrip.Configure();


                var config = FeatureSelectionConfigurator.New(FeatureName, FeatureGuid)
                    .SetDisplayName("SpecialtyManeuver.Name")
                    .SetDescription("SpecialtyManeuver.Description")
                    .SetIsClassFeature(true)
                    .AddToAllFeatures
                    ([
                        "C40B53F1-51E8-40E3-88FA-2A7989C62DE7", // Bull Rush
                        "DBF2256C-4B2B-460D-9D81-33638FA1E84F", // Disarm
                        "BB7F6432-20AE-4D89-A4B1-1DC59E4C7656", //Grapple
                        "DDDEF8BE-93CB-4BEE-B4E0-7AF2404C4192", //Sunder Armor
                        "B33039BF-1F19-4B96-B081-4449E4E02D31" // Trip
                    ])
                    .SetRanks(3)
                    ;

            
                
                // Check for prerequisite feats before adding the next ones to the list.   

                config.Configure();

            }
        
    }
}
