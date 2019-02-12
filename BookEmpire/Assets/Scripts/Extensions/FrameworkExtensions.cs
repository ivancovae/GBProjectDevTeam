using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Games.Interface;

namespace Games
{
    public static partial class FrameworkExtensions
    {
        private static System.Random _r = new System.Random();

        public static void SetAlpha(this SpriteRenderer r, float alpha)
        {
            var c = r.color;
            r.color = new Color(c.r, c.g, c.b, alpha);
        }

        public static Color SetAlpha(this Color c, float alpha)
        {
            return new Color(c.r, c.g, c.b, alpha);
        }

        public static T Random<T>(this List<T> list)
        {
            var val = list[UnityEngine.Random.Range(0, list.Count)];
            return val;
        }

        public static T RandomByChance<T>(this List<T> vals) where T : IRandom
        {
            var total = 0f;

            var probs = new float[vals.Count];

            for (var i = 0; i < probs.Length; i++)
            {
                probs[i] = vals[i].returnChance;
                total += probs[i]; 
            }

            var randomPoint = (float) _r.NextDouble() * total;

            for (var i = 0; i < probs.Length; i++)
            {
                if (randomPoint < probs[i])
                    return vals[i];
                randomPoint -= probs[i];
            }
            return vals[0];
        }

        public static Vector3 Center(this Transform[] points)
        {
            Vector3 finalPos = Vector3.zero;
            for (var i = 0; i < points.Length; i++)
            {
                finalPos += points[i].position;
            }
            finalPos /= points.Length;
            return finalPos;
        }

        public static Transform FindDeep(this Transform obj, string id)
		{
			if (obj.name == id)
			{
				return obj;
			}

			int count = obj.childCount;
			for (int i = 0; i < count; ++i)
			{
				var posObj = obj.GetChild(i).FindDeep(id);
				if (posObj != null)
				{
					return posObj;
				}
			}

			return null;
}
    }
}