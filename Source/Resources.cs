using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace NutraBob {
    public static class Resources {
        public const string Path = Strings.ID + "/";

        public static readonly Texture2D RenameIcon =
            ContentFinder<Texture2D>.Get(Path + "RenameIcon");
    }
}
