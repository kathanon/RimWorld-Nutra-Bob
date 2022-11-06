using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NutraBob {
    public class CompProperties_Renameable : CompProperties {
        public CompProperties_Renameable() : base(typeof(CompRenameable)) {}

        public int maxLength = 28;

    }
}
