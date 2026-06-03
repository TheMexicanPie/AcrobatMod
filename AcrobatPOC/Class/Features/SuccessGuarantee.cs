using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcrobatPOC.Class.Features
{
    internal class SuccessGuarantee
    {
        private static readonly string FeatureName = "SuccessGuarantee";
        private static readonly string FeatureGuid = "C92D6486-4DDF-47B6-8FAD-C13ECAC68C10";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, FeatureGuid)
                .SetDisplayName("SuccessGuarantee.Name")
                .SetDescription("SuccessGuarantee.Description")
                .Configure();
        }
    }
}
