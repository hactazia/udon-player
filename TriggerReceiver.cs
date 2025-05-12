using UdonSharp;
using VRC.SDKBase;

namespace Hactazia.UdonPlayer
{
    public class TriggerReceiver : UdonSharpBehaviour
    {
        public TriggerEmitter source;
        
        private void Start()
        {
            if (!source) return;
            source.AddListener(this);
        }

        private void OnDestroy()
        {
            if (!source) return;
            source.RemoveListener(this);
        }

        public virtual void OnPlayerEnter(VRCPlayerApi player)
        {
        }

        public virtual void OnPlayerExit(VRCPlayerApi player)
        {
        }

        public virtual void OnPlayerStay(VRCPlayerApi player)
        {
        }
    }
}