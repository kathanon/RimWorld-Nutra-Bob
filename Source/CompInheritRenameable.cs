using NutraBob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NutraBob {
    public class CompInheritRenameable : ThingComp {
        public CompProperties_InheritRenameable Props => 
            (CompProperties_InheritRenameable) props;

        public override string TransformLabel(string orig) {
            var map = parent.Map;
            var adj = GenAdj.CellsAdjacentCardinal(parent)
                .Where(p => p.InBounds(map))
                .Select(p => p.GetEdifice(map)?.GetComp<CompRenameable>())
                .Where(c => c != null && c.HasLabel);
            if (Props.inheritFrom != null) {
                adj = adj.Where(c => c.parent.def == Props.inheritFrom);
            }
            string label = null;
            foreach (var comp in adj) {
                if (label == null) {
                    label = $"{comp.Label} ({orig})";
                } else { // several adjacent buildings are applicable
                    return orig;
                }
            }
            return label ?? orig;
        }
    }
}
