using System;
using UnityEngine;

namespace _Demo
{
    [Serializable]
    public class Statistic
    {
        [SerializeField]
        public StatisticRecipe Stat {  get; private set; }
        [SerializeField]
        public float Value;
    }
}

