using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScopeProjector : MonoBehaviour
{
    public float size = 2.0f;
    public float fadeSpeed = 2.0f;
    public Material projectorMaterial;          //Ʈ���� ���׸��� ���

    private MeshRenderer quadRenderer;
    private bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);       //�⺻ ���� �����
        quad.transform.SetParent(transform);
        quad.transform.localPosition = Vector3.zero;
        quad.transform.localRotation = Quaternion.Euler(90, 0, 0);
        quad.transform.localScale = Vector3.one * size;

        quadRenderer = quad.GetComponent<MeshRenderer>();
        quadRenderer.material = projectorMaterial;
        quadRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;   //�׸��� �ڵ带 ����.
        quadRenderer.receiveShadows = false;
        Destroy(quad.GetComponent<Collider>());
    }

    void Update()
    {
        if(isFading)
        {
            float currentAlpha = GetAlpha();
            currentAlpha -= fadeSpeed * Time.deltaTime;
            SetAlpha(currentAlpha);
            if(currentAlpha <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ShowAtPosition(Vector3 position)            //���� �����ǿ��� ������Ʈ�� �����ش�.
    {
        transform.position = position + Vector3.up * 0.1f;
        SetAlpha(1.0f);
        isFading = false;
        gameObject.SetActive(true);
    }

    public void StartFading()
    {
        isFading = true;
    }
    private void SetAlpha(float alpha)
    {
        alpha = Mathf.Clamp01(alpha);
        Color color = projectorMaterial.color;
        color.a = alpha;
        projectorMaterial.color = color;
    }

    private float GetAlpha()                        //���İ� �������� �Լ�
    {
        return projectorMaterial.color.a;
    }
}
