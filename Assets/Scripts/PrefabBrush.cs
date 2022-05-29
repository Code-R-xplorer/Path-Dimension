#if UNITY_EDITOR
    using UnityEditor.Tilemaps;
    using UnityEngine;
    [CreateAssetMenu(fileName = "Prefab brush", menuName = "Brushes/Prefab brush")]
    [CustomGridBrush(false, true, false, "Prefab brush")]
    public class PrefabBrush : GameObjectBrush
    {}
#endif
