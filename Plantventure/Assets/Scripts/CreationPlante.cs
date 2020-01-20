using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CreationPlante : MonoBehaviour
{

    /*! Image de la forme de la feuille. */
    public Image selectionImgForme;
    /*! Liste des images de la forme de la feuille. */
    public List<Sprite> listeImgForme = new List<Sprite>();
    public Text selectionForme;
    /*! Liste des textes de la forme de la feuille. */
    public List<string> listeTxtForme = new List<string>();

    //taille
    /*! Texte de la taille de la plante. */
    public Text selectionTaille;
    /*! Liste des textes de la taille de la plante.*/
    public List<string> listeTxtTaille = new List<string>();


    //couleur
    /*! Image de la couleur de la fleur. */
    public Image selectionImgCouleur;
    /*! Liste des couleurs de la fleur. */
    public List<Sprite> listeImgCouleur = new List<Sprite>();
    /*! Texte des couleurs de la plante. */
    public Text selectionCouleur;
    /*! Liste des textes des couleur.*/
    public List<string> listeTxtCouleur = new List<string>();

    //Tige
    /*! Texte des tiges de la plante. */
    public Text selectionTige;
    /*! Liste des textes des tiges de la plante.*/
    public List<string> listeTxtTige = new List<string>();

    //Racine
    /*! Texte des racines de la plante. */
    public Text selectionRacine;
    /*! Liste des textes des racines de la plante.*/
    public List<string> listeTxtRacine = new List<string>();

    /*! Indexe de la liste de la forme de la plante. */
    private int indexForme = 0;
    /*! Indexe de la liste de la taille de la plante. */
    private int indexTaille = 0;
    /*! Indexe de la liste des couleurs de la plante. */
    private int indexCouleur = 0;
    /*! Indexe de la liste des tiges de la plante. */
    private int indexTige = 0;
    /*! Indexe de la liste des racines de la plante. */
    private int indexRacine = 0;

    /*! Toggle correpondant à la présence de feuilles ou non.*/
    public Toggle ToggleFeuille;
    /*! Toggle correpondant à la présence de poils ou non.*/
    public Toggle TogglePoil;
    /*! Toggle correpondant à la présence d'épines ou non.*/
    public Toggle ToggleEpine;
    /*! Toggle correpondant à la présence de cire ou non.*/
    public Toggle ToggleCire;

    /*! Objet de la plante.*/
    public static GameObject plante;

    /*!
     * Méthode qui change vers la droite l'image de la feuille.
     */
    public void btnDroiteFeuille()
    {
        if (indexForme < listeImgForme.Count - 1)
        {
            indexForme++;
            selectionImgForme.sprite = listeImgForme[indexForme];
            selectionForme.text = listeTxtForme[indexForme];

        }
        else
        {
            indexForme = 0;
            selectionImgForme.sprite = listeImgForme[indexForme];
            selectionForme.text = listeTxtForme[indexForme];
        }


    }

    /*!
     * Méthode qui change vers la gauche l'image de la feuille.
     */
    public void btnGaucheFeuille()
    {
        if (indexForme > 0)
        {
            indexForme--;
            selectionImgForme.sprite = listeImgForme[indexForme];
            selectionForme.text = listeTxtForme[indexForme];
        }
        else
        {
            indexForme = listeImgForme.Count - 1;
            selectionImgForme.sprite = listeImgForme[indexForme];
            selectionForme.text = listeTxtForme[indexForme];
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
     * Méthode qui change vers la gauche la taille de la plante.
     */
    public void btnGaucheTaille()
    {
        if (indexTaille > 0)
        {
            indexTaille--;
            selectionTaille.text = listeTxtTaille[indexTaille];
        }
        else
        {
            indexTaille = listeTxtTaille.Count - 1;
            selectionTaille.text = listeTxtTaille[indexTaille];
        }
    }

    /*!
     * Méthode qui change vers la droite la taille de la plante.
     */
    public void btnDroiteTaille()
    {
        if (indexTaille < listeTxtTaille.Count - 1)
        {
            indexTaille++;
            selectionTaille.text = listeTxtTaille[indexTaille];

        }
        else
        {
            indexTaille = 0;
            selectionTaille.text = listeTxtTaille[indexTaille];
        }
    }

    /*!
     * Méthode qui change vers la gauche la tige de la plante.
     */
    public void btnGaucheTige()
    {
        if (indexTige > 0)
        {
            indexTige--;
            selectionTige.text = listeTxtTige[indexTige];
        }
        else
        {
            indexTige = listeTxtTige.Count - 1;
            selectionTige.text = listeTxtTige[indexTige];
        }
    }

    /*!
     * Méthode qui change vers la droite la tige de la plante.
     */
    public void btnDroiteTige()
    {
        if (indexTige < listeTxtTige.Count - 1)
        {
            indexTige++;
            selectionTige.text = listeTxtTige[indexTige];

        }
        else
        {
            indexTige = 0;
            selectionTige.text = listeTxtTige[indexTige];
        }
    }

    /*!
    * Méthode qui change vers la gauche la racine de la plante.
    */
    public void btnGaucheRacine()
    {
        if (indexRacine > 0)
        {
            indexRacine--;
            selectionRacine.text = listeTxtRacine[indexRacine];
        }
        else
        {
            indexRacine = listeTxtRacine.Count - 1;
            selectionRacine.text = listeTxtRacine[indexRacine];
        }
    }

    /*!
     * Méthode qui change vers la droite la racine de la plante.
     */
    public void btnDroiteRacine()
    {
        if (indexRacine < listeTxtRacine.Count - 1)
        {
            indexRacine++;
            selectionRacine.text = listeTxtRacine[indexRacine];

        }
        else
        {
            indexRacine = 0;
            selectionRacine.text = listeTxtRacine[indexRacine];
        }
    }


    /*!
     * Méthode qui genère la plante avec ses informations.
     */
    public void btnGenerer()
    {
        object[] attributs = new object[8];
        attributs[0] = selectionTaille.text;
        attributs[1] = listeTxtCouleur[indexCouleur];
        attributs[2] = selectionTige.text;
        attributs[7] = selectionRacine.text;
        //Vérification si les Toggles sont cochés ou non
        if (ToggleFeuille.isOn)
        {
            attributs[3] = " Forme des feuilles : " + selectionForme.text;

        }
        else
        {
            attributs[3] = " Pas de feuilles ";
        }

        if (TogglePoil.isOn)
        {
            attributs[4] = " Poils ";
        }
        else
        {
            attributs[4] = " Pas de poils ";
        }

        if (ToggleEpine.isOn)
        {
            attributs[5] = " Epines ";
        }
        else
        {
            attributs[5] = " Pas d'épines ";
        }

        if (ToggleCire.isOn)
        {
            attributs[6] = "Cire";
        }
        else
        {
            attributs[6] = " Pas de cire ";
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
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("scn_CreationPlante"));
    }
}
