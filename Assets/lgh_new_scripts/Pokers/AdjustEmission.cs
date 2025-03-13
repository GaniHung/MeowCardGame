using UnityEngine;

public class AdjustEmission : MonoBehaviour
{
    public Renderer targetRenderer; // 目标渲染器
    public Color emissionColor = Color.white; // 发光颜色
    public float emissionIntensity = 1.0f; // 发光强度

    private Material material; // 存储材质引用
    private Color originalColor; // 存储原始颜色

    void Start()
    {
        if (targetRenderer == null)
        {
            targetRenderer = GetComponent<Renderer>();
        }

        material = targetRenderer.material;
        originalColor = material.color; // 保存原始颜色

        SetEmission(emissionColor, emissionIntensity);
    }

    public void SetEmission(Color color, float intensity)
    {
        if (material != null)
        {
            material.EnableKeyword("_EMISSION"); // 启用发光关键字
            material.SetColor("_EmissionColor", color * intensity);
            material.color = originalColor; // 保留原始颜色
        }
    }

    void Update()
    {
        // 示例：根据时间变化发光颜色和强度
        float time = Time.time;
        Color dynamicColor = new Color(Mathf.Sin(time) * 0.5f + 0.5f, Mathf.Cos(time) * 0.5f + 0.5f, 0.5f, 1.0f);
        float dynamicIntensity = Mathf.PingPong(time, 1.0f);
        SetEmission(dynamicColor, dynamicIntensity);
    }
}