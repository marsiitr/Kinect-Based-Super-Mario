using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
public Transform[] Entities;
private static Transform p;
public static Transform GetTransform(){return p;}
public static GameManager GetComponent(){return p.GetComponent<GameManager>();}
void Awake(){
p=this.transform;
}
void Start(){}
void Update(){}
public static Transform SpawnEntity(int ID,Vector3 pos){
var entity=Instantiate(GetComponent().Entities[ID],pos,Quaternion.identity) as Transform;
return entity;
}
}
