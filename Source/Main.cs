using HarmonyLib;
using Verse;
using RimWorld;

namespace NutraBob
{
    [StaticConstructorOnStartup]
    public static class Main
    {
        static Main()
        {
            var harmony = new Harmony(Strings.ID);
            harmony.PatchAll();
        }
    }
}
