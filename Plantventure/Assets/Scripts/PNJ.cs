using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNJ : MonoBehaviour {

    /*! Réference la fenetre de dialogue. */
    [SerializeField] private GameObject fenetreDialogue;
    /*! Réference l'objet texte de la fenetre de dialogue. */
    [SerializeField] private Text zoneTexte;

    // Informations relatives au 
    /*! Chaine de caractères correspondant au nom du PNJ.*/
    [SerializeField] private string nom;
    /*! Tableau correspondant à l'ensemble des lignes de discussions. */
    [SerializeField] private string[] lignes;
    /*! Vitesse d'affichage des discussions des PNJ. */
    private float vitesseAffichage = 0.0001f;

    /*! Index correspondant à une ligne dans le tableau des discussions. */
    private int index = 0;
    /*! Booléen permettant de savoir si l'aide d'identification des PNJ était activée avant l'intéraction avec un PNJ.*/
    private bool aideWasActive = false;

    /*!
     * Méthode qui permet de mettre en scène une interaction entre le joueur et un PNJ.
     */
    public void parler()
    {
        if (!fenetreDialogue.activeSelf)
        {
            aideWasActive = MenuInGame.aide;
            MenuInGame.aide = false;
            ControleurJoueur.autoriserMouvement = false;
            fenetreDialogue.SetActive(true);
            StartCoroutine(Ecrire());
        }
        else if (zoneTexte.text.Equals(getLigne(index)))
        {
            ligneSuivante();
        }
    }
    /*!
     * Méthode qui permet d'afficher les répliques de dialogues des PNJ durant une intéraction avec le joueur.
     */
    IEnumerator Ecrire()
    {
        foreach (char letter in getLigne(index).ToCharArray())
        {
            zoneTexte.text += letter;
            yield return new WaitForSeconds(vitesseAffichage);
        }
    }

    /*!
     * Méthode qui permet d'afficher la réplique de dialogue suivante d'un PNJ.
     */
    public void ligneSuivante()
    {
        int taille = lignes.Length;

        if (index < taille - 1)
        {
            index++;
            zoneTexte.text = "";
            StartCoroutine(Ecrire());
        } else
        {
            ControleurJoueur.autoriserMouvement = true;
            fenetreDialogue.SetActive(false);
            index = 0;
            zoneTexte.text = "";
            if(aideWasActive)
                MenuInGame.aide = true;
        }
    }

    /*§
     * Méthode qui permet d'accéder à la réplique de dialogue d'un PNJ par rapport au numéro de ligne.
     * @param index Le numéro de la ligne souhaitée.
     * @return La réplique de dialogue du PNJ.
     */ 
    public string getLigne(int index)
    {
        return nom + " - " + lignes[index].Replace("(joueur)", ControleurJoueur.instance.nom);
    }
}
