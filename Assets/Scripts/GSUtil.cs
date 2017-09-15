using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSUtil : MonoBehaviour {

    private static GSUtil _Instance;

    public bool isJapan = false;
    public TextMesh helloText;

    public static GSUtil Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<GSUtil>();
            }
            return _Instance;
        }
    }

    private void Awake()
    {
        // タイムゾーン取得
#if UNITY_UWP
        TimeZoneInfo timezone = TimeZoneInfo.Local;
        if (timezone.Id.Equals("Tokyo Standard Time"))
        {
            isJapan = true;
        }
        else
        {
            isJapan = false;
        }
#endif
        // ローカライズファイル初期化
        TextLocalizer.Init(isJapan);

    }

    // Use this for initialization
    void Start () {
        helloText.text = TextLocalizer.Get("Hello");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
