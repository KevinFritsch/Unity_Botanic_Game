using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeTile : Tile
{
    /*!
     * Redéfinition de la méthode StartUp qui renvoie vrai si l'objet go est situé sur la position souhaitée.
     * @param position Position de la case.
     * @param tilemap TileMap de la case.
     * @param go Objet.
     * @return Booléen vrai ou faux si l'objet go est situé sur la position souhaitée.
     */
    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {
        go.GetComponent<SpriteRenderer>().sortingOrder = -position.y * 2;

        return base.StartUp(position, tilemap, go);
    }


#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/TreeTile")]

    public static void CreateChemin()
    {
        string path = EditorUtility.SaveFilePanelInProject("Sauvg TreeTile", "TreeTile", "asset", "Sauvg treeTile", "Assets");

        if (path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<TreeTile>(), path);
    }
#endif
}
