using UnityEngine;

namespace GameSystem.Events
{
    [CreateAssetMenu(fileName = "New VoidEvent", menuName = "GameEvents/Void Event")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}