using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuPrincipal : MonoBehaviour {
    
    /*!
     * Méthode qui permet d'afficher le menu principal.
     */
    private void Start()
    {
        Cursor.visible = true;
    }
    /*!
     * Méthode qui permet de charger et d'afficher la scène de jeu.
     */
    public void JouerJeu()
    {
        SceneManager.LoadScene(1);
    }
    /*!
     * Méthode qui permet de quitter le menu vers le bureau.
     */
    public void QuitterJeu()
    {
        Application.Quit();
    }
}
