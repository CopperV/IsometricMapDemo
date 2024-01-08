using UnityEngine;

namespace _Demo
{
    [CreateAssetMenu(fileName = "New Statistic", menuName = "IMD/Statistic")]
    public class StatisticRecipe : ScriptableObject
    {
        public string Id { get; private set; }
        public string Display { get; private set; }
        public float Value { get; private set; }
    }
}
