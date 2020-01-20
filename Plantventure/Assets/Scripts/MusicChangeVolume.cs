using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicChangeVolume : MonoBehaviour {

    /*! Slider correpondant à la barre de niveau du volume de la musique du jeu. */
    public Slider volume;
    /*! Source audio de la musique principale du jeu. */
    public AudioSource maMusique;

    /*!
     * Méthode permettant d'initaliser la source audio de la classe en faisant appel à l'instance de la classe music_background.
     */ 
    void Awake()
    {
        maMusique = MusicBackground.instance.GetComponent<AudioSource>();
    }
    /*!
     * Méthode de mise à jour permattant de modifier le volume du jeu en fonction de la barre de niveau de volume dans les options du jeu. 
     * 
     */
    void Update () {
        maMusique.volume = volume.value;
	}
}
