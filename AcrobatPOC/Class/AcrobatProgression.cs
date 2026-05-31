using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcrobatPOC.Class
{
    internal class AcrobatProgression
    {
        private static readonly string ProgressionName = "AcrobatProgression";
        private static readonly string ProgressionGuid = "57F31351-8FBC-470B-A455-C3F19798BED6";

        public static void Configure()
        {
            var entries = LevelEntryBuilder.New()
                .AddEntry
                (1,
                "A7E1F749-81D8-485A-A0BA-F300F18620DD", // Acrobat Proficiencies
                FeatureRefs.AgileManeuvers.Reference.Get(),
                "A735C5B7-6328-4442-A7F2-8F32D00ED6F8", // Bonus Maneuver Feat 1
                "7C8B00CA-69D9-4F14-957B-1D9542A204DB" // Maneuver Mastery
                )
                .AddEntry
                (2,
                "95F5A426-8B4D-4F1D-AE7E-0B0C8813CC5F" //Specialty Maneuver
                )
                .AddEntry
                (3,
                FeatureRefs.Evasion.Reference.Get()
                )
                .AddEntry
                (5,
                "A735C5B7-6328-4442-A7F2-8F32D00ED6F8", // Bonus Maneuver Feat 1
                "7C8B00CA-69D9-4F14-957B-1D9542A204DB" // Maneuver Mastery
                )
                .AddEntry
                (9,
                "568C3AE8-9EF4-4505-A6C9-82D3635736B7", // Bonus Maneuver Feat 9
                "7C8B00CA-69D9-4F14-957B-1D9542A204DB" // Maneuver Mastery
                )
                .AddEntry
                (11,
                FeatureRefs.ImprovedEvasion.Reference.Get()
                )
                .AddEntry
                (10,
                "95F5A426-8B4D-4F1D-AE7E-0B0C8813CC5F" //Specialty Maneuver
                )
                .AddEntry
                (13,
                "568C3AE8-9EF4-4505-A6C9-82D3635736B7", // Bonus Maneuver Feat 9
                "7C8B00CA-69D9-4F14-957B-1D9542A204DB" // Maneuver Mastery
                )
                .AddEntry
                (17,
                "568C3AE8-9EF4-4505-A6C9-82D3635736B7", // Bonus Maneuver Feat 9
                "7C8B00CA-69D9-4F14-957B-1D9542A204DB" // Maneuver Mastery
                )
                .AddEntry
                (18,
                "95F5A426-8B4D-4F1D-AE7E-0B0C8813CC5F" //Specialty Maneuver
                )
                ;

            ProgressionConfigurator.New(ProgressionName, ProgressionGuid)
                //.SetClasses("08636672-3547-4DC5-AE9B-BAA8DCF4164B")
                .AddToClasses("08636672-3547-4DC5-AE9B-BAA8DCF4164B")
                .SetForAllOtherClasses(false)
                .SetIsClassFeature(true)
                //.SetRanks(1)
                .SetLevelEntries(entries)
                .AddToUIGroups("A735C5B7-6328-4442-A7F2-8F32D00ED6F8", "568C3AE8-9EF4-4505-A6C9-82D3635736B7")
                .Configure();
        }
          

    }
}
