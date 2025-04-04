using MelonLoader;
using UnityEngine;
using Il2CppScheduleOne.Casino.UI;

namespace Nopjo
{
    public class BlackjackInterfaceMonitor
    {
        private BlackjackInterface currentBlackjackInterface = null;

        public System.Collections.IEnumerator MonitorBlackjackInterface()
        {
            while (true)
            {
                yield return new WaitForSeconds(2.0f);

                try
                {
                    var interfaces = Object.FindObjectsOfType<BlackjackInterface>();
                    if (interfaces != null && interfaces.Length > 0)
                    {
                        currentBlackjackInterface = interfaces[0];
                    }
                    else
                    {
                        currentBlackjackInterface = null;
                    }
                }
                catch (System.Exception ex)
                {
                    MelonLogger.Error($"Error finding BlackjackInterface: {ex.Message}");
                }
            }
        }

        public BlackjackInterface GetCurrentBlackjackInterface()
        {
            return currentBlackjackInterface;
        }
    }
}