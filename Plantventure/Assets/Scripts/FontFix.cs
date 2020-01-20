using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontFix : MonoBehaviour {

    /*! Tableau de polices de caractères. */
    public Font[] fonts;

    /*!
     * Méthode qui permet d'initialiser la fixation des pixels des polices de caractères.
     */
	void Start () {
		for(int i = 0; i < fonts.Length; i++)
        {
            fonts[i].material.mainTexture.filterMode = FilterMode.Point;
        }
	}
	
	
}
