using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlanteInsecte : MonoBehaviour
{

    /*! Booléen qui permet de savoir si la plante à été créée ou non. */
    public bool valide = false;
    /*! Taille de la plante sous forme de chaine de caractères. */
    public string parfum;
    /*! Forme des feuilles de la plante sous forme de chaine de caractères. */
    public string ultra;
    /*! Couleur de la plante sous forme de chaine de caractères. */
    public string couleur;


    /*! Objet de la plante. */
    public GameObject obj;
    /*! Texte correspondant à l'ensemble des informations affichées sur une plante créée au préalable. */
    public Text textDisplay;

    /*!
     * Méthode qui permet de générer les différentes informations de la plante.
     * @param attributs Les informations physiques relatives à la plante créée.
     */
    IEnumerator generer(object[] attributs)
    {
        parfum = attributs[0].ToString();
        couleur = attributs[1].ToString();
        ultra = attributs[2].ToString();

        float somme = 0;
        switch(parfum)
        {
            case "Moyen":
                somme += 1;
                break;
            case "Elevé":
                somme += 2;
                break;
            default:
                somme += 0;
                break;
        }
        switch (couleur)
        {
            case "Bleu":
                somme += 2;
                break;
            case "Jaune":
                somme += 2;
                break;
            default:
                somme += 0;
                break;
        }
        if (!ultra.Equals(""))
        {
            somme += 1;
            switch (ultra)
            {
                case "Centre":
                    somme += 1;
                    break;
                default:
                    somme += 0;
                    break;
            }
        }

        //determination de la réussite ou non du défis de création de plante en fonction du pourcentage d'informations correctes
        somme = (somme / 6) * 100;
        Quete.instance.afficherTuto(true);
        if (somme < 40)//défi non réussi
        {
            valide = false;
            Quete.instance.afficherMessage("Hmmmm... ma plante n’attire pas d’insecte...");
        }
        else if (somme < 70)//défi partiellement réussi
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("plante-abeille-1", typeof(Sprite)) as Sprite;
            valide = true;
            Quete.instance.afficherMessage("Ma plante attire très peu d’insectes, mais ce n’est pas grave je vais faire avec");
        }
        else if (somme < 90)//défi réussi
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("plante-abeille-2-" + couleur.ToLower(), typeof(Sprite)) as Sprite;
            valide = true;
            Quete.instance.afficherMessage("Génial ! Ma plante attire des insectes, je vais en rajouter plein à l’avenir !");
        }
        else//défi réalisé à la perfection
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("plante-abeille-3-" + couleur.ToLower(), typeof(Sprite)) as Sprite;
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
            textDisplay.text = "Parfum : " + parfum + " - Couleur : " + couleur;
            if (!ultra.Equals(""))
                textDisplay.text += " - Ultraviolet : " + ultra;
        }
        else
        {
            ControleurJoueur.autoriserMouvement = true;
            obj.SetActive(false);
            textDisplay.text = "";
        }
    }
}
