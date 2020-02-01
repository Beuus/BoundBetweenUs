using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRope : MonoBehaviour
{
    public GameObject fixedNodeOne;
    public GameObject fixedNodeTwo;
    public GameObject sprite;
    public GameObject hingeNode;

    public float breakDistance=10;
    public float[] distanceByLevel;
    public int ropeLives=2;
    public float compressFactor=1;

    public bool isBreak = false;
    public bool isUnbreakable = false;

    public Color[] colorsByHit;
    public float brightFactor;

    private float sizeSprite;
    private float numberOfSprite;
    private int lives = 0;

    private List<GameObject> nodes;
    private List<HingeJoint2D> springs;

    private float oldDistance;
    private float newDistance;
    private int side = 1;
    private string nameCollision;

    private void Start()
    {
        breakDistance = distanceByLevel[0];
        Vector2 sizeBox = sprite.GetComponent<BoxCollider2D>().bounds.size;
        sizeSprite = sizeBox.x;

        oldDistance = Mathf.Abs(fixedNodeOne.transform.position.x - fixedNodeTwo.transform.position.x);

        numberOfSprite = Mathf.Abs(fixedNodeOne.transform.position.x - fixedNodeTwo.transform.position.x)/sizeSprite;
        numberOfSprite = Mathf.Ceil(numberOfSprite);

        nodes = new List<GameObject>();
        springs = new List<HingeJoint2D>();

        nodes.Add(Instantiate(hingeNode, fixedNodeOne.transform.position + new Vector3(sizeSprite/2, 0, 0), Quaternion.identity, this.transform));
        nodes.Add(Instantiate(hingeNode, fixedNodeTwo.transform.position - new Vector3(sizeSprite/2, 0, 0), Quaternion.identity, this.transform));

        springs.Add(nodes[0].GetComponent<HingeJoint2D>());
        springs.Add(nodes[1].GetComponent<HingeJoint2D>());

        springs[0].connectedBody = fixedNodeOne.GetComponent<Rigidbody2D>();
        springs[1].connectedBody = fixedNodeTwo.GetComponent<Rigidbody2D>();

        springs[0].anchor = -new Vector3(sizeSprite/2, 0, 0);
        springs[1].anchor =  new Vector3(sizeSprite/2, 0, 0);
        Debug.Log(nodes[0].transform.position);

        //nodes.Add(Instantiate(hingeNode, nodes[0].transform.position + new Vector3(sizeSprite, 0, 0), Quaternion.identity, this.transform));
        //springs.Add(nodes[1].GetComponent<HingeJoint2D>());
        //springs[1].connectedBody = nodes[0].GetComponent<Rigidbody2D>();
        //springs[1].anchor =  new Vector3(sizeSprite, 0, 0);
        int length = Mathf.FloorToInt((numberOfSprite - 2) / 2);
        for (int i = 0; i < length; i++)
        {
            nodes.Add(Instantiate(hingeNode, nodes[i * 2].transform.position + new Vector3(sizeSprite, 0, 0), Quaternion.identity, this.transform));
            nodes.Add(Instantiate(hingeNode, nodes[i * 2 + 1].transform.position - new Vector3(sizeSprite, 0, 0), Quaternion.identity, this.transform));

            springs.Add(nodes[i * 2 + 2].GetComponent<HingeJoint2D>());
            springs.Add(nodes[i * 2 + 3].GetComponent<HingeJoint2D>());

            springs[i * 2 + 2].connectedBody = nodes[i * 2].GetComponent<Rigidbody2D>();
            springs[i * 2 + 3].connectedBody = nodes[i * 2 + 1].GetComponent<Rigidbody2D>();

            //springs[i * 2 + 2].connectedAnchor = -nodes[i * 2].transform.position + new Vector3(sizeSprite, 0, 0);
            //springs[i * 2 + 3].connectedAnchor = -nodes[i * 2 + 1].transform.position - new Vector3(sizeSprite, 0, 0);

            springs[i * 2 + 2].anchor = - new Vector3(sizeSprite, 0, 0);
            springs[i * 2 + 3].anchor =  new Vector3(sizeSprite, 0, 0);
        }

        if (numberOfSprite % 2 != 0)
        {
            nodes.Add(Instantiate(hingeNode, (nodes[nodes.Count - 1].transform.position + nodes[nodes.Count - 2].transform.position) / 2, Quaternion.identity, this.transform));
        }
        else{
            springs.RemoveAt(springs.Count - 1);
        }
        nodes[nodes.Count - 1].AddComponent<HingeJoint2D>();
        HingeJoint2D[] hinges = nodes[nodes.Count - 1].GetComponents<HingeJoint2D>();

        hinges[0].connectedBody = nodes[nodes.Count - 3].GetComponent<Rigidbody2D>();
        hinges[1].connectedBody = nodes[nodes.Count - 2].GetComponent<Rigidbody2D>();

        hinges[0].anchor = -new Vector3(sizeSprite, 0, 0);
        hinges[1].anchor = new Vector3(sizeSprite, 0, 0);

        springs.Add(hinges[0]);
        springs.Add(hinges[1]);  
        
        ChangeRopeColor(oldDistance);
    }

    private void Update()
    {
        if(!isBreak){
            UpdateRope();

            if(!isUnbreakable){
                CheckBreakRope(oldDistance);
            }
        }
    }

    private void UpdateRope(){
        newDistance = Mathf.Abs(fixedNodeOne.transform.position.x - fixedNodeTwo.transform.position.x);
        if(!isUnbreakable){
            ChangeRopeColor(newDistance);
        }
        float expandDistance = (newDistance - oldDistance);
        
        if(expandDistance > sizeSprite){
            AddNode(side);
            side = -side;
            oldDistance = newDistance;
        }
        else if(expandDistance < -sizeSprite/compressFactor){
            DeleteNode(side);
            side = -side;
            oldDistance = newDistance;
        }
    }

    private void AddNode(int side){
        if(side < 0){
            nodes.Insert(0,Instantiate(hingeNode, fixedNodeOne.transform.position + new Vector3(sizeSprite / 2, 0, 0), Quaternion.identity, this.transform));
            springs.Insert(0,nodes[0].GetComponent<HingeJoint2D>());
            springs[0].connectedBody = fixedNodeOne.GetComponent<Rigidbody2D>();
            springs[0].anchor = -new Vector3(sizeSprite / 2, 0, 0);

            springs[2].connectedBody = nodes[0].GetComponent<Rigidbody2D>();
            springs[2].anchor = -new Vector3(sizeSprite, 0, 0);
        }
        else{
            nodes.Insert(0,Instantiate(hingeNode, fixedNodeTwo.transform.position - new Vector3(sizeSprite / 2, 0, 0), Quaternion.identity, this.transform));
            springs.Insert(0,nodes[0].GetComponent<HingeJoint2D>());

            springs[0].connectedBody = fixedNodeTwo.GetComponent<Rigidbody2D>();
            springs[0].anchor = new Vector3(sizeSprite / 2, 0, 0);

            springs[2].connectedBody = nodes[0].GetComponent<Rigidbody2D>();
            springs[2].anchor = new Vector3(sizeSprite, 0, 0);
        }
    }

    private void DeleteNode(int side){
        GameObject nodeToRemove = nodes[0];

        nodes.RemoveAt(0);
        springs.RemoveAt(0);

        Destroy(nodeToRemove);
        if(side > 0){
            springs[1].connectedBody = fixedNodeOne.GetComponent<Rigidbody2D>();
            springs[1].anchor = -new Vector3(sizeSprite / 2, 0, 0);
        }
        else{
            springs[1].connectedBody = fixedNodeTwo.GetComponent<Rigidbody2D>();
            springs[1].anchor = new Vector3(sizeSprite / 2, 0, 0);
        }

    }

    private void CheckBreakRope(float distance){
        if(distance > breakDistance){
            BreakRope();
        }
    }

    private void BreakRope(){
        GameObject.Destroy(nodes[nodes.Count / 2]);
        isBreak = true;
        FindObjectOfType<GameManager>().GameOver();
    }

    public void ChangeRopeColor(float distance){
        float h, s, v;
        
        Color col = colorsByHit[lives];
        Color.RGBToHSV(col,out h,out s,out v);
        v = 1-(Mathf.InverseLerp(1, breakDistance, distance)*0.4f);

        col = Color.HSVToRGB(h, s, v);

        foreach (GameObject g in nodes)
        {
            g.GetComponent<SpriteRenderer>().color = col;
        }
    }

    public void SetWhiteColor(){
        Color col = new Color(1, 1, 1);

        foreach (GameObject g in nodes)
        {
            g.GetComponent<SpriteRenderer>().color = col;
        }
    }

    public void RopeDamage(string n){
        
        if(!string.Equals(nameCollision,n)){
            lives++;
            if(lives >= (ropeLives)){
                BreakRope();
            }
        }
        nameCollision = n;
    }

    public void UnbreakableRopeOn(){
        isUnbreakable = true;

        SetWhiteColor();
    }

    public void UnbreakableRopeOff(){
        isUnbreakable = false;
    }

    public void DecreaseDistanceRope(int level){
        breakDistance = distanceByLevel[level];
    }
}
