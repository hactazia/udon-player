using Hactazia.UdonList;
using TMPro;
using VRC.SDKBase;

namespace Hactazia.UdonPlayer.Example
{
    public class PlayerList : TriggerReceiver
    {
        public TextMeshProUGUI text;
        
        private void UpdateList()
        {
            text.text = "";
            var players = source
                ? source.GetPlayers()
                : ListExtensions.New<VRCPlayerApi>();
            for (var i = 0; i < players.Length; i++)
            {
                var p = players[i];
                if (p == null) continue;
                if (i > 0) text.text += "\n";
                text.text += $"{p.displayName}";
            }
        }

        public override void OnPlayerEnter(VRCPlayerApi player)
        {
            UpdateList();
        }

        public override void OnPlayerExit(VRCPlayerApi player)
        {
            UpdateList();
        }

        public override void OnPlayerStay(VRCPlayerApi player)
        {
            UpdateList();
        }
    }
}