using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NutraBob {
    public static class Extensions {
        public static void OpenMenu(this List<FloatMenuOption> menu) => Find.WindowStack.Add(new FloatMenu(menu));
    }
}
