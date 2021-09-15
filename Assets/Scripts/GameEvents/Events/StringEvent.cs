using UnityEngine;

namespace GameSystem.Events
{
    [CreateAssetMenu(fileName = "New StringEvent", menuName = "GameEvents/String Event")]
    public class StringEvent : BaseGameEvent<string>
    {
    }
}