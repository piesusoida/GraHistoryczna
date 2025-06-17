using UnityEngine;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
	private int x_left = -150;
	private int x_right = 270;
	private int y = -40;

    // Zmienna przechowująca numer aktualnej strony
    private int currentPage = 1;  // Zaczynamy od strony 1

    // Zmienna do przechowywania wszystkich paneli (stron) w UI
    public GameObject[] pages;  // Tablica obiektów, które reprezentują strony

    // Funkcja wywoływana przy naciśnięciu przycisku
    public void NextPage()
    {
    	// Ukrywamy wszystkie strony
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
        }
        
        // Zwiększamy numer strony
        currentPage++;
        
        // Upewnij się, że nie przekroczyliśmy liczby stron
        if ((currentPage-1)*2 >= pages.Length)
        {
            currentPage--;  // Jeśli nie mamy więcej stron, wracamy do poprzedniej
        }
        

        // Pokazujemy stronę o numerze currentPage
        pages[(currentPage-1)*2].SetActive(true);
        if(((currentPage-1)*2+1) < pages.Length){
        	pages[(currentPage-1)*2+1].SetActive(true);
        }
    }
    
    // Funkcja wywoływana przy naciśnięciu przycisku
    public void PreviousPage()
    {
    	// Ukrywamy wszystkie strony
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
        }
        
        // Zmiejszamy numer strony
        currentPage--;
        
        // Upewnij się, że nie przekroczyliśmy liczby stron
        if (currentPage < 1)
        {
            currentPage++;  // Jeśli nie mamy więcej stron, wracamy do poprzedniej
        }
        

        // Pokazujemy stronę o numerze currentPage
        pages[(currentPage-1)*2].SetActive(true);
        if(((currentPage-1)*2+1) < pages.Length){
        	pages[(currentPage-1)*2+1].SetActive(true);
        }
       
    }


    // Funkcja na początek, aby wyświetlić stronę 1 na początku
    void Start()
    {
    	int i=0;
        // Ukrywamy wszystkie strony
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
            if(i%2 == 0) {
            	page.GetComponent<RectTransform>().anchoredPosition = new Vector2(x_left, y); // lewa strona
            } else {
            	page.GetComponent<RectTransform>().anchoredPosition = new Vector2(x_right, y); // prawa strona
            }
            i++;
        }

        // Pokazujemy stronę 1
        pages[0].SetActive(true);
        
        if (pages.Length > 1) {
        	pages[1].SetActive(true);
        }
    }
}

