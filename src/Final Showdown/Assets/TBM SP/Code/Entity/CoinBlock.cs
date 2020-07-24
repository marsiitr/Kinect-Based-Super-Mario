using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock:MonoBehaviour{
public float AnimSpeed=2;
public Sprite[] Anim;
public Sprite DisableBlock;
private float animclock;
private int CurrentSprite;
private bool act,act2;
private Vector2 startPos;
void Start(){
startPos=transform.position;
}
public void Act(){
if(!act){
var render=GetComponent<SpriteRenderer>();
act=true;
render.sprite=DisableBlock;
GameManager.SpawnEntity(2,startPos);
}
}
void Update(){
if(!act){
var render=GetComponent<SpriteRenderer>();
animclock+=Time.deltaTime*AnimSpeed;
if(animclock>=1){
CurrentSprite+=1;
animclock=0;
}
if(CurrentSprite>=Anim.Length){
CurrentSprite=0;
}
render.sprite=Anim[CurrentSprite];
}/*else{
if(!act2){
transform.position=Vector3.MoveTowards(transform.position,startPos+new Vector3(0,0.2f),5*Time.deltaTime);
if(!act2 && transform.position==startPos + new Vector3(0,0.2f)){
act2=true;
}}
if(act2){
transform.position=Vector3.MoveTowards(transform.position,startPos,5*Time.deltaTime);
}
}*/
}
}
