using UnityEngine;
using UnityEngine.UI;

public class GoTo : MonoBehaviour
{
    public GameObject Barra;
    public GameObject Positions;
    public GameObject mensaje;
    public PathManager pathManager; // Reference to the PathManager

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnGoToClicked);
    }

    private void OnGoToClicked()
    {
        Text childText = Barra.transform.Find("NombreEdiBarra")?.GetComponent<Text>();
        if (childText == null)
        {
            Debug.LogError("GoTo: No Text component found on NombreEdiBarra");
            return;
        }

        string buildingName = childText.text;
        Debug.Log("GoTo: Attempting to navigate to " + buildingName);
        mensaje.SetActive(false);

        Transform targetTransform = null;
        switch (buildingName)
        {
            case "Pabellon 3":
                targetTransform = Positions.transform.Find("Pabellon 3");
                break;
            case "Pabellon 1":
                targetTransform = Positions.transform.Find("Pabellon 1");
                break;
            case "Pabellon 2":
                targetTransform = Positions.transform.Find("Pabellon 2");
                break;
            case "Exactas":
                targetTransform = Positions.transform.Find("Exactas");
                break;
            case "Humanas":
                targetTransform = Positions.transform.Find("Humanas");
                break;
            case "Economicas":
                targetTransform = Positions.transform.Find("Economicas");
                break;
            case "Veterinaria":
                targetTransform = Positions.transform.Find("Veterinaria");
                break;
            case "Exactas/Pabellon 4":
                targetTransform = Positions.transform.Find("Exactas/Pabellon 4");
                break;
            case "Kiosco Economicas":
                targetTransform = Positions.transform.Find("Kiosco Economicas");
                break;
            case "Boxes de Investigación":
                targetTransform = Positions.transform.Find("Boxes de Investigación");
                break;
            case "Boxes de Investigación II":
                targetTransform = Positions.transform.Find("Boxes de Investigación II");
                break;
            case "IFIMAT":
                targetTransform = Positions.transform.Find("IFIMAT");
                break;
            case "ISISTAN":
                targetTransform = Positions.transform.Find("ISISTAN");
                break;
            case "PLADEMA":
                targetTransform = Positions.transform.Find("PLADEMA");
                break;
            case "Sanidad Animal":
                targetTransform = Positions.transform.Find("Sanidad Animal");
                break;
            case "Colectivos":
                targetTransform = Positions.transform.Find("Colectivos");
                break;
            case "Comedor":
                targetTransform = Positions.transform.Find("Comedor");
                break;
            case "Pabellon Veterinaria":
                targetTransform = Positions.transform.Find("Pabellon Veterinaria");
                break;
            case "Departamento de Producción Animal":
                targetTransform = Positions.transform.Find("Departamento de Producción Animal");
                break;
            case "Tecnología Alimentaria":
                targetTransform = Positions.transform.Find("Tecnología Alimentaria");
                break;
            case "Biblioteca":
                targetTransform = Positions.transform.Find("Biblioteca");
                break;
            case "Banco Santander":
                targetTransform = Positions.transform.Find("Banco Santander");
                break;
            default:
                Debug.LogError("GoTo: No matching case for " + buildingName);
                break;
        }

        if (targetTransform != null)
        {
            pathManager.SetTarget(targetTransform, this);
        }
        else
        {
            DisplayMessage(false);
        }
    }

    public void DisplayMessage(bool success)
    {
        mensaje.SetActive(true);
        if (success)
        {
            mensaje.GetComponentInChildren<Text>().text = "El camino ha sido marcado en su minimapa!";
        }
        else
        {
            mensaje.GetComponentInChildren<Text>().text = "Por favor, asegúrese de estar en una vereda!";
        }
    }
}
