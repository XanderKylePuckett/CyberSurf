﻿namespace Xander
{
    namespace Debugging
    {
        public static class LineNumbers
        {
            public static string GetPathHere(
                [System.Runtime.CompilerServices.CallerFilePath] string file = "",
                [System.Runtime.CompilerServices.CallerLineNumber] int line = 0) =>
                $"{file}:{line}";
        }
        public static class DebugExtensions
        {
            public static string HierarchyPath(this UnityEngine.GameObject pGobjGameObject)
            {
                string lStrRetVal = "";
                for (UnityEngine.Transform lTfmTransform = pGobjGameObject.transform; null != lTfmTransform; lTfmTransform = lTfmTransform.parent)
                    lStrRetVal = lTfmTransform.gameObject.name + '.' + lStrRetVal;
                return lStrRetVal.Substring(0, lStrRetVal.Length - 1);
            }
            public static string Info<T>(this T comp) where T : UnityEngine.Component =>
                $" ({comp.gameObject.HierarchyPath()})[{comp.gameObject.GetInstanceID()}]::({comp.GetType().FullName})[{comp.GetInstanceID()}].";
        }
        public static class Helper
        {
            public static string TimeStamp => System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
            public static string DozenalTimeStamp => Dozenal.DozenalStrings.Dozenal(System.DateTime.Now);
        }
    }
    namespace Dozenal
    {
        public static class DozenalStrings
        {
            private const string cstStrDozDig = "0123456789XE";
            public static string Dozenal(this ulong i)
            {
                if (0ul == i)
                    return "0";
                string rv = "";
                while (0ul != i)
                {
                    rv = cstStrDozDig[(int)(i % 12ul)] + rv;
                    i /= 12ul;
                }
                return rv;
            }
            public static string Dozenal(this int i)
            {
                if (i < 0)
                    return "-" + Dozenal((ulong)(-i));
                return Dozenal((ulong)i);
            }
            public static string Dozenal(this System.DateTime time) =>
                string.Concat(time.Year.Dozenal().PadLeft(4, '0'), (time.Month - 1).Dozenal().PadLeft(1, '0'),
                    (time.Day - 1).Dozenal().PadLeft(2, '0'), time.Hour.Dozenal().PadLeft(2, '0'),
                    time.Minute.Dozenal().PadLeft(2, '0'), time.Second.Dozenal().PadLeft(2, '0'),
                    ((int)System.Math.Round(1.728 * time.Millisecond)).Dozenal().PadLeft(3, '0'));
        }
    }
    namespace NullConversion
    {
        public static class NullConverter
        {
            public static T ConvertNull<T>(this T obj) where T : UnityEngine.Object
            { if (null != obj) return obj; return null; }
            public static T GetNullConvertedComponent<T>(this UnityEngine.Component obj)
                where T : UnityEngine.Component => obj.GetComponent<T>().ConvertNull();
            public static T GetNullConvertedComponent<T>(this UnityEngine.GameObject obj)
                where T : UnityEngine.Component => obj.GetComponent<T>().ConvertNull();
            public static T GetNullConvertedComponentInChildren<T>(this UnityEngine.Component obj)
                where T : UnityEngine.Component => obj.GetComponentInChildren<T>().ConvertNull();
            public static T GetNullConvertedComponentInChildren<T>(this UnityEngine.GameObject obj)
                where T : UnityEngine.Component => obj.GetComponentInChildren<T>().ConvertNull();
            public static T GetNullConvertedComponentInParent<T>(this UnityEngine.Component obj)
                where T : UnityEngine.Component => obj.GetComponentInParent<T>().ConvertNull();
            public static T GetNullConvertedComponentInParent<T>(this UnityEngine.GameObject obj)
                where T : UnityEngine.Component => obj.GetComponentInParent<T>().ConvertNull();
        }
    }
    namespace BoolConversion
    {
        public static class BoolConverter
        {
            public static sbyte Sbyte(this bool obj) => (obj ? (sbyte)1 : (sbyte)0);
            public static byte Byte(this bool obj) => (obj ? (byte)1 : (byte)0);
            public static short Short(this bool obj) => (obj ? (short)1 : (short)0);
            public static ushort Ushort(this bool obj) => (obj ? (ushort)1 : (ushort)0);
            public static int Int(this bool obj) => (obj ? 1 : 0);
            public static uint Uint(this bool obj) => (obj ? 1u : 0u);
            public static long Long(this bool obj) => (obj ? 1L : 0L);
            public static ulong Ulong(this bool obj) => (obj ? 1ul : 0ul);
            public static char Char(this bool obj) => (obj ? '\x0001' : '\0');
            public static decimal Decimal(this bool obj) => (obj ? 1.0m : 0.0m);
            public static float Float(this bool obj) => (obj ? 1.0f : 0.0f);
            public static double Double(this bool obj) => (obj ? 1.0 : 0.0);
            public static bool Bool(this bool obj) => obj;
            public static bool Bool(this object obj) => (null != obj);
            public static bool Bool(this sbyte obj) => (0 != obj);
            public static bool Bool(this byte obj) => (0u != obj);
            public static bool Bool(this short obj) => (0 != obj);
            public static bool Bool(this ushort obj) => (0u != obj);
            public static bool Bool(this int obj) => (0 != obj);
            public static bool Bool(this uint obj) => (0u != obj);
            public static bool Bool(this long obj) => (0L != obj);
            public static bool Bool(this ulong obj) => (0ul != obj);
            public static bool Bool(this char obj) => ('\0' != obj);
            public static bool Bool(this decimal obj) => (0.0m != obj);
            public static bool Bool(this float obj) => (0.0f != obj);
            public static bool Bool(this double obj) => (0.0 != obj);
        }
    }
}
public class LabelOverrideAttribute : UnityEngine.PropertyAttribute
{
    public string mStrLabel = null;
    public LabelOverrideAttribute(string pStrLabel) { mStrLabel = pStrLabel; }
#if UNITY_EDITOR
    [UnityEditor.CustomPropertyDrawer(typeof(LabelOverrideAttribute))]
    public class ThisPropertyDrawer : UnityEditor.PropertyDrawer
    {
        public override void OnGUI(UnityEngine.Rect pSctPosRect, UnityEditor.SerializedProperty pClProp, UnityEngine.GUIContent pClLabel)
        {
            pClLabel.text = ((LabelOverrideAttribute)attribute).mStrLabel ?? pClLabel.text;
            UnityEditor.EditorGUI.PropertyField(pSctPosRect, pClProp, pClLabel);
        }
    }
#endif
}
#if UNITY_EDITOR
namespace Xander.Steam
{
    [UnityEditor.InitializeOnLoad]
    public class SteamAppId
    {
        public const int cstIntSteamAppId = 735810;
        static SteamAppId()
        {
            System.IO.StreamWriter lSwSteamAppIdFile = new System.IO.StreamWriter(UnityEngine.Application.dataPath + "/../steam_appid.txt", false);
            lSwSteamAppIdFile.Write(cstIntSteamAppId);
            lSwSteamAppIdFile.Close();
        }
    }
}
#endif