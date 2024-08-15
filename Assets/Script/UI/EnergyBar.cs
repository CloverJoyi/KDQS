using UnityEngine.UI;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    public static EnergyBar Instance { get; private set; }
    public Image mask;
    private float originalSize;

    void Awake()
    {
        Instance = this;
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;

    }

    // Update is called once per frame
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSize * value);
    }
}
