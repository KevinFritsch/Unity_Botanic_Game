using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CreationPlanteInsectes : MonoBehaviour
{

    /*! Booléen qui vérifie si le menu est ouvert.*/
    public static bool ouvert = false;
   
    //parfum
    /*! Texte des parfums de la plante. */
    public Text selectionParfum;
    /*! Liste des textes des parfums de la plante.*/
    public List<string> listeTxtParfum = new List<string>();

    //couleur
    /*! Image de la couleur de la fleur. */
    public Image selectionImgCouleur;
    /*! Liste des couleurs de la fleur. */
    public List<Sprite> listeImgCouleur = new List<Sprite>();
    /*! Liste des textes des couleurs.*/
    public List<string> listeTxtCouleur = new List<string>();

    //localisation des couleurs ultraviolettes
    /*! Texte des localisations des couleurs ultraviolettes. */
    public Text selectionUltra;
    /*! Liste des localisations des couleurs ultraviolettes.*/
    public List<string> listeTxtUltra = new List<string>();

    /*! Indexe de la liste des parfums de la plante. */
    private int indexParfum = 0;
    /*! Indexe de la liste des couleurs de la plante. */
    private int indexCouleur= 0;
    /*! Indexe des localisations des couleurs ultraviolettes. */
    private int indexUltra = 0;

    /*! Toggle correpondant à la présence de formes ultraviolettes ou non.*/
    public Toggle ToggleUltra;

    /*! Objet de la plante.*/
    public static GameObject plante;

    /*!
     * Méthode qui change vers la droite l'image de la feuille.
     */
    public void btnDroiteParfum()
    {
        if (indexParfum < listeTxtParfum.Count - 1)
        {
            indexParfum++;
            selectionParfum.text = listeTxtParfum[indexParfum];

        }
        else
        {
            indexParfum = 0;
            selectionParfum.text = listeTxtParfum[indexParfum];
        }


    }

    /*!
     * Méthode qui change vers la gauche l'image de la feuille.
     */
    public void btnGaucheParfum()
    {
        if (indexParfum > 0)
        {
            indexParfum--;
            selectionParfum.text = listeTxtParfum[indexParfum];
        }
        else
        {
            indexParfum = listeTxtParfum.Count - 1;
            selectionParfum.text = listeTxtParfum[indexParfum];
        }
    }

    /*!
     * Méthode qui change vers la droite la couleur de la fleur.
     */
    public void btnDroiteCouleur()
    {
        if (indexCouleur < listeImgCouleur.Count - 1)
        {
            indexCouleur++;
            selectionImgCouleur.sprite = listeImgCouleur[indexCouleur];

        }
        else
        {
            indexCouleur = 0;
            selectionImgCouleur.sprite = listeImgCouleur[indexCouleur];
        }


    }

    /*!
     * Méthode qui change vers la gauche la couleur de la fleur.
     */
    public void btnGaucheCouleur()
    {
        if (indexCouleur > 0)
        {
            indexCouleur--;
            selectionImgCouleur.sprite = listeImgCouleur[indexCouleur];
        }
        else
        {
            indexCouleur = listeImgCouleur.Count - 1;
            selectionImgCouleur.sprite = listeImgCouleur[indexCouleur];
        }
    }

    /*!
     * Méthode qui change vers la droite la localisation des formes ultraviolettes.
     */
    public void btnDroiteUltra()
    {
        if (indexUltra < listeTxtUltra.Count - 1)
        {
            indexUltra++;
            selectionUltra.text = listeTxtUltra[indexUltra];

        }
        else
        {
            indexUltra = 0;
            selectionUltra.text = listeTxtUltra[indexUltra];
        }


    }

    /*!
     * Méthode qui change vers la gauche la localisation des formes ultraviolettes.
     */
    public void btnGaucheUltra()
    {
        if (indexUltra > 0)
        {
            indexUltra--;
            selectionUltra.text = listeTxtUltra[indexUltra];
        }
        else
        {
            indexUltra = listeTxtUltra.Count - 1;
            selectionUltra.text = listeTxtUltra[indexUltra];
        }
    }

    /*!
     * Méthode qui genère la plante avec ses informations.
     */
    public void btnGenerer()
    {
        object[] attributs = new object[3];
        attributs[0] = selectionParfum.text;
        attributs[1] = listeTxtCouleur[indexCouleur];
        attributs[2] = "";
        if (ToggleUltra.isOn)
        {
            attributs[2] = selectionUltra.text;

        }
        plante.SendMessage("generer", attributs);
        btnRetour();
    }
    
    /*!
     * Méthode qui permet de quitter le menu de création de plante.
     */
    public void btnRetour()
    {
        MenuInGame.pause = false;
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("scn_CreationPlanteInsectes"));
    }
}
