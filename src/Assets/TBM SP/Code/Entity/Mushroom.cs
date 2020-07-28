using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom:MonoBehaviour{
private int Horizontal;
private Vector3 startPos;
private float VerticalVelocity;
private bool init,hpos;
void Start(){
startPos=transform.position;
}
void Update(){
if(!init){
transform.position=Vector3.MoveTowards(transform.position,startPos+new Vector3(0,1),2*Time.deltaTime);
if(transform.position==startPos+new Vector3(0,1)){
init=true;
}
}else{
var pos=transform.position;
if(!hpos){
var playerPosX=Player.GetTransform().position.x;
if(playerPosX<transform.position.x){
Horizontal=-1;
}else{
Horizontal=-1;
}
hpos=true;
}
RaycastHit hit;
if(Physics.Raycast(transform.position,Vector3.right*Horizontal,out hit,0.4f)){
if(hit.transform.tag=="Solid"){
Horizontal=-Horizontal;
}
}
pos.y-=VerticalVelocity*Time.deltaTime;
if(Physics.Raycast(pos-new Vector3(0.3f,0),Vector3.down,out hit,0.5f)||Physics.Raycast(pos+new Vector3(0.3f,0),Vector3.down,out hit,0.5f)){
if(hit.transform.tag=="Solid"){
    pos.y=hit.transform.position.y+1;
    VerticalVelocity=0;
}   
}
pos.y-=VerticalVelocity*Time.deltaTime;
transform.position=pos;
}
}
}

