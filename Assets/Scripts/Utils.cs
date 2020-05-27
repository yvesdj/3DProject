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
        public static Vector3 ChangeYFromVector3(Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }

        //public static Quaternion ChangeXFromRotation(Vector3 v, float x)
        //{
        //    return new Quaternion(x, v.y, v.z);
        //}
    }
}
