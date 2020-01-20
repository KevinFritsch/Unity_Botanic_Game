using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plante : MonoBehaviour {

    /*! Booléan qui permet de savoir si la plante à été créée ou non. */
    public bool valide;

    /*! Taille de la plante sous forme de chaine de carractères. */
    public string taille;
    /*! Forme des feuilles de la plante sous forme de chaine de caractères. */
    public string forme;
    /*! Couleur de la plante sous forme de chaine de caractères. */
    public string couleur;
    /*! Poils de la plante sous forme de chaine de caractères.*/
    public string poil;
    /*! Epines de la plante sous forme de chaine de caractères.*/
    public string epine;
    /*! Cire de la plante sous forme de chaine de caractères.*/
    public string cire;
    /*! Tige de la plante sous forme de chaine de caractères.*/
    public string tige;
    /*! Racine de la plante sous forme de chaine de caractères.*/
    public string racine;

    /*! Objet de la plante. */
    public GameObject obj;
    /*! Texte correspondant à l'ensemble des informations physiques affichées sur une plante créée au préalable. */
    public Text textDisplay;

    /*!
     * Méthode d'initialisation de la classe.
     */
    void Start () {
        valide = false;	
	}

    /*!
     * Méthode qui permet de générer les différentes informations physiques de la plante.
     * @param attributs Les informations relatives à la plante créée.
     */
    public virtual IEnumerator generer(object[] attributs)
    {
        taille = attributs[0].ToString();
        couleur = attributs[1].ToString();
        tige = attributs[2].ToString();
        forme = attributs[3].ToString();
        poil = attributs[4].ToString();
        epine = attributs[5].ToString();
        cire = attributs[6].ToString();
        racine = attributs[7].ToString();


        float somme = 0;
        switch (taille)
        {
            case "Petite":
                somme += 2;
                break;
            case "Moyenne":
                somme += 1;
                break;
            default:
                somme += 0;
                break;
        }
        switch (couleur)
        {
            case "Noir":
                somme += 2;
                break;
            case "Marron":
                somme += 2;
                break;
            case "Bleu":
                somme += 2;
                break;
            case "Violet":
                somme += 2;
                break;
            default:
                somme += 0;
                break;
        }
        switch (tige)
        {
            case "Souple":
                somme += 2;
                break;
            default:
                somme += 0;
                break;
        }
        switch (racine)
        {
            case "Longues":
                somme += 2;
                break;
            case "Moyennes":
                somme += 1;
                break;
            default:
                somme += 0;
                break;
        }

        switch (forme)
        {
            case " Pas de feuilles ":
                somme += 2;
                break;
            default:
                somme += 0;
                break;
        }

        switch (poil)
        {
            case " Poils ":
                somme += 2;
                break;
            default:
                somme += 0;
                break;
        }

        switch (epine)
        {
            case " Epines ":
                somme += 2;
                break;
            default:
                somme += 0;
                break;
        }

        switch (cire)
        {
            case "Cire":
                somme += 2;
                break;
            default:
                somme += 0;
                break;
        }
        //calcul pour déterminer si le joueur à réussi le défis ou non selon un pourcentage d'informations correctes
        somme = (somme / 16) * 100;
        Quete.instance.afficherTuto(true);
        if (somme < 40)//défi non réussi
        {
            valide = false;
            Quete.instance.afficherMessage("Hmmm... Ma plante ne résiste pas...");
        }
        else if (somme < 70)//défi relativement réussi
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("plante-1", typeof(Sprite)) as Sprite;
            valide = true;
            Quete.instance.afficherMessage("Ma plante ne résiste pas très bien, mais ce n’est pas grave je vais faire avec");
        }
        else if (somme < 90)//défi réussi
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("plante-2-" + couleur.ToLower(), typeof(Sprite)) as Sprite;
            valide = true;
            Quete.instance.afficherMessage("Génial ! Ma plante résiste super bien, je vais en rajouter plein à l’avenir !");
        }
        else//défi réussi à la perfection
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("plante-3-" + couleur.ToLower(), typeof(Sprite)) as Sprite;
            valide = true;
            Quete.instance.afficherMessage("Incroyable ! Ma plante est parfaite !");
        }
        yield return new WaitForSeconds(10);
        Quete.instance.afficherMessage("");
        Quete.instance.afficherTuto(false);
    }

    /*!
     * Méthode qui permet d'afficher les informations physiques de la plante créée.
     */
    void afficherInfo()
    {
        if (!obj.activeSelf)
        {
            ControleurJoueur.autoriserMouvement = false;
            obj.SetActive(true);
            textDisplay.text = "Taille : " + taille + " Couleur : " + couleur + " Tige : " + tige + " Racines : " + racine + " " + forme +  poil +  epine + cire;
        }
        else
        {
            ControleurJoueur.autoriserMouvement = true;
            obj.SetActive(false);
            textDisplay.text = "";
        }
    }
}
