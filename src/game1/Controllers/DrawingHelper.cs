using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game1.Controllers
{
    public class DrawingHelper
    {
        public static string randomEye = @"-|@!~^+'o0O⊙";
        public static string randomMouth = @"_x*oO~DVv";
        public static string randomHair = randomEye + randomMouth;
        public static List<StringBuilder> Draw(int FaceCount)
        {
            int RowWidth = 21;
            int hairWidth = 15;
            
            string leftEar = "(";
            string rightEar = ")";
            string leftFace = "|";
            string nose = "*";

            var faces = new List<StringBuilder>();
            
            for (int t = 1; t <= FaceCount; t++)
            {
                StringBuilder sb = new StringBuilder();
                string eye = GetRandomPart(randomEye, 1);
                string mouth = GetRandomPart(randomMouth, 1);
                string hairStyle = GetRandomPart(randomHair, 1);
                DrawHair(RowWidth, hairWidth, hairStyle,sb);
                DrawCartoon(leftEar, rightEar, leftFace, eye, nose, mouth,sb);
                sb.Append("\n");
                faces.Add(sb);
            }
            return faces;
            
        }

        private static void DrawHair(int RowWidth, int hairWidth, string hairStyle,StringBuilder sb)
        {
            StringBuilder hair = new StringBuilder();
            for (int i = 1; i <= hairWidth - 2; i++)
            {
                hair.Append(hairStyle);
            }
            sb.AppendLine((" " + hair + " ").PadLeft((RowWidth - hairWidth) / 2 + hairWidth, ' '));
            sb.AppendLine(("|" + hair + "|").PadLeft((RowWidth - hairWidth) / 2 + hairWidth, ' '));
        }
        public static string GetRandomPart(string pwdchars, int pwdlen)
        {
            
            string tmpstr = "";
            int iRandNum;
            Thread.Sleep(100);
            long tick = DateTime.Now.Ticks;
            Random rnd = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            for (int i = 0; i < pwdlen; i++)
            {
                iRandNum = rnd.Next(pwdchars.Length);
                tmpstr += pwdchars[iRandNum];
            }
            return tmpstr;
        }
        private static void DrawCartoon(string leftEar, string rightEar, string leftFace, string eye, string nose, string mouth, StringBuilder sb)
        {
            //Print left
            PrintLeftParts(leftEar, 3,sb);
            PrintLeftParts(leftFace, 0,sb);
            PrintLeftParts(eye, 2,sb);
            PrintLeftParts(nose, 2,sb);
            //Pring right
            PrintLeftParts(eye, 2, sb);
            PrintLeftParts(leftFace, 2,sb);
            PrintLeftParts(rightEar, 0,sb);
            //Print down face
            sb.AppendLine();
            PrintLeftParts(leftFace, 4,sb);
            PrintLeftParts(mouth, 5,sb,'_');
            PrintLeftParts(leftFace, 5, sb,'_');
            sb.AppendLine();
            sb.AppendLine();

        }

        static void PrintLeftParts(string organName, int leftPad, StringBuilder sb,char paddingchar = ' ')
        {
            for( int i=0; i < leftPad; i++)
            {
                sb.Append(paddingchar);
            }
            sb.Append(organName);
        }
    }
}
