
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;



public class objetos
	{
    public string Title { get; set; } //endereço, arquivo, tipo e posição
    public string Position { get; set; }
    public string Type { get; set; }
    public string FilePath { get; set; }

    public objetos()
    {

    }

    public objetos(string name, string name2,string name3, string name4)
    {
        Title = name;
        Position = name2;
        Type = name3;
        FilePath = name4;

    }
}



public class LeituraParam : MonoBehaviour
{	

	List<objetos>Objs = new List<objetos>(0);
	public List<Sprite>SpritesBotoes = new List<Sprite>(0);
    public Sprite Fundo;
    public GameObject LocalFundo;
	public Sprite bt;
	public List<GameObject> GSs;
	public List<GameObject> BotoesObjetos;
    public List<GameObject> BotoesVegetacao;
	public Texture2D tex;

	private string theWholeFileAsOneLongString;
 	private List<string> eachLine;
 	private DragMeMenu scriptElem;
	
    // Start is called before the first frame update
    void Start()
    {	

        TextAsset arq = Resources.Load<TextAsset>("lista");



        Debug.Log(arq.text);
        theWholeFileAsOneLongString = arq.text;
        int i=0;
        //int j=0;
         eachLine = new List<string>();
         eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]) );
         //Debug.Log(eachLine[0]);
         //Debug.Log(eachLine[1]);

    	foreach(string line in eachLine)
		{   
            if (line == ""){
                break;
            }
    	  	string[] leitura = line.Split(';');
 
            if (arq)
            {
                Sprite loco = Resources.Load(leitura[0].ToString(), typeof(Sprite)) as Sprite;

                Debug.Log(leitura[0].ToString());
                var lido = leitura[0].TrimEnd('.', 'j', 'p',  'n', 'g'); // good luck, have fun
                Debug.Log("Cortado: " + lido);
				tex = Resources.Load<Texture2D>(lido);

            }

            if( int.Parse(leitura[1]) == 0 ){ //Caso seja o BACKGROUND
                Fundo = Sprite.Create( tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width/2, tex.height/2) );
               LocalFundo.GetComponent<Image>().sprite = Fundo;
                
            }
            
            //ALTERAR - CASO NÃO TENHA A POSIÇÃO, EXCLUIR O BOTÃO E O GAMESPOT
            
            if(int.Parse(leitura[1]) == 1){ //OBJETOS 
                bt = Sprite.Create( tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width/2, tex.height/2) );
                SpritesBotoes.Add(bt);

                //Para imagens com local específico
                BotoesObjetos[int.Parse(leitura[2])].transform.GetChild(0).GetComponent<DragMeMenu>().spot = GSs[int.Parse(leitura[2])]; //atribui ao botão qual seu GameSpot referente
                BotoesObjetos[int.Parse(leitura[2])].transform.GetChild(0).GetComponent<Image>().sprite = SpritesBotoes[i];
                GSs[int.Parse(leitura[2])].GetComponent<DropMeMenu>().respectiveImage[0] = BotoesObjetos[int.Parse(leitura[2])].transform.GetChild(0).gameObject;//atribui ao GameSpot qual seu botão/imagem referente
                i +=1;
            }
            
            if(int.Parse(leitura[1]) == 2){ //VEGETAÇÃO
                bt = Sprite.Create( tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width/2, tex.height/2) );
                SpritesBotoes.Add(bt);

                //Para imagens com local específico
                BotoesVegetacao[int.Parse(leitura[2])].transform.GetChild(0).GetComponent<DragMeMenu>().spot = GSs[int.Parse(leitura[2])]; //atribui ao botão qual seu GameSpot referente
                BotoesVegetacao[int.Parse(leitura[2])].transform.GetChild(0).GetComponent<Image>().sprite = SpritesBotoes[i];
                GSs[int.Parse(leitura[2])].GetComponent<DropMeMenu>().respectiveImage[0] = BotoesVegetacao[int.Parse(leitura[2])].transform.GetChild(0).gameObject;//atribui ao GameSpot qual seu botão/imagem referente
                i +=1;
            }

		}

        foreach(GameObject botao in BotoesObjetos) // Se não possuir imagem associada não da display
        {  
            if(botao.transform.GetChild(0).GetComponent<DragMeMenu>().spot == null){
                Debug.Log("spot nulo");
                botao.SetActive(false);
            }
        }

        foreach(GameObject botao in BotoesVegetacao) // Se não possuir imagem associada não da display
        {  
            if(botao.transform.GetChild(0).GetComponent<Image>().sprite == null){
                botao.SetActive(false);
            }
        }
		
    }

    
    // Update is called once per frame
    void Update()
    {
        
    } 
} 
