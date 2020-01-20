using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Quete : MonoBehaviour {

    /*! Instance de la classe courrante Quete initialisée nulle au départ.*/
    public static Quete instance = null;
    /*! Objet de la zone de texte du tutoriel.*/
    public GameObject zoneTextTuto;
    /*! Texte corerspondant aux actions que le joueur doit réaliser.*/
    public Text zoneText;

    /*!
    * Méthode qui permet d'initialiser l'instance de la classe sous forme d'un singleton.
    */
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            instance = this;
        }
    }

    void Start()
    {
        afficherTuto(false);
    }

    /*!
     * Méthode qui permet d'ajouter une instruction à la zone de texte du tutoriel sans lecture dans un fichier texte.
     * @param message L'instruction que l'on souhaite ajouter à la zone de texte.
     */
    public void afficherMessage(string message)
    {
        Quete.instance.zoneText.text = message;
    }

    /*!
     * Méthode qui permet l'affichage de la zone de texte correpondant au tutoriel du jeu content les instructions pour le joueur.
     * @param Afficher Booléen correpondant à l'autorisation ou non de l'affichage du tutoriel.
     */ 
    public void afficherTuto(bool afficher)
    {
        zoneTextTuto.SetActive(afficher);
        zoneText.enabled = afficher;

    }
}
