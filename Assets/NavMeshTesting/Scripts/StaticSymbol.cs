using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSymbol : MonoBehaviour
{

    protected Symbol currentSymbol;

    public Symbol CurrentSymbol {
        get { return currentSymbol; }
        set {
            currentSymbol = value;
            quadRenderer.material = materials[(int) currentSymbol];
        }
    }

    [SerializeField]
    protected List<Material> materials;

    [SerializeField]
    protected MeshRenderer quadRenderer;

    // Start is called before the first frame update
    protected virtual void Start() {
        CurrentSymbol = GenerateRandomSymbol();

    }

    protected Symbol GenerateRandomSymbol() {
        int rand = UnityEngine.Random.Range(0, 3);
        return (Symbol) rand;
    }
}
