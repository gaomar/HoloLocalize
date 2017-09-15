using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class TextLocalizer {

    // 文字列格納、検索用ディクショナリー
    private static Dictionary<string, string> sDictionary = new Dictionary<string, string>();

    /// <summary>
    /// 文字列初期化
    /// </summary>
    /// <param name="isJapan">日本語かどうか</param>
    public static void Init(bool isJapan)
    {
        // リソースファイルパス決定
        string filePath;
        if (isJapan)
        {
            filePath = "Text/japanese";
        }
        else
        {
            filePath = "Text/english";
        }

        // ディクショナリー初期化
        sDictionary.Clear();
        TextAsset csv = Resources.Load<TextAsset>(filePath);
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {
            string[] values = reader.ReadLine().Split('\t');
            sDictionary.Add(values[0], values[1].Replace("\\n", "\n"));
        }
    }

    /// <summary>
    /// 文字列取得
    /// </summary>
    /// <param name="key">文字列取得キー</param>
    /// <returns>キーに該当する文字列</returns>
    public static string Get(string key)
    {
        return sDictionary[key];
    }

}
