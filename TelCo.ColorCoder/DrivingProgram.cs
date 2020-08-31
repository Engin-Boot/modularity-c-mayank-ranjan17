using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using TelCo.ColorCoder;

namespace TelCo.ColorCoder
{
    class DrivingProgram
    {
        public Color[] colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
        public Color[] colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };

        public override string ToString()
        {
            string colorCode = "";
            int i = 1;
            foreach (var majorColor in colorMapMajor)
            {
                foreach (var minorColor in colorMapMinor)
                {
                    colorCode += $"MajorColor:{majorColor}, MinorColor:{minorColor}, PairNumber:{i++}\n\n";
                }
            }
            return colorCode;
        }

        public ColorPair GetColorFromPairNumber(int pairNumber)
        {
            // The function supports only 1 based index. Pair numbers valid are from 1 to 25
            int minorSize = colorMapMinor.Length;
            int majorSize = colorMapMajor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }
            // Find index of major and minor color from pair number
            int zeroBasedPairNumber = pairNumber - 1;int majorIndex = zeroBasedPairNumber / minorSize;int minorIndex = zeroBasedPairNumber % minorSize;
            // Construct the return val from the arrays
            ColorPair pair = new ColorPair()
            {  majorColor = colorMapMajor[majorIndex],minorColor = colorMapMinor[minorIndex]
            };
            // return the value
            return pair;
        }
    }
}
