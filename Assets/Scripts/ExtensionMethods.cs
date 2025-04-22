using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static Vector2 ToNewVector2(this Vector2 vector) => new Vector2(vector.x, vector.y);

    public static Color GetTransparentColor(this Color color) => new Color(color.r, color.g, color.b, 0);
    public static Color GetVisibleColor(this Color color) => new Color(color.r, color.g, color.b, 1);
}
