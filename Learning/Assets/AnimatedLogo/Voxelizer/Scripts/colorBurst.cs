using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorBurst : MonoBehaviour {
    public Voxelizer _voxelizer;
    [SerializeField] private ReflectionProbe _reflectionProbe;
    [SerializeField] private Texture hueTexture;
    public GameObject _colorBurst;
    private float colorHUE, dpiScale;
    private GUIStyle guiStyleHeader = new GUIStyle ();
    private Color guiColor = Color.red;

    void Awake () {
        if (!_reflectionProbe) {
            Debug.LogError ("PLeaseAddReflectionProbe");

        }
    }
    void Start () {
        if (Screen.dpi < 1) dpiScale = 1;
        if (Screen.dpi < 200) dpiScale = 1;
        else dpiScale = Screen.dpi / 200f;
        guiStyleHeader.fontSize = (int) (15f * dpiScale);
        guiStyleHeader.normal.textColor = guiColor;
    }

    private void OnGUI () {
        var offset = 0f;

        GUI.Label (new Rect (400 * dpiScale, 15 * dpiScale + offset / 2, 100 * dpiScale, 20 * dpiScale),
            "LogoAscreen \"");

        GUI.DrawTexture (new Rect (12 * dpiScale, 140 * dpiScale + offset, 285 * dpiScale, 15 * dpiScale), hueTexture, ScaleMode.StretchToFill, false, 0);

        float oldColorHUE = colorHUE;
        colorHUE = GUI.HorizontalSlider (new Rect (12 * dpiScale, 147 * dpiScale + offset, 285 * dpiScale, 15 * dpiScale), colorHUE, 0, 360);

        if (Mathf.Abs (oldColorHUE - colorHUE) > 0.001) {
            _voxelizer._lineColor = ME_ColorHelper.ConvertRGBColorByHUE (_voxelizer._lineColor, colorHUE / 360f);
        }

    }
}