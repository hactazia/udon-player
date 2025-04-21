using Hactazia.UdonList;
using UdonSharp;
using VRC.SDKBase;

namespace Hactazia.UdonPlayer
{
    public class TriggerEmitter : UdonSharpBehaviour
    {
        private int[] _players;
        private TriggerReceiver[] _receivers;

        public void AddListener(TriggerReceiver receiver)
        {
            _receivers = _receivers.AddIfNotExists(receiver);
        }

        public void RemoveListener(TriggerReceiver receiver)
        {
            _receivers = _receivers.RemoveMany(receiver);
        }

        public VRCPlayerApi[] GetPlayers()
        {
            var li = ListExtensions.New<VRCPlayerApi>();
            foreach (var id in _players.Safe())
                li = li.AddIfNotExists(VRCPlayerApi.GetPlayerById(id));
            return li;
        }

        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            _players = _players.AddIfNotExists(player.playerId);
            foreach (var receiver in _receivers.Safe())
                receiver.OnPlayerEnter(player);
        }

        public override void OnPlayerTriggerExit(VRCPlayerApi player)
        {
            _players = _players.RemoveMany(player.playerId);
            foreach (var receiver in _receivers.Safe())
                receiver.OnPlayerExit(player);
        }

        public override void OnPlayerTriggerStay(VRCPlayerApi player)
        {
            _players = _players.AddIfNotExists(player.playerId);
            foreach (var receiver in _receivers.Safe())
                receiver.OnPlayerStay(player);
        }
    }
}