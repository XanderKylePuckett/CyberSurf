﻿using UnityEngine;
using static Xander.BoolConversion.BoolConverter;
public static class GameSettings
{
    #region BOOL
    public static bool SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key + "_BOOL", value.Int());
        return value;
    }
    public static bool GetBool(string key, bool defaultValue = false) => SetBool(key, PlayerPrefs.GetInt(key + "_BOOL", defaultValue.Int()).Bool());
    public static bool GetBool(string key, ref bool value) => value = GetBool(key, value);
    public static void ResetBool(string key)
    {
        key += "_BOOL";
        if (PlayerPrefs.HasKey(key)) PlayerPrefs.DeleteKey(key);
    }
    public static bool HasBool(string key) => PlayerPrefs.HasKey(key + "_BOOL");
    #endregion
    #region INT
    public static int SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key + "_INT", value);
        return value;
    }
    public static int GetInt(string key, int defaultValue = 0) => SetInt(key, PlayerPrefs.GetInt(key + "_INT", defaultValue));
    public static int GetInt(string key, ref int value) => value = GetInt(key, value);
    public static void ResetInt(string key)
    {
        key += "_INT";
        if (PlayerPrefs.HasKey(key)) PlayerPrefs.DeleteKey(key);
    }
    public static bool HasInt(string key) => PlayerPrefs.HasKey(key + "_INT");
    #endregion
    #region UINT
    public static uint SetUint(string key, uint value)
    {
        PlayerPrefs.SetInt(key + "_UINT", (int)value);
        return value;
    }
    public static uint GetUint(string key, uint defaultValue = 0u) => SetUint(key, (uint)PlayerPrefs.GetInt(key + "_UINT", (int)defaultValue));
    public static uint GetUint(string key, ref uint value) => value = GetUint(key, value);
    public static void ResetUint(string key)
    {
        key += "_UINT";
        if (PlayerPrefs.HasKey(key)) PlayerPrefs.DeleteKey(key);
    }
    public static bool HasUint(string key) => PlayerPrefs.HasKey(key + "_UINT");
    #endregion
    #region FLOAT
    public static float SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key + "_FLOAT", value);
        return value;
    }
    public static float GetFloat(string key, float defaultValue = 0.0f) => SetFloat(key, PlayerPrefs.GetFloat(key + "_FLOAT", defaultValue));
    public static float GetFloat(string key, ref float value) => value = GetFloat(key, value);
    public static void ResetFloat(string key)
    {
        key += "_FLOAT";
        if (PlayerPrefs.HasKey(key)) PlayerPrefs.DeleteKey(key);
    }
    public static bool HasFloat(string key) => PlayerPrefs.HasKey(key + "_FLOAT");
    #endregion
    #region STRING
    public static string SetString(string key, string value)
    {
        PlayerPrefs.SetString(key + "_STRING", value);
        return value;
    }
    public static string GetString(string key, string defaultValue = "") => SetString(key, PlayerPrefs.GetString(key + "_STRING", defaultValue));
    public static string GetString(string key, ref string value) => value = GetString(key, value);
    public static void ResetString(string key)
    {
        key += "_STRING";
        if (PlayerPrefs.HasKey(key)) PlayerPrefs.DeleteKey(key);
    }
    public static bool HasString(string key) => PlayerPrefs.HasKey(key + "_STRING");
    #endregion
    #region CHAR
    public static char SetChar(string key, char value)
    {
        PlayerPrefs.SetInt(key + "_CHAR", value);
        return value;
    }
    public static char GetChar(string key, char defaultValue = '\0') => SetChar(key, (char)PlayerPrefs.GetInt(key + "_CHAR", defaultValue));
    public static char GetChar(string key, ref char value) => value = GetChar(key, value);
    public static void ResetChar(string key)
    {
        key += "_CHAR";
        if (PlayerPrefs.HasKey(key)) PlayerPrefs.DeleteKey(key);
    }
    public static bool HasChar(string key) => PlayerPrefs.HasKey(key + "_CHAR");
    #endregion
    #region COLOR
    public static Color SetColor(string key, Color value)
    {
        key += "_COLOR_";
        PlayerPrefs.SetFloat(key + 'R', value.r);
        PlayerPrefs.SetFloat(key + 'G', value.g);
        PlayerPrefs.SetFloat(key + 'B', value.b);
        PlayerPrefs.SetFloat(key + 'A', value.a);
        return value;
    }
    public static Color GetColor(string key, Color defaultValue)
    {
        Color ret;
        ret.r = PlayerPrefs.GetFloat(key + "_COLOR_R", defaultValue.r);
        ret.g = PlayerPrefs.GetFloat(key + "_COLOR_G", defaultValue.g);
        ret.b = PlayerPrefs.GetFloat(key + "_COLOR_B", defaultValue.b);
        ret.a = PlayerPrefs.GetFloat(key + "_COLOR_A", defaultValue.a);
        return SetColor(key, ret);
    }
    public static Color GetColor(string key) => GetColor(key, Color.clear);
    public static Color GetColor(string key, ref Color value) => value = GetColor(key, value);
    public static void ResetColor(string key)
    {
        key += "_COLOR_";
        if (PlayerPrefs.HasKey(key + 'R')) PlayerPrefs.DeleteKey(key + 'R');
        if (PlayerPrefs.HasKey(key + 'G')) PlayerPrefs.DeleteKey(key + 'G');
        if (PlayerPrefs.HasKey(key + 'B')) PlayerPrefs.DeleteKey(key + 'B');
        if (PlayerPrefs.HasKey(key + 'A')) PlayerPrefs.DeleteKey(key + 'A');
    }
    public static bool HasColor(string key)
    {
        key += "_COLOR_";
        return
            PlayerPrefs.HasKey(key + 'R') &&
            PlayerPrefs.HasKey(key + 'G') &&
            PlayerPrefs.HasKey(key + 'B') &&
            PlayerPrefs.HasKey(key + 'A');
    }
    #endregion
    #region ENUM
    public static T SetEnum<T>(string key, T value) where T : struct, System.IFormattable, System.IConvertible, System.IComparable
    {
        if (!typeof(T).IsEnum) throw new System.ArgumentException(typeof(T).ToString() + " is not an enum");
        PlayerPrefs.SetInt(key + "_ENUM_" + typeof(T).ToString().ToUpper(), System.Convert.ToInt32(value));
        return value;
    }
    public static T GetEnum<T>(string key, T defaultValue) where T : struct, System.IFormattable, System.IConvertible, System.IComparable
    {
        if (!typeof(T).IsEnum) throw new System.ArgumentException(typeof(T).ToString() + " is not an enum");
        return SetEnum(key, (T)(object)PlayerPrefs.GetInt(key + "_ENUM_" + typeof(T).ToString().ToUpper(), System.Convert.ToInt32(defaultValue)));
    }
    public static T GetEnum<T>(string key) where T : struct, System.IFormattable, System.IConvertible, System.IComparable
    {
        if (!typeof(T).IsEnum) throw new System.ArgumentException(typeof(T).ToString() + " is not an enum");
        return SetEnum(key, (T)(object)PlayerPrefs.GetInt(key + "_ENUM_" + typeof(T).ToString().ToUpper(), 0));
    }
    public static T GetEnum<T>(string key, ref T value) where T : struct, System.IFormattable, System.IConvertible, System.IComparable
    {
        if (!typeof(T).IsEnum) throw new System.ArgumentException(typeof(T).ToString() + " is not an enum");
        return value = GetEnum(key, value);
    }
    public static void ResetEnum<T>(string key) where T : struct, System.IFormattable, System.IConvertible, System.IComparable
    {
        if (!typeof(T).IsEnum) throw new System.ArgumentException(typeof(T).ToString() + " is not an enum");
        key += "_ENUM_" + typeof(T).ToString().ToUpper();
        if (PlayerPrefs.HasKey(key)) PlayerPrefs.DeleteKey(key);
    }
    public static bool HasEnum<T>(string key) where T : struct, System.IFormattable, System.IConvertible, System.IComparable
    {
        if (!typeof(T).IsEnum) throw new System.ArgumentException(typeof(T).ToString() + " is not an enum");
        return PlayerPrefs.HasKey(key + "_ENUM_" + typeof(T).ToString().ToUpper());
    }
    #endregion
    #region VECTOR4
    public static Vector4 SetVector4(string key, Vector4 value)
    {
        key += "_VECTOR4_";
        PlayerPrefs.SetFloat(key + 'X', value.x);
        PlayerPrefs.SetFloat(key + 'Y', value.y);
        PlayerPrefs.SetFloat(key + 'Z', value.z);
        PlayerPrefs.SetFloat(key + 'W', value.w);
        return value;
    }
    public static Vector4 GetVector4(string key, Vector4 defaultValue)
    {
        Vector4 ret;
        ret.x = PlayerPrefs.GetFloat(key + "_VECTOR4_X", defaultValue.x);
        ret.y = PlayerPrefs.GetFloat(key + "_VECTOR4_Y", defaultValue.y);
        ret.z = PlayerPrefs.GetFloat(key + "_VECTOR4_Z", defaultValue.z);
        ret.w = PlayerPrefs.GetFloat(key + "_VECTOR4_W", defaultValue.w);
        return SetVector4(key, ret);
    }
    public static Vector4 GetVector4(string key) => GetVector4(key, Vector4.zero);
    public static Vector4 GetVector4(string key, ref Vector4 value) => value = GetVector4(key, value);
    public static void ResetVector4(string key)
    {
        key += "_VECTOR4_";
        if (PlayerPrefs.HasKey(key + 'X')) PlayerPrefs.DeleteKey(key + 'X');
        if (PlayerPrefs.HasKey(key + 'Y')) PlayerPrefs.DeleteKey(key + 'Y');
        if (PlayerPrefs.HasKey(key + 'Z')) PlayerPrefs.DeleteKey(key + 'Z');
        if (PlayerPrefs.HasKey(key + 'W')) PlayerPrefs.DeleteKey(key + 'W');
    }
    public static bool HasVector4(string key)
    {
        key += "_VECTOR4_";
        return
            PlayerPrefs.HasKey(key + 'X') &&
            PlayerPrefs.HasKey(key + 'Y') &&
            PlayerPrefs.HasKey(key + 'Z') &&
            PlayerPrefs.HasKey(key + 'W');
    }
    #endregion
    #region VECTOR3
    public static Vector3 SetVector3(string key, Vector3 value)
    {
        key += "_VECTOR3_";
        PlayerPrefs.SetFloat(key + 'X', value.x);
        PlayerPrefs.SetFloat(key + 'Y', value.y);
        PlayerPrefs.SetFloat(key + 'Z', value.z);
        return value;
    }
    public static Vector3 GetVector3(string key, Vector3 defaultValue)
    {
        Vector3 ret;
        ret.x = PlayerPrefs.GetFloat(key + "_VECTOR3_X", defaultValue.x);
        ret.y = PlayerPrefs.GetFloat(key + "_VECTOR3_Y", defaultValue.y);
        ret.z = PlayerPrefs.GetFloat(key + "_VECTOR3_Z", defaultValue.z);
        return SetVector3(key, ret);
    }
    public static Vector3 GetVector3(string key) => GetVector3(key, Vector3.zero);
    public static Vector3 GetVector3(string key, ref Vector3 value) => value = GetVector3(key, value);
    public static void ResetVector3(string key)
    {
        key += "_VECTOR3_";
        if (PlayerPrefs.HasKey(key + 'X')) PlayerPrefs.DeleteKey(key + 'X');
        if (PlayerPrefs.HasKey(key + 'Y')) PlayerPrefs.DeleteKey(key + 'Y');
        if (PlayerPrefs.HasKey(key + 'Z')) PlayerPrefs.DeleteKey(key + 'Z');
    }
    public static bool HasVector3(string key)
    {
        key += "_VECTOR3_";
        return
            PlayerPrefs.HasKey(key + 'X') &&
            PlayerPrefs.HasKey(key + 'Y') &&
            PlayerPrefs.HasKey(key + 'Z');
    }
    #endregion
    #region VECTOR3INT
    public static Vector3Int SetVector3Int(string key, Vector3Int value)
    {
        key += "_VECTOR3INT_";
        PlayerPrefs.SetInt(key + 'X', value.x);
        PlayerPrefs.SetInt(key + 'Y', value.y);
        PlayerPrefs.SetInt(key + 'Z', value.z);
        return value;
    }
    public static Vector3Int GetVector3Int(string key, Vector3Int defaultValue) => SetVector3Int(key, new Vector3Int(
        PlayerPrefs.GetInt(key + "_VECTOR3INT_X", defaultValue.x),
        PlayerPrefs.GetInt(key + "_VECTOR3INT_Y", defaultValue.y),
        PlayerPrefs.GetInt(key + "_VECTOR3INT_Z", defaultValue.z)));
    public static Vector3Int GetVector3Int(string key) => GetVector3Int(key, Vector3Int.zero);
    public static Vector3Int GetVector3Int(string key, ref Vector3Int value) => value = GetVector3Int(key, value);
    public static void ResetVector3Int(string key)
    {
        key += "_VECTOR3INT_";
        if (PlayerPrefs.HasKey(key + 'X')) PlayerPrefs.DeleteKey(key + 'X');
        if (PlayerPrefs.HasKey(key + 'Y')) PlayerPrefs.DeleteKey(key + 'Y');
        if (PlayerPrefs.HasKey(key + 'Z')) PlayerPrefs.DeleteKey(key + 'Z');
    }
    public static bool HasVector3Int(string key)
    {
        key += "_VECTOR3INT_";
        return
            PlayerPrefs.HasKey(key + 'X') &&
            PlayerPrefs.HasKey(key + 'Y') &&
            PlayerPrefs.HasKey(key + 'Z');
    }
    #endregion
    #region VECTOR2
    public static Vector2 SetVector2(string key, Vector2 value)
    {
        key += "_VECTOR2_";
        PlayerPrefs.SetFloat(key + 'X', value.x);
        PlayerPrefs.SetFloat(key + 'Y', value.y);
        return value;
    }
    public static Vector2 GetVector2(string key, Vector2 defaultValue)
    {
        Vector2 ret;
        ret.x = PlayerPrefs.GetFloat(key + "_VECTOR2_X", defaultValue.x);
        ret.y = PlayerPrefs.GetFloat(key + "_VECTOR2_Y", defaultValue.y);
        return SetVector2(key, ret);
    }
    public static Vector2 GetVector2(string key) => GetVector2(key, Vector2.zero);
    public static Vector2 GetVector2(string key, ref Vector2 value) => value = GetVector2(key, value);
    public static void ResetVector2(string key)
    {
        key += "_VECTOR2_";
        if (PlayerPrefs.HasKey(key + 'X')) PlayerPrefs.DeleteKey(key + 'X');
        if (PlayerPrefs.HasKey(key + 'Y')) PlayerPrefs.DeleteKey(key + 'Y');
    }
    public static bool HasVector2(string key)
    {
        key += "_VECTOR2_";
        return
            PlayerPrefs.HasKey(key + 'X') &&
            PlayerPrefs.HasKey(key + 'Y');
    }
    #endregion
    #region VECTOR2INT
    public static Vector2Int SetVector2Int(string key, Vector2Int value)
    {
        key += "_VECTOR2INT_";
        PlayerPrefs.SetInt(key + 'X', value.x);
        PlayerPrefs.SetInt(key + 'Y', value.y);
        return value;
    }
    public static Vector2Int GetVector2Int(string key, Vector2Int defaultValue) => SetVector2Int(key, new Vector2Int(
        PlayerPrefs.GetInt(key + "_VECTOR2INT_X", defaultValue.x),
        PlayerPrefs.GetInt(key + "_VECTOR2INT_Y", defaultValue.y)));
    public static Vector2Int GetVector2Int(string key) => GetVector2Int(key, Vector2Int.zero);
    public static Vector2Int GetVector2Int(string key, ref Vector2Int value) => value = GetVector2Int(key, value);
    public static void ResetVector2Int(string key)
    {
        key += "_VECTOR2INT_";
        if (PlayerPrefs.HasKey(key + 'X')) PlayerPrefs.DeleteKey(key + 'X');
        if (PlayerPrefs.HasKey(key + 'Y')) PlayerPrefs.DeleteKey(key + 'Y');
    }
    public static bool HasVector2Int(string key)
    {
        key += "_VECTOR2INT_";
        return
            PlayerPrefs.HasKey(key + 'X') &&
            PlayerPrefs.HasKey(key + 'Y');
    }
    #endregion
    #region QUATERNION
    public static Quaternion SetQuaternion(string key, Quaternion value)
    {
        key += "_QUATERNION_";
        PlayerPrefs.SetFloat(key + 'X', value.x);
        PlayerPrefs.SetFloat(key + 'Y', value.y);
        PlayerPrefs.SetFloat(key + 'Z', value.z);
        PlayerPrefs.SetFloat(key + 'W', value.w);
        return value;
    }
    public static Quaternion GetQuaternion(string key, Quaternion defaultValue)
    {
        Quaternion ret;
        ret.x = PlayerPrefs.GetFloat(key + "_QUATERNION_X", defaultValue.x);
        ret.y = PlayerPrefs.GetFloat(key + "_QUATERNION_Y", defaultValue.y);
        ret.z = PlayerPrefs.GetFloat(key + "_QUATERNION_Z", defaultValue.z);
        ret.w = PlayerPrefs.GetFloat(key + "_QUATERNION_W", defaultValue.w);
        return SetQuaternion(key, ret);
    }
    public static Quaternion GetQuaternion(string key) => GetQuaternion(key, Quaternion.identity);
    public static Quaternion GetQuaternion(string key, ref Quaternion value) => value = GetQuaternion(key, value);
    public static void ResetQuaternion(string key)
    {
        key += "_QUATERNION_";
        if (PlayerPrefs.HasKey(key + 'X')) PlayerPrefs.DeleteKey(key + 'X');
        if (PlayerPrefs.HasKey(key + 'Y')) PlayerPrefs.DeleteKey(key + 'Y');
        if (PlayerPrefs.HasKey(key + 'Z')) PlayerPrefs.DeleteKey(key + 'Z');
        if (PlayerPrefs.HasKey(key + 'W')) PlayerPrefs.DeleteKey(key + 'W');
    }
    public static bool HasQuaternion(string key)
    {
        key += "_QUATERNION_";
        return
            PlayerPrefs.HasKey(key + 'X') &&
            PlayerPrefs.HasKey(key + 'Y') &&
            PlayerPrefs.HasKey(key + 'Z') &&
            PlayerPrefs.HasKey(key + 'W');
    }
    #endregion
    public static void Save() => PlayerPrefs.Save();
}