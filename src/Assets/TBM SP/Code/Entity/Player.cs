using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player:MonoBehaviour{
 public SpriteRenderer renderer;
 public float Speed=1;
 public float SpeedUp=4;
 public float JumpSpeed=2;
 public float Gravity=2;
 public bool IsBig=false;
 public Sprite[] Idle,Walk;
 public Sprite[] BigIdle,BigWalk;
 private float Velocity,Fall;
 public float VerticalVelocity=1;
 private int HorizontalDirection=0;
 private Sprite[] CurrentAnim;
 private int AnimState=-1;
 private float animclock;
 private int CurrentSprite;
 private static Transform p;
 private bool Jump,IsGround;
 private Vector3 pos, newPos;
 public static Transform GetTransform(){return p;}
void Start(){
p=this.transform;    
SetAnim(0,IsBig);  
IsGround=true;  
}
void Update(){
var pos=transform.position;
if(Input.GetKeyDown(KeyCode.Space)&&IsGround){
VerticalVelocity-=JumpSpeed;
Jump=true;
IsGround=false;
}
if (Input.GetKey(KeyCode.A)){
HorizontalDirection=-1;
}else 
if(Input.GetKey(KeyCode.D)){
HorizontalDirection=1;    
}else{
HorizontalDirection=0;    
}
//Collisions   
RaycastHit hit;
var O=0.5f;
if(IsBig){O=1;}
var Origin=pos+new Vector3(0,O,0);
if(Physics.Raycast(Origin,Vector3.right*HorizontalDirection,out hit,0.4f)){
if(hit.transform.tag=="Solid"){
HorizontalDirection=0;
Velocity=0;
}
}
var Origin2=pos+new Vector3(0,1,0);
var O2=1f;
if(Mathf.Sign(VerticalVelocity)<=0){  
Origin2=pos+new Vector3(0,0.5f,0);
O2=0.5f;
}
VerticalVelocity+=Time.deltaTime*Gravity;
pos.y-=VerticalVelocity*Time.deltaTime;
if(Physics.Raycast(Origin2-new Vector3(0.3f,0),Vector3.down*Mathf.Sign(VerticalVelocity),out hit,O2)||Physics.Raycast(Origin2+new Vector3(0.3f,0),Vector3.down*Mathf.Sign(VerticalVelocity),out hit,O2)){
if(Mathf.Sign(VerticalVelocity)>=0){
if(hit.transform.tag=="Solid"){
if(!IsGround){
IsGround=true;
Jump=false;
pos.y=hit.transform.position.y+0.5f;
}else{
pos.y=hit.transform.position.y+0.5f;
VerticalVelocity=0;
}
}
}else{
pos.y=hit.transform.position.y-(O+1);
VerticalVelocity=0;
if(hit.transform.GetComponent<CoinBlock>()!=null){
hit.transform.SendMessage("Act");
}
}
}
//Collisions
if(VerticalVelocity>=15){VerticalVelocity=15;}
Velocity=Mathf.MoveTowards(Velocity,HorizontalDirection,SpeedUp*Time.deltaTime);
pos.x+=(Speed*Velocity)*Time.deltaTime;
transform.position=pos;
if(HorizontalDirection==1){
renderer.flipX=false;
}else
if(HorizontalDirection==-1){
renderer.flipX=true;
}
transform.position=pos;
if(Velocity!=0){
SetAnim(1,IsBig);
}else
    {
        SetAnim(0,IsBig);

    }
     animclock+=Time.deltaTime*(Mathf.Abs(Velocity))*(Speed*3);
     
     if(animclock>=1)
    {
        CurrentSprite+=1;
        
        animclock=0;
    }
     if(CurrentSprite>=CurrentAnim.Length)
     {
         CurrentSprite=0;
     }
     renderer.sprite=CurrentAnim[CurrentSprite];
    }
    void SetAnim(int state,bool big)
    {
        if(state!=AnimState)
        {  
            CurrentSprite=0;
            animclock=0;
            if(state==0&&!big){CurrentAnim=Idle;}
            if(state==0&&big){CurrentAnim=BigIdle;}
            if(state==1&&!big){CurrentAnim=Walk;}
            if(state==1&&big){CurrentAnim=BigWalk;}
            
            AnimState=state;
        } 
    }
}

