using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanteToundra : Plante {

    public override IEnumerator generer(object[] attributs)
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
            case "Rouge":
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
            case "Courtes":
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
        //calcul pour déterminer si le joueur à réussi le défis ou non selon un pourcentage d'informations correctes
        somme = (somme / 12) * 100;
        Quete.instance.afficherTuto(true);
        if (somme < 40)//défi non réussi
        {
            valide = false;
            Quete.instance.afficherMessage("Hmmm... Ma plante ne résiste pas...");
        }
        else if (somme < 70)//défi relativement réussi
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("plante-1-toundra", typeof(Sprite)) as Sprite;
            valide = true;
            Quete.instance.afficherMessage("Ma plante ne résiste pas très bien, mais ce n’est pas grave je vais faire avec");
        }
        else if (somme < 90)//défi réussi
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("plante-2-toundra-" + couleur.ToLower(), typeof(Sprite)) as Sprite;
            valide = true;
            Quete.instance.afficherMessage("Génial ! Ma plante résiste super bien, je vais en rajouter plein à l’avenir !");
        }
        else//défi réussi à la perfection
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("plante-toundra-3-" + couleur.ToLower(), typeof(Sprite)) as Sprite;
            valide = true;
            Quete.instance.afficherMessage("Incroyable ! Ma plante est parfaite !");
        }
        yield return new WaitForSeconds(10);
        Quete.instance.afficherMessage("");
        Quete.instance.afficherTuto(false);
    }
}
