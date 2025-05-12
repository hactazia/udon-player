using Hactazia.Types;
using TMPro;
using VRC.SDKBase;

namespace Hactazia.UdonPlayer.Example
{
    public class PlayerList : TriggerReceiver
    {
        public TextMeshProUGUI text;

        private void UpdateList()
        {
            var text = "";
            var players = source
                ? source.GetPlayers()
                : ListExtensions.New<VRCPlayerApi>();

            for (var i = 0; i < players.Length; i++)
            {
                var p = players[i];
                if (p == null) continue;
                if (i > 0) text += "\n";
                text += $"{p.displayName}";
            }
            
            if (this.text && this.text.text != text)
                this.text.text = text;
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