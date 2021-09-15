using UnityEngine;

namespace GameSystem.Events
{
    [CreateAssetMenu(fileName = "New GameObjectEvent", menuName = "GameEvents/GameObject Event")]
    public class GameObjectEvent : BaseGameEvent<GameObject>
    {
    }
}