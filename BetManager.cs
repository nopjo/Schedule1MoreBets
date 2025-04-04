using MelonLoader;
using System.Reflection;
using Il2CppScheduleOne.Casino.UI;

namespace Nopjo
{
    public class BetManager
    {
        private readonly int[] betAmounts = new int[] { 100, 200, 500, 1000, 2000, 5000, 10000, 25000 };
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