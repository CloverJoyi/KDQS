

using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance { get; private set; }
    public Image mask;
    private float originalSize;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
