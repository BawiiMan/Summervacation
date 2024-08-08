using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScopeProjector : MonoBehaviour
{
    public float size = 2.0f;
    public float fadeSpeed = 2.0f;
    public Material projectorMaterial;          //트렌스 메테리얼 사용

    private MeshRenderer quadRenderer;
    private bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);       //기본 도형 만들기
        quad.transform.SetParent(transform);
        quad.transform.localPosition = Vector3.zero;
        quad.transform.localRotation = Quaternion.Euler(90, 0, 0);
        quad.transform.localScale = Vector3.one * size;

        quadRenderer = quad.GetComponent<MeshRenderer>();
        quadRenderer.material = projectorMaterial;
        quadRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;   //그림자 코드를 끈다.
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

    public void ShowAtPosition(Vector3 position)            //받은 포지션에서 오브젝트를 보여준다.
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

    private float GetAlpha()                        //알파값 가져오는 함수
    {
        return projectorMaterial.color.a;
    }
}
