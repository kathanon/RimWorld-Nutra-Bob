using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NutraBob {
    public class Dialog_RenameThing : Dialog_Rename {
        private readonly List<CompRenameable> comps;

        public Dialog_RenameThing(List<CompRenameable> comps, bool openedByHotkey) {
            this.comps = comps;
            if (comps.TrueForAll(c => c.Label == comps[0].Label)) curName = comps[0].Label;
            if (openedByHotkey) WasOpenedByHotkey();
        }

        public void Open() => Find.WindowStack.Add(this);

        protected override int MaxNameLength => comps.Min(c => c.Props.maxLength);

        protected override AcceptanceReport NameIsValid(string name) => true;

        protected override void SetName(string name) {
            foreach (var comp in comps) {
                comp.Label = name;
            }
        }
    }
}
