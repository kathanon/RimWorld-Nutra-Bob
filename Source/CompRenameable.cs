using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace NutraBob {
    public class CompRenameable : ThingComp {
        public CompProperties_Renameable Props => (CompProperties_Renameable) props;

        public string Label = null;
        
        public bool HasLabel => !Label.NullOrEmpty();

        public override string TransformLabel(string orig) => HasLabel ? $"{Label} ({orig})" : orig;

        public override IEnumerable<Gizmo> CompGetGizmosExtra() {
            yield return new RenameGizmo(this);
        }

        public override void PostExposeData() {
            Scribe_Values.Look(ref Label, "label");
        }
    }
}
