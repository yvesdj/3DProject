using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Utils
    {
        public static Vector3 ChangeHeightFromVector3(Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }
    }
}
