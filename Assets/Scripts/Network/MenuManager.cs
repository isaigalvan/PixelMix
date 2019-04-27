using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviourPunCallbacks
{
    //[SerializeField] Fuerza a Unity a serializar un campo privado.
    //[Tooltip()] Especifica una información sobre herramientas para un campo en la ventana del Inspector.

    [Tooltip("UI del panel de crear nickname y concectarse a una sala")]
    [SerializeField]
    private GameObject userNameScreen, connectScreen, selectScreen;

    [Tooltip("UI del botón de crear nickname")]
    [SerializeField]
    private GameObject createUserNameButton;

    [Tooltip("UI de la caja de texto de crear sala, unirse a una sala y del nickname")]
    [SerializeField]
    private TMP_InputField userNameInput, createRoomInput, joinRommInput;

    /// <summary>
    /// La funcion awake es una funcion especial de Unity que se usa para inicializar 
    /// cualquier variable o estado del juego antes de que comience el juego.
    /// </summary>
    private void Awake()
    {
        //Usa los valores del Script de las configuraciones del servidor
        PhotonNetwork.ConnectUsingSettings();
    }

    /// <summary>
    /// Se llama cuando el cliente está conectado al servidor maestro y está listo para el emparejamiento y otras tareas.
    /// Aquí es donde Photon crea un lobby por defecto en el servidor.
    /// </summary>
    public override void OnConnectedToMaster()
    {
        Debug.Log("__________Conectando al servidor__________");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    /// <summary>
    /// Esta función es llamada cuando el jugador entra en un lobby del servidor maestro. 
    /// Una vez creado el lobby activa el panel donde el usuario escribe su nickname.
    /// </summary>
    public override void OnJoinedLobby()
    {
        Debug.Log("__________Conectando al Lobby_____________");
        userNameScreen.SetActive(true); 
    }

    /// <summary>
    /// Esta función es llamada cuando LoadBalancingClient entró a una sala
    /// sin importar si este cliente la creó o simplemente se unió.
    /// Una vez unido en una sala se manada llamar la escena del juego
    /// </summary>
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(12);
    }

    /// <summary>
    /// Es una función especial de photon que permite al desarrollador 
    /// saber si la desconexión con el servidor fue por un fracaso o por un error intecional.
    /// El motivo de esta desconexión se proporciona como DisconnectCause.
    /// </summary>
    /// <param name="cause"></param>
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("__________Se ha desconectado el servidor a causa de {0}__________", cause);
    }

    #region UIMethots
    /// <summary>
    /// Funcion que se encarga de controlar el botón donde se ingresa el nickname.
    /// Una vez presionado el botón Photon se encargará de almacenar lo que se escribió en la caja de texto y 
    /// despues se desactivara el panel actual para así pasar al panel donde el usuario se conecta a una sala.
    /// </summary>
    public void OnClick_CreateNameButton()
    {
        PhotonNetwork.NickName = userNameInput.text;
        userNameScreen.SetActive(false);
        connectScreen.SetActive(true);
    }

    /// <summary>
    /// Funcion que se encarga de controlar la caja de texto del nickname.
    /// Cuando el usuario ingresa un nickname menor a 2 caracteres al desactiva el botón donde ingresa el nickname.
    /// </summary>
    public void OnNameInputfield_Changed()
    {
        if (userNameInput.text.Length >=2)
        {
            createUserNameButton.SetActive(true);
        }
        else
        {
            createUserNameButton.SetActive(false); 
        }
    }

    /// <summary>
    /// Funcion que se encarga de controlar el botón de unirse a una sala
    /// Una vez presionado el botón Photon se encargará de crear una sala con las caracteristicas dadas por la variable room
    /// para posteriormente unir al usuario automaticamente a la sala con el nombre que se escribió en la caja de texto
    /// </summary>
    public void OnClick_JoinRoom()
    {
        RoomOptions room = new RoomOptions();
        room.MaxPlayers = 4;

        //PhotonNetwork.JoinOrCreateRoom(joinRommInput.text, room, TypedLobby.Default);
        PhotonNetwork.JoinRoom(joinRommInput.text);
    }

    /// <summary>
    /// Funcion que se encarga de controlar el botón de crear una sala
    /// Una vez presionado el botón Photon se encargará de crear una sala con las caracteristicas dadas por la variable room
    /// </summary>
    public void OnClick_CreateRoom()
    {
        RoomOptions room = new RoomOptions();
        room.MaxPlayers = 4;

        PhotonNetwork.CreateRoom(createRoomInput.text, room, null);
    }

    public void OnClick_CloseGame()
    {
        Application.Quit();
        Debug.Log("__________Se ha cerrado el juego__________");
    }
    #endregion
}
