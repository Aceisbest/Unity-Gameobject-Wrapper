using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectWrapper 
{
    //This lets you set the pos of the gameobject very simple 
        public static void Moveobject(GameObject ThisObject, float X, float Y, float Z = 0) 
        {
        if(ThisObject != null) { ThisObject.transform.position = new Vector3(X, Y, Z); } else { return; }
        }

    // This checks if the object is on or now, if its null(it isn't found) it comes out as false
        public static bool IsObjectActive(this GameObject Object) 
        { 
          if(Object == null) { return false; }

          if(Object.activeInHierarchy) { return true; } else { return false; }
        }

    // This prints the name of the Game object
        public static void GetName(this GameObject Object) 
        { 
        if (Object != null) { Debug.Log($"The name of this object is: {Object.name}"); }      
        }

        // This just Destroys the Gameobject
       public static void DestroyObject(this GameObject Object) { if (Object != null) { GameObject.Destroy(Object); } }
    
    // This encodes the name of a Gameobject (idk why you would need this)
        public static void EncodeGameObjectName(this GameObject Object) 
        { 
         

            if(Object != null) 
            {
            var EncodedName = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Object.name));

             Debug.Log($"Encoded name of {Object.name} is {EncodedName}");
            } 
            else { return; }

        }

    // This lets you swap the material of your Gameobject
        public static void SwapMaterial(this GameObject Object, Material NewMat) 
        {
           Renderer GameObjectRen;

          if(Object != null)  { GameObjectRen =  Object.GetComponent<Renderer>(); GameObjectRen.material = NewMat; } else { return; }
       
        }

    // This lets you swap the shader of a Gameojects material
        public static void SwapShader(this GameObject Object, Shader NewShader)
        {
        Renderer GameObjectRen;

        if (Object != null) { GameObjectRen = Object.GetComponent<Renderer>();  GameObjectRen.material.shader = NewShader; } else { return; }

        }

     // This lets you get or add a componet to your Gameoject, I didn't code this one lol 
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
        T component = gameObject.GetComponent<T>();
        if (component == null)
            {
            return gameObject.AddComponent<T>();
            }
        return component;
        }
     
         // This just gets the position of the Gameobject and gives you a string of it
        public static string GetPos(this GameObject Object) 
        {
         return Object.transform.position.ToString();
        }
    }
