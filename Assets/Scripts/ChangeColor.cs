﻿using UnityEngine;

/// <summary>
/// Change the color through the time to a component of type <see cref="SkinnedMeshRenderer" />
/// </summary>
public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private float _Duration;

    private SkinnedMeshRenderer _FlagRenderer;

    private Color _Color1;

    private Color _Color2;

    private float _Time = 0f;

    private void Start()
    {
        _FlagRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        _Color1 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        _Color2 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    void Update()
    {
        UpdateFlagColor();
    }

    /// <summary>
    /// Updates dynamically the color to <see cref="_FlagRenderer"/>.
    /// </summary>
    private void UpdateFlagColor() {
        if (_FlagRenderer.material.color == _Color2)
        {
            _Time = 0f;
            _Color1 = _Color2;
            _Color2 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        Color color = Color.Lerp(_Color1, _Color2, _Time);
        _Time += Time.deltaTime / _Duration;
        _FlagRenderer.material.color = color;
    }

}