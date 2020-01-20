using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInGame : MonoBehaviour
{
    /*! Instance de la classe courrante MenuInGame initialisée nulle au départ.*/
    public static MenuInGame instance = null;
    /*! Objet du menu pause. */
    [SerializeField] private GameObject menuPause;
    /*! Objet du nom du joueur. */
    [SerializeField] private GameObject selectionNom;
    /*! Objet du menu d'aide d'identification des PNJ. */
    [SerializeField] private GameObject menuAide;
    /*! Objet de l'introduction */
    [SerializeField] private GameObject zoneIntro;
    /*! Objet de la zone de text de l'introduction */
    [SerializeField] private Text zoneIntroText;

    /*! Booléen pour savoir si le menu pause est activé ou non. */
    public static bool pause = true;
    /*! Booléen pour savoir si le menu pause est affiché ou non. */
    public static bool afficher = false;
    /*! Booléen pour savoir si le menu d'aide d'identification des PNJ est activé ou non. */
    public static bool aide = false;
    /*! Texte qui permet d'afficher les messages d'erreur éventuels sous forme de chaine de caractères. */
    private Text textErreur;


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

    /*!
     * Méthode qui permet d'afficher le menu pause et de mettre à jour les éléments de ce menu.
     */
    void Start()
    {
        pause = true;
        afficher = false;
        aide = false;
        Text[] texts = selectionNom.GetComponentsInChildren<Text>();
        foreach (Text txt in texts)
        {
            if (txt.name.Equals("TextErreur"))
            {
                textErreur = txt;
                textErreur.enabled = false;
            }
        }
    }

    /*!
     * Méthode permettant de mettre à jour le menu pause en fontion des instructions du joueur.
     */ 
    void Update()
    {
        if (MenuInGame.pause)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            if (afficher)
            {
                menuPause.SetActive(true);
            }
        }
        else
        {
            menuPause.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
            afficher = false;
        }

        menuAide.SetActive(aide);

        if (Input.GetKeyDown("return") && !pause)
        {
            aide = !aide;
            menuAide.SetActive(!menuAide.activeSelf);
        }
        if (Input.GetKeyDown("escape") && !selectionNom.activeSelf && !zoneIntro.activeSelf)
        {
            MenuInGame.pause = !MenuInGame.pause;
            if (MenuInGame.pause)
            {
                afficher = true;
            }
            else if (SceneManager.GetActiveScene().name.Equals("scn_CreationPlante"))
            {
                SceneManager.UnloadSceneAsync("scn_CreationPlante");
            }
            else if (SceneManager.GetActiveScene().name.Equals("scn_CreationPlanteInsectes"))
            {
                SceneManager.UnloadSceneAsync("scn_CreationPlanteInsectes");
            }
        }
    }

    /*!
     * Méthode qui permet de quitter le menu pause et de continuer la partie.
     */
    public void BtnReprendre()
    {
        MenuInGame.pause = !MenuInGame.pause;
    }

    /*!
     * Méthode qui permet de retourner au menu principal du jeu.
     */
    public void BtnQuitter()
    {
        BtnReprendre();
        SceneManager.LoadScene(0);
    }
    /*!
     * Méthode qui permet de stocker et de prendre en compte le nom du joueur choisit pour lancer la partie.
     */ 
    public void BtnValiderNom()
    {
        InputField inputNom = selectionNom.GetComponentInChildren<InputField>();
        if(inputNom.text.Length >= 3)
        {
            ControleurJoueur.instance.nom = inputNom.text;
            string text = zoneIntroText.text.Replace("(joueur)", ControleurJoueur.instance.nom);
            zoneIntroText.text = text;
            selectionNom.SetActive(false);
        } else
        {
            textErreur.enabled = true;
        }
    }

    public void BtnValiderIntroduction()
    {
        zoneIntro.SetActive(false);
        BtnReprendre();
    }
}