using UnityEngine;

namespace _Demo
{
    [CreateAssetMenu(fileName = "New Statistic", menuName = "IMD/Statistic")]
    public class StatisticRecipe : ScriptableObject
    {
        public string Id;
        public string Display;
        public float Value;

        /*
         Variables Min and Max have been added to easily generate random statistics
         */
        public float MinValue;
        public float MaxValue;
    }
}
