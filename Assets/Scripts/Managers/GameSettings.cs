﻿using UnityEngine;
public static class GameSettings
{
    public static bool SetBool(string key, bool value) { PlayerPrefs.SetInt(key + "BOOL", value ? 1 : 0); return value; }
    public static bool GetBool(string key, bool defaultValue = false) { return SetBool(key, 0 != PlayerPrefs.GetInt(key + "BOOL", defaultValue ? 1 : 0)); }
    public static bool GetBool(string key, ref bool value) { value = GetBool(key, value); return value; }
    public static int SetInt(string key, int value) { PlayerPrefs.SetInt(key + "INT", value); return value; }
    public static int GetInt(string key, int defaultValue = 0) { return SetInt(key, PlayerPrefs.GetInt(key + "INT", defaultValue)); }
    public static int GetInt(string key, ref int value) { value = GetInt(key, value); return value; }
    public static uint SetUint(string key, uint value) { PlayerPrefs.SetInt(key + "UINT", unchecked((int)value)); return value; }
    public static uint GetUint(string key, uint defaultValue = 0) { return SetUint(key, unchecked((uint)PlayerPrefs.GetInt(key + "UINT", unchecked((int)defaultValue)))); }
    public static uint GetUint(string key, ref uint value) { value = GetUint(key, value); return value; }
    public static float SetFloat(string key, float value) { PlayerPrefs.SetFloat(key + "FLOAT", value); return value; }
    public static float GetFloat(string key, float defaultValue = 0.0f) { return SetFloat(key, PlayerPrefs.GetFloat(key + "FLOAT", defaultValue)); }
    public static float GetFloat(string key, ref float value) { value = GetFloat(key, value); return value; }
    public static string SetString(string key, string value) { PlayerPrefs.SetString(key + "STRING", value); return value; }
    public static string GetString(string key, string defaultValue = "") { return SetString(key, PlayerPrefs.GetString(key + "STRING", defaultValue)); }
    public static string GetString(string key, ref string value) { value = GetString(key, value); return value; }
    public static char SetChar(string key, char value) { PlayerPrefs.SetString(key + "CHAR", "" + value); return value; }
    public static char GetChar(string key, char defaultValue = '\0') { string str = PlayerPrefs.GetString(key + "CHAR", "" + defaultValue); return SetChar(key, (null != str && str.Length > 0) ? str[0] : '\0'); }
    public static char GetChar(string key, ref char value) { value = GetChar(key, value); return value; }
    public static void Save() { PlayerPrefs.Save(); }
    public static void Reset(string key) { PlayerPrefs.DeleteKey(key); }
    public static void Reset() { PlayerPrefs.DeleteAll(); }
}