using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NutraBob {
    public class CompProperties_InheritRenameable : CompProperties {
        public CompProperties_InheritRenameable() : base(typeof(CompInheritRenameable)) {}

        public ThingDef inheritFrom = null;
    }
}
