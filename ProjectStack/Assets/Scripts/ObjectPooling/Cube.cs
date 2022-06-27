using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IPoolable
{
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private Rigidbody _rb;
    public void PrepareForActivate(Vector3 position)
    {
        transform.SetParent(null);
        transform.position = position;
        this.gameObject.SetActive(true);
        transform.localScale = new Vector3(1.5f, 0.2f, 1.5f);
    }

    public void PrepareForDeactivate(Transform parent)
    {
        this.gameObject.SetActive(false);
        this.transform.SetParent(parent);
    }

    public void EnableGravity()
    {
        _rb.useGravity = true;
    }
    public void SetColor(float hue)
    {
        _meshRenderer.material.color = Color.HSVToRGB(hue, 1f, 1f);
    }

    public void SetColor(float hue, float value)
    {
        _meshRenderer.material.color = Color.HSVToRGB(hue, 1f, value);
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }

    public Color GetColor()
    {
        return _meshRenderer.material.color;
    }




}
