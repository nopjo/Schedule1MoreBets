using MelonLoader;
using System.Reflection;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace Nopjo
{
    public static class SlotMachineModifier
    {
        private static readonly int[] betAmounts = new int[] { 100, 200, 500, 1000, 2000, 5000, 10000, 25000 };

        public static System.Collections.IEnumerator ModifySlotMachineBets()
        {
            yield return null;
            yield return null;
            yield return null;

            try
            {
                var slotMachineType = typeof(Il2CppScheduleOne.Casino.SlotMachine);
                var betAmountsProperty = slotMachineType.GetProperty("BetAmounts", BindingFlags.Public | BindingFlags.Static);

                if (betAmountsProperty != null)
                {
                    MelonLogger.Msg("Found BetAmounts property, attempting to modify...");
                    var currentValue = betAmountsProperty.GetValue(null);

                    if (currentValue != null)
                    {
                        var newBetAmounts = new Il2CppStructArray<int>(betAmounts.Length);
                        for (int i = 0; i < betAmounts.Length; i++)
                        {
                            newBetAmounts[i] = betAmounts[i];
                        }

                        betAmountsProperty.SetValue(null, newBetAmounts);
                        MelonLogger.Msg("Successfully modified Slot Machine BetAmounts property");

                        var verifyValue = betAmountsProperty.GetValue(null);
                        if (verifyValue is Il2CppStructArray<int> verifyArray)
                        {
                            string values = string.Join(", ", verifyArray);
                            MelonLogger.Msg($"New Slot Machine BetAmounts: [{values}]");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying Slot Machine BetAmounts: {ex.Message}");
            }
        }
    }
}