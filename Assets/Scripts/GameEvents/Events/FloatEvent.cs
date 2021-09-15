using UnityEngine;

namespace GameSystem.Events
{
    [CreateAssetMenu(fileName = "New FloatTimerEvent", menuName = "GameEvents/Float Event")]
    public class FloatEvent : BaseGameEvent<float>, ISerializationCallbackReceiver
    {
        public float initialValue;
        [System.NonSerialized]
        public float RuntimeValue;

        public void OnAfterDeserialize()
        {
            RuntimeValue = initialValue;
        }

        public void OnBeforeSerialize() { }
    }
}