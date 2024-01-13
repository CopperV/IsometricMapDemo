using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Demo
{
    public interface ISelectable
    {
        public void Select(GameObject Target);
        public void Unselect(GameObject Target);
    }
}

