using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBuilderDirector : MonoBehaviour
{
    [Header("Builders Prefabs")]
    public GameObject Blue;
    public GameObject Green;
    public GameObject Orange;
    public GameObject Pink;
    public GameObject Red;


    [SerializeField]
    public AlienInfo[] AlienList;

    //Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAliens());
    }

    void BuildAlien(IAlienBuilder Builder, Vector2 position)
    {
        Builder.BuildAlien(position);
        Builder.SetAlienSprite();
        Builder.SetAlienBullet();
        Builder.AddAlienStrategy();
        Builder.SetAlienHealth();
       
    }

    private IEnumerator SpawnAliens()
    {
        foreach (AlienInfo alien in AlienList)
        {
            yield return new WaitForSeconds(0.5f);

            GameObject BuilderObject = null;
            IAlienBuilder Builder = null;

            switch (alien.type)
            {
                //uzycie new jest nie dozwolone w unity, poniewaz nie wie do jakiego obiektu ma byc skrypt przypisany
                //dlatego najpierw trzeba stworzyc obiekt posiadajacy skrypt
                //obiekt musi byc wczesniej stworzony w edytorze zeby bylo mozna mu przypisac z gory ustalone elementy nie bedace wartosciami
                case 1:
                    BuilderObject = Instantiate(Blue);
                    break;
                case 2:
                    BuilderObject = Instantiate(Green);
                    break;
                case 3:
                    BuilderObject = Instantiate(Orange);
                    break;
                case 4:
                    BuilderObject = Instantiate(Pink);
                    break;
                case 5:
                    BuilderObject = Instantiate(Red);
                    break;

            }
            if (BuilderObject != null)
            {
                Builder = BuilderObject.GetComponent<IAlienBuilder>();
                BuildAlien(Builder, alien.position);
                Destroy(BuilderObject);

            }
        }
    }
}

