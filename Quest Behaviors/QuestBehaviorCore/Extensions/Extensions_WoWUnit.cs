﻿// Originally contributed by Chinajade.
//
// LICENSE:
// This work is licensed under the
//     Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License.
// also known as CC-BY-NC-SA.  To view a copy of this license, visit
//      http://creativecommons.org/licenses/by-nc-sa/3.0/
// or send a letter to
//      Creative Commons // 171 Second Street, Suite 300 // San Francisco, California, 94105, USA.

#region Usings

using System.Linq;

using Styx.WoWInternals.WoWObjects;
#endregion


namespace Honorbuddy.QuestBehaviorCore
{
    public static class Extensions_WoWUnit
    {
        /// <summary>
        /// Similar to WoWUnit.Mounted, but also tests for auras that provide a 'mounted' characteristic.
        /// <para>Notes:<list type="bullet">
        /// <item><description><para> * The following auras count as 'mounted' auras:
        /// Druid(Flight Form), Druid(Swift Fight Form), Druid(Travel Form), Shaman(Ghost Wolf),
        /// Worgen(Running Wild).</para></description></item>
        /// </list></para>
        /// </summary>
        /// <param name="wowUnit"></param>
        /// <returns></returns>
        public static bool IsMounted(this WoWUnit wowUnit)
        {
            return (wowUnit.Mounted
                    || wowUnit.GetAllAuras().Any(a => s_mountedAuras.Contains(a.SpellId)));
        }
        private readonly static int[] s_mountedAuras =
            {
                165962,		// Druid: Flight Form (Patch 6.0.2)
				33943,      // Druid: Flight Form
				40120,      // Druid: Swift Flight Form
				  783,      // Druid: Travel Form
				93326,      // Herbalist: Sandstone Drake
				 2645,      // Shaman: Ghost Wolf
				87840,      // Worgen: Running Wild
			};


        // 16Apr2013-10:34UTC chinajade
        public static bool IsShapeshifted(this WoWUnit wowUnit)
        {
            return wowUnit.GetAllAuras().Any(a => s_shapeshiftAuras.Contains(a.SpellId));
        }
        private readonly static int[] s_shapeshiftAuras =
            {
                 1066,      // Druid: Aquatic Form
				 5487,      // Druid: Bear Form
				  768,      // Druid: Cat Form
				165962,		// Druid: Flight Form (Patch 6.0.2)
				33943,      // Druid: Flight Form
				40120,      // Druid: Swift Flight Form
				  783,      // Druid: Travel Form       
				93326,      // Herbalist: Sandstone Drake
				 2645,      // Shaman: Ghost Wolf
				87840,      // Worgen: Running Wild
			};


        // 11Apr2013-07:48UTC chinajade
        public static bool IsUntagged(this WoWUnit wowUnit)
        {
            return (wowUnit != null)
                && (wowUnit.TappedByAllThreatLists
                    || wowUnit.TaggedByMe
                    || !wowUnit.TaggedByOther);
        }
    }
}
