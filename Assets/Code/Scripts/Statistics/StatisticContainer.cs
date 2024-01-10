using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Demo
{
    [Serializable]
    public class StatisticContainer
    {
        [SerializeField]
        private List<Statistic> Statistics;

        public Statistic GetStatistic(string Id) => Statistics.Find(Stat => Stat.Stat.Id.Equals(Id));
    }
}

