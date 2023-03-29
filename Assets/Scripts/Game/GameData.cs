using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private Sprite fire, earth, wind, water, order;
    [SerializeField] private Color defaultColor;
    [SerializeField] private List<Color> colorList;

    private static GameData instance;
    public static Color DefaultColor { get => instance.defaultColor; }

    public static Dictionary<Element, Element> winOrder = new Dictionary<Element, Element>()
    {
        {Element.Fire, Element.Wind },
        {Element.Water, Element.Earth },
        {Element.Earth, Element.Fire },
        {Element.Wind, Element.Water },
    };

    private void Awake()
    {
        instance = this;
    }

    public static void Initialize()
    {
        instance = FindObjectOfType<GameData>();
    }

    public static Sprite GetSprite(Element element)
    {
        switch (element)
        {
            case Element.Fire:
                return instance.fire;
            case Element.Water:
                return instance.water;
            case Element.Earth:
                return instance.earth;
            case Element.Wind:
                return instance.wind;
        }

        throw new System.Exception("incomplete map");
    }

    public static Color GetColor(int index)
    {
        return instance.colorList[index];
    }
}
