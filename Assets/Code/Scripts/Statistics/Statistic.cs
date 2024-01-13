using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Demo
{
    [Serializable]
    public class Statistic
    {
        [SerializeField]
        public StatisticRecipe Stat;
        [SerializeField]
        public float Value;

        /*
         Additional method for generating random value
         */
        public void GenerateRandomValue()
        {
            float rand = Random.Range(Stat.MinValue, Stat.MaxValue);
            rand = (float)Math.Round(rand, 1);
            Value = rand;
        }
    }
}

