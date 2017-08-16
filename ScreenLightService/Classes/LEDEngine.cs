using System;
using System.Collections.Generic;
using sys = System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenLightService.Interfaces;
using local = ScreenLightService.Models;
using System.Collections.Concurrent;
using System.Threading;

namespace ScreenLightService.Classes
{
    public static class LedEngine
    {
        private static ConcurrentDictionary<local.Point, sys.Color> CoordsColorDictionary = new ConcurrentDictionary<local.Point, sys.Color>();

        public static void AddOrUpdate(local.Point point, sys.Color color)
        {
           CoordsColorDictionary.AddOrUpdate(point, color, (key, value) => value = color);
        }

        public static void Remove(local.Point point)
        {
            CoordsColorDictionary.TryRemove(point, out sys.Color color);
        }

        public static void RemoveAll()
        {
            CoordsColorDictionary.Clear();
        }

        public static sys.Color GetColor(local.Point point)
        {
            CoordsColorDictionary.TryGetValue(point, out sys.Color color);
            return color;
        }

        public static local.Point[] GetCoords()
        {
            var coords = new List<local.Point>();
            foreach(var pair in CoordsColorDictionary)
            {
                coords.Add(pair.Key);
            }
            return coords.ToArray();
        }
    }
}
