using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleurJoueur : MonoBehaviour
{
    /*! Instance de la classe courrante ControleurJoueur initialisée nulle au départ.*/
    public static ControleurJoueur instance = null;
    /*! Chaine de caractères correspondant au nom du joueuer.*/
    public string nom = "";
    /*! Vitesse de déplacement du personnage. */
    [SerializeField] private float speed = 4;
    /*! Vecteur de la position de départ. */
    private Vector2 startPos;
    /*! Vecteur de la positon de la cible. */
    private Vector2 targetPos;
    /*! Timer permettant d'éffectuer les déplacements. */
    private float timer;
    /*! Booléen permettant de savoir si le joueur est en déplacement ou non. */
    private bool isMoving;
    /*! Animation du déplacement du personnage. */
    private Animator animation;
    /*! Indexe de la direction du déplacement du personnage */
    private int spriteDirection = 0;
    /*! Vecteur de la direction du personnage. */
    private Vector3 direction;

    /*! Booléen qui permet de savoir si le déplacement du personnage est autorisé ou non en fonction des obstacles présents sur la carte. */
    public static bool autoriserMouvement = true;

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
     * Méthode qui permet d'initialiser les attributs de la classe.
     */
    void Start()
    {
        animation = this.GetComponent<Animator>();
        startPos = transform.position;
        targetPos = transform.position;
        autoriserMouvement = true;
    }

    /*!
     * Méthode qui permet de mettre à jour les éléments de la classe en fonction des déplacements et des mouvements du personnage en temps réel.
     */
    void Update()
    {
        animation.SetInteger("direction", spriteDirection);
        if (timer <= 1 && isMoving)
        {
            timer += speed / 100;
        }
        else
        {
            isMoving = false;
            animation.SetBool("marche", false);
        }
        if (isMoving)
        {
            transform.position = Vector2.Lerp(startPos, targetPos, timer);
        }

        // On vérifie si le jeu est en pause
        if (!MenuInGame.pause)
        {
            if (Input.GetKeyDown("space") && !isMoving)
            {
                parlerAuPNJ();
                StartCoroutine(creerPlante());
            }
            if (autoriserMouvement)
            {
                if ((Input.GetKey("z") || Input.GetKey("up")) && !isMoving)
                {
                    bouger(Vector3.up, 2, 0, 1);
                }
                else if ((Input.GetKey("s") || Input.GetKey("down")) && !isMoving)
                {
                    bouger(Vector3.down, 0, 0, -1);
                }
                else if ((Input.GetKey("q") || Input.GetKey("left")) && !isMoving)
                {
                    bouger(Vector3.left, 1, -1, 0);
                }
                else if ((Input.GetKey("d") || Input.GetKey("right")) && !isMoving)
                {
                    bouger(Vector3.right, 3, 1, 0);
                }
            }
        }
    }

    /*!
     * Méthode qui permet de déplacer le personnage en fonction des directions souhaitées.
     * @param direction Vecteur de direction du déplacement.
     * @param spriteDirection Entier correspondant à la direction souhaitée.
     * @param x Abscisse du déplacement.
     * @param y Ordonnée du déplacement.
     */
    void bouger(Vector3 direction, int spriteDirection, float x, float y)
    {
        this.spriteDirection = spriteDirection;
        this.direction = direction;
        if (!detecterCollision(direction))
        {
            timer = 0;
            isMoving = true;
            animation.SetBool("marche", true);
            startPos = transform.position;
            targetPos = new Vector2(startPos.x + x, startPos.y + y);
        }
    }

    /*!
     * Méthode qui permet de détecter une collision entre un obstacle présent sur la carte et le vecteur de direction du déplacement du personnage.
     * @param direction Vecteur de direction du déplacement.
     * @return collision Booléen qui permet de savoir si il y a une collision ou non.
     */
    private bool detecterCollision(Vector3 direction)
    {
        RaycastHit hit;
        bool collision = false;
        if (Physics.Raycast(transform.position, direction, out hit, 1.0f))
        {
            if (hit.collider.gameObject.tag == "obstacle" || hit.collider.gameObject.tag == "pnj" || hit.collider.gameObject.tag == "plante" || hit.collider.gameObject.tag == "planteinsecte")
            {
                collision = true;
            }
        }
        return collision;
    }

    /*!
     * Méthode qui permet de parler avec un personnage non joueur.
     */
    void parlerAuPNJ()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 1.0f))
        {
            if (hit.collider.gameObject.tag == "pnj")
            {
                hit.collider.SendMessage("parler");
            }
        }
    }

    /*!
     * Méthode qui permet d'intéragir avec une plante et de lancer le menu de création de la plante.
     */
    IEnumerator creerPlante()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, this.direction, out hit, 1.0f))
        {
            if (hit.collider.gameObject.tag == "plante")
            {
                Plante plante = (Plante)hit.collider.gameObject.GetComponent("Plante");
                if (!plante.valide)
                {
                    CreationPlante.plante = hit.collider.gameObject;
                    MenuInGame.pause = true;
                    MenuInGame.afficher = false;
                    AsyncOperation chargement = SceneManager.LoadSceneAsync("scn_CreationPlante", LoadSceneMode.Additive);
                    yield return chargement;
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("scn_CreationPlante"));
                }
                else
                {
                    hit.collider.gameObject.SendMessage("afficherInfo");
                }
            }
            else if (hit.collider.gameObject.tag == "planteinsecte")
            {
                PlanteInsecte plante = (PlanteInsecte)hit.collider.gameObject.GetComponent("PlanteInsecte");
                if (!plante.valide)
                {
                    CreationPlanteInsectes.plante = hit.collider.gameObject;
                    MenuInGame.pause = true;
                    MenuInGame.afficher = false;
                    AsyncOperation chargement = SceneManager.LoadSceneAsync("scn_CreationPlanteInsectes", LoadSceneMode.Additive);
                    yield return chargement;
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("scn_CreationPlanteInsectes"));
                }
                else
                {
                    hit.collider.gameObject.SendMessage("afficherInfo");
                }
            }
        }
    }
}