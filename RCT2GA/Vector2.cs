using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA
{
    class Vector2
    {
        //TODO
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public void RotateBy(int angle)
        {
            if (angle == 0)
            {
                return;
            }

            float theta = (float)(angle * Math.PI / 180.0f);

            float x = (float)(X * Math.Cos(theta) - Y * Math.Sin(theta));
            float y = (float)(X * Math.Sin(theta) - Y * Math.Cos(theta));

            X = x;
            Y = y;
        }
    }
}
