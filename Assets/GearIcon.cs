using UnityEngine;

public class GearIcon : MonoBehaviour
{
    public RectTransform gearIcon;

    void Start()
    {
        gearIcon.anchorMin = new Vector2(1,1);
        gearIcon.anchorMax = new Vector2(1, 1);
        gearIcon.anchoredPosition = new Vector2(-10, -10);
    }   
}
