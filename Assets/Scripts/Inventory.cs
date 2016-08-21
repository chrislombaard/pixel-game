using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class Inventory : MonoBehaviour {
	GameObject inventoryUI;
	GameObject slotPanel;
	ItemDatabase database;
	public GameObject inventoryItem;
    public bool showInventory;
    private GameObject canvas;
    public EventSystem eventSystem;
	private InventoryUI inventoryUIObjects;
	public GameObject[] itemPrefabs;

	int inventorySize = 4;
	int equipSize;
	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();

	void Start(){
		
		inventorySize = 4;
		database = GetComponent<ItemDatabase> ();
		inventoryUI = GameObject.Find ("Inventory UI");
		slotPanel = inventoryUI.transform.FindChild ("Slot Panel").gameObject;
		inventoryUIObjects = inventoryUI.GetComponent<InventoryUI> ();

		for (int i = 1; i <= inventorySize; i++) {
			items.Add (new Item());
			//slots.Add (slotPanel.transform.FindChild ("Item_" + i).gameObject);
		}
        
		AddItemNew (0);
		AddItemNew (1);
		AddItemNew (2);
		AddItemNew (3);


		SetEmptySlotsImages ();
	}
    
    
    void Update(){
        if(inventoryUI.GetComponent<InventoryUI>().isShowing)
            inventoryUI.transform.FindChild("Item Description").GetComponent<Text>().text = eventSystem.currentSelectedGameObject.GetComponent<ItemData>().item.Description;
    }
    
	public void PrintItems(){
		for(int i = 0; i < items.Count; i++){
			Debug.Log (items[i].ID);
		}
	}
		
	public void UseItem(int id){
		if (inventoryUI.GetComponent<InventoryUI> ().isShowing && items[id].ID != -1) {
			Debug.Log ("Used item " + id);
		}
	}

	public void DropItem(int index){
        int value = Random.Range(10, 20);
       
        
        Debug.Log("Index: " + index);
		int id = items [index].ID;
        Debug.Log("ID: " + index);
        
		if (index > 0) {
			eventSystem.SetSelectedGameObject (slots [index - 1]);
		}
		items [index] = new Item ();
		SetEmptySlotsImages ();
		GameObject tmp = (GameObject)Instantiate(itemPrefabs[id], new Vector2(GameObject.Find ("Player").transform.position.x + 5 + id + value, GameObject.Find ("Player").transform.position.y), GameObject.Find ("Player").transform.rotation);
		tmp.GetComponent<ItemData> ().item = database.FetchItemByID (id);
        tmp.name = tmp.GetComponent<ItemData> ().item.Title;
    
         
	}


	public void AddItemNew(int id){
		Color color;
		Item itemToAdd = database.FetchItemByID (id);
		SpriteState st = new SpriteState();

		for (int i = 0; i < items.Count; i++) {
			if (items [i].ID == -1) {
				items [i] = itemToAdd;
				slots[i].GetComponent<ItemData>().item = itemToAdd;
                slots[i].GetComponent<ItemData>().index = i;
				slots[i].name = itemToAdd.Title;
				slots [i].GetComponent<Button> ().transition = Selectable.Transition.SpriteSwap;
				slots[i].GetComponent<Image> ().sprite = itemToAdd.Sprite;
				st.highlightedSprite = itemToAdd.SpriteTransition;

				slots[i].GetComponent<Button> ().spriteState = st;
				color = slots [i].GetComponent<Image> ().color;
				color.a = 1f;
				slots [i].GetComponent<Image> ().color = color;
				slots [i].GetComponent<Button> ().interactable = true;
                

				//slots [i].name = itemToAdd.Title + " Slot";
				break;
				//itemObj.transform.position = Vector2.zero; // Position is relative to its parent
			}
		}
	}
		
	public void SetEmptySlotsImages(){
		Color color;

		for(int i = 0; i < inventorySize; i++){
			if (items [i].ID == -1){
				color = slots [i].GetComponent<Image> ().color;
				color.a = 0f;
				slots [i].GetComponent<Image> ().color = color;
				slots [i].GetComponent<Button> ().interactable = false;
			}
		}
	}

	public void AddItem(int id){
		Item itemToAdd = database.FetchItemByID (id);

		if (itemToAdd.Stackable && CheckIfItemIsInInventory (itemToAdd)) {
			for (int i = 0; i < items.Count; i++) {
				if (items [i].ID == itemToAdd.ID) {
					ItemData data = slots [i].transform.GetChild (0).GetComponent<ItemData> ();
					data.amount++;
					data.transform.GetChild (0).GetComponent<Text> ().text = data.amount.ToString ();
					break;
				}
			}
		} else {

			for (int i = 0; i < items.Count; i++) {
				if (items [i].ID == -1) {
					items [i] = itemToAdd;
					GameObject itemObj = Instantiate (inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
					itemObj.transform.SetParent (slotPanel.transform, false);
					itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;
					itemObj.name = itemToAdd.Title;
					//slots [i].name = itemToAdd.Title + " Slot";
					break;
					//itemObj.transform.position = Vector2.zero; // Position is relative to its parent
				}
			}
		}
	}

	bool CheckIfItemIsInInventory(Item item){
		for (int i = 0; i < items.Count; i++) {
			if(items[i].ID == item.ID){
				return true;
			}
		}

		return false;
	}
}
