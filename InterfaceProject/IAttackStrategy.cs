using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assembly_CSharp
{
    public interface IAttackStrategy
    {
        void Attack(GameObject target);
    }
}
