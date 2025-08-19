using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.InterSample
{
    public class NOIcolorchangeSample : MonoBehaviour
    {
        SpriteRenderer sr;
        CastedAttack CastedAttack;
        int damage;
        Text target;

        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            
        }
    }
}
