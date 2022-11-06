using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace NutraBob {
    public class RenameGizmo : Command {
        private readonly List<CompRenameable> comps = new List<CompRenameable>();

        public RenameGizmo(CompRenameable comp) {
            comps.Add(comp);
            icon = Resources.RenameIcon;
            defaultLabel = "Rename";
            defaultDesc = $"Rename this {comp.parent.def.label}.";
            hotKey = KeyBindingDefOf.Misc2;
        }

        public override void MergeWith(Gizmo other) {
            if (other is RenameGizmo o) {
                comps.AddRange(o.comps);
                o.comps.Clear();
                defaultDesc = "Rename selected things.";
            }
        }

        private IEnumerable<string> AllNames => comps.Select(c => c.Label).Distinct();

        private IEnumerable<string> AllSetNames => AllNames.Where(n => n != null);

        private bool UseMenu => AllNames.Count() > 1;

        public override void ProcessInput(Event ev) {
            if (comps.Count == 0) return;
            if (ev.button == 1 && UseMenu) {
                var opts = AllSetNames.Select(n => new FloatMenuOption(n, () => SetName(n))).ToList();
                opts.Add(new FloatMenuOption("New name...", OpenDialog));
                opts.OpenMenu();
            } else {
                OpenDialog();
            }
            base.ProcessInput(ev);
        }

        private void OpenDialog() => new Dialog_RenameThing(comps, KeyBindingDefOf.Misc2.IsDown).Open();

        private void SetName(string name) {
            foreach (var comp in comps) {
                comp.Label = name;
            }
        }
    }
}
