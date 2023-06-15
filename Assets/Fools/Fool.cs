using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fool : MonoBehaviour
{
    protected float currentAngle;

    [SerializeField]
    protected float speed;

    private MeshRenderer meshRenderer;
    private Color originColor;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GenerateRandomAngle();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        originColor = meshRenderer.material.color;
    }

    private void GenerateRandomAngle() {
        currentAngle = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0, currentAngle, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected void ResetFool() {
        transform.position = Vector3.zero;
        GenerateRandomAngle();
    }

    protected abstract void Move();

    protected abstract void ReactToClick();

    public void OnClick() {
        Hit();
        ReactToClick();
    }

    private void Hit() {
        meshRenderer.material.color = Color.red;
        LeanTween.color(meshRenderer.gameObject, originColor, 0.25f);
    }
}
