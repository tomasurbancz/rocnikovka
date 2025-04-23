using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordTrainingObject : MonoBehaviour
{
    public Image Image;
    public Image Collision;
    public int CollisionKey;
    public TrainingObjectType TrainingObject;
    public enum TrainingObjectType
    {
        Apple,
        Star
    }

    public static SwordTrainingObject Create(Image imageToClone, Image collision, int collisionKey, TrainingObjectType trainingObjectType)
    {
        GameObject appleObject = new GameObject("Apple");
        SwordTrainingObject trainingObject = appleObject.AddComponent<SwordTrainingObject>();

        trainingObject.Image = Instantiate(imageToClone, imageToClone.transform.parent);
        trainingObject.Image.transform.position = imageToClone.transform.position;
        trainingObject.Image.transform.localScale = imageToClone.transform.localScale;
        trainingObject.Image.color = new Color(trainingObject.Image.color.r, trainingObject.Image.color.g, trainingObject.Image.color.b, 1);

        trainingObject.Collision = collision;
        trainingObject.CollisionKey = collisionKey;
        trainingObject.TrainingObject = trainingObjectType;

        return trainingObject;
    }
}
