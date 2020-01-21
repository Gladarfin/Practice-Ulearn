using System.Collections.Generic;
using GeometryTasks;
using System.Drawing;

namespace GeometryPainting
{
    public static class SegmentExtensions
    {
        public static Dictionary<Segment, Color> SegmentsColor = new Dictionary<Segment, Color>();

        public static void SetColor(this Segment segment, Color newColor)
        {
            SegmentsColor[segment] = newColor;
        }

        public static Color GetColor(this Segment segment)
        {
            if (SegmentsColor.ContainsKey(segment))
                return SegmentsColor[segment];
            return Color.Black;
        }
    }
}
