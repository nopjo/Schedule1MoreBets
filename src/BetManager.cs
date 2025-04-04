using MelonLoader;
using System.Reflection;
using Il2CppScheduleOne.Casino.UI;

namespace Nopjo
{
    public class BetManager
    {
        private readonly int[] betAmounts = new int[] { 10, 25, 50, 75, 100, 200, 300, 500, 750, 1000, 1500, 2000, 3000, 5000, 7500, 10000, 15000, 20000, 25000, 50000, 100000 };
        private int currentBetIndex = 0;

        public string GetBetAmountsString()
        {
            return string.Join(", ", betAmounts);
        }

        public void IncreaseBet(BlackjackInterface blackjackInterface)
        {
            currentBetIndex = (currentBetIndex + 1) % betAmounts.Length;
            ApplyBet(blackjackInterface);
        }

        public void DecreaseBet(BlackjackInterface blackjackInterface)
        {
            currentBetIndex = (currentBetIndex - 1 + betAmounts.Length) % betAmounts.Length;
            ApplyBet(blackjackInterface);
        }

        private void ApplyBet(BlackjackInterface blackjackInterface)
        {
            int selectedBet = betAmounts[currentBetIndex];
            blackjackInterface.CurrentGame.SetLocalPlayerBet(selectedBet);
            RefreshDisplayedBet(blackjackInterface);
            MelonLogger.Msg($"Set bet to {selectedBet}.");
        }

        private void RefreshDisplayedBet(BlackjackInterface blackjackInterface)
        {
            try
            {
                var refreshMethod = typeof(BlackjackInterface)
                    .GetMethod("RefreshDisplayedBet", BindingFlags.Instance | BindingFlags.NonPublic);
                if (refreshMethod != null)
                {
                    refreshMethod.Invoke(blackjackInterface, null);
                    MelonLogger.Msg("Refreshed bet display.");
                }
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error refreshing bet display: {ex.Message}");
            }
        }
    }
}