using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheminNeige : Tile {

    /*! tableau représentant les différentes images de chemin. */
    [SerializeField] private Sprite[] CheminN;

    /*! Tableau représentant les previews. */
    [SerializeField] private Sprite[] preview;

    /*!
     * Méthode qui permet de raffraichir la page.
     * @param position Position sur la page.
     */
    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
       for(int y=-1; y <= 1; y++)
        {
            for(int x=-1; x <= 1; x++)
            {
                Vector3Int nPos = new Vector3Int(position.x + x, position.y + y, position.z);

                if(HasRoad(tilemap, position))
                {
                    tilemap.RefreshTile(nPos);
                }
            }
        }
    }

    /*!
     * Redefinition de la méthode GetTileData qui modifie la case courante en fonction des cases adjacentes.
     * @param position Position de la case.
     * @param tilemap TileMap de la case courante.
     * @param tileData Les données relatives à la case courante.
     */
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        string composition = string.Empty;

        for(int x = -1; x <= 1; x++)
        {
           
            for (int y = -1; y <= 1; y++)
            {
                if (x != 0 || y != 0)
                {
                    if (HasRoad(tilemap, new Vector3Int(position.x + x, position.y + y, position.z)))
                    {
                        composition += 'R';
                    }
                    else
                    {
                        composition += 'S';
                    }
                }                    
            }
        }

        tileData.sprite = CheminN[4];

        if (composition[1] == 'S' && composition[3] == 'R' && composition[4] == 'S' && composition[6] == 'R' && composition[2] == 'S')
        {
            tileData.sprite = CheminN[0];
        }

        else if (composition[1] == 'R' && composition[3] == 'R' && composition[4] == 'S' && composition[6] == 'R')
        {
            tileData.sprite = CheminN[1];
        }

        else if (composition[1] == 'R' && composition[3] == 'R' && composition[4] == 'S' && composition[6] == 'S' && composition[7] == 'S')
        {
            tileData.sprite = CheminN[2];
        }

        else if (composition[1] == 'S' && composition[3] == 'R' && composition[4] == 'R' && composition[6] == 'R')
        {
            tileData.sprite = CheminN[3];
        }

        else if (composition[1] == 'R' && composition[3] == 'R' && composition[4] == 'R' && composition[6] == 'S')
        {
            tileData.sprite = CheminN[5];
        }

        else if (composition[1] == 'S' && composition[3] == 'S' && composition[4] == 'R' && composition[6] == 'R' && composition[0] == 'S')
        {
            tileData.sprite = CheminN[6];
        }

        else if (composition[1] == 'R' && composition[3] == 'S' && composition[4] == 'R' && composition[6] == 'R')
        {
            tileData.sprite = CheminN[7];
        }

        else if (composition[1] == 'R' && composition[3] == 'S' && composition[4] == 'R' && composition[6] == 'S' && composition[5] == 'S')
        {
            tileData.sprite = CheminN[8];
        }

        else if (composition[1] == 'R' && composition[3] == 'R' && composition[4] == 'R' && composition[6] == 'R' && composition[2] == 'S')
        {
            tileData.sprite = CheminN[9];
        }

        else if (composition[1] == 'R' && composition[3] == 'R' && composition[4] == 'R' && composition[6] == 'R' && composition[7] == 'S')
        {
            tileData.sprite = CheminN[10];
        }

        else if (composition[1] == 'R' && composition[3] == 'R' && composition[4] == 'R' && composition[6] == 'R' && composition[0] == 'S')
        {
            tileData.sprite = CheminN[11];
        }

        else if (composition[1] == 'R' && composition[3] == 'R' && composition[4] == 'R' && composition[6] == 'R' && composition[5] == 'S')
        {
            tileData.sprite = CheminN[12];
        }
    }

    /*!
     * Méthode qui permet de vérifier si la position appartient à la TileMap.
     * @param position Position de la case.
     * @param tilemap TileMap de la case courante.
     * @return Booléen vrai si la position appartient à la TileMap.
     */
    private bool HasRoad(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }
    

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/CheminN")]

    public static void CreateChemin()
    {
        string path = EditorUtility.SaveFilePanelInProject("Sauvg Chemin", "Nvx Chemin", "asset", "Sauvg chemin", "Assets");

        if(path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<CheminNeige>(), path);
    }
#endif
}
