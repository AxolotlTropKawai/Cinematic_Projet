using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;

public class LaunchSound : MonoBehaviour
{
    //[Range(60, 71)]
    //public int soundToPlay;

    public DrumElements drumElement = DrumElements.Grosse_Caisse;

    // 60 : Grosse caisse
    // 61 : Caisse claire
    // 62 : Tom alto
    // 63 : Tom medium
    // 64 : Tom basse
    // 65 : CP
    // 66 : Rimshot
    // 67 : Cow bell
    // 68 : Charleston fermee
    // 69 : Charleston ouverte
    // 70 : Cymbale Ride
    // 71 : Cymbale Crash
    public enum DrumElements
    {
        Grosse_Caisse = 60,
        Caisse_Claire,
        Tom_Alto,
        Tom_Medium,
        Tom_Basse,
        Clap,
        Rimshot,
        Cow_Bell,
        Charleston_Fermee,
        Charleston_Ouverte,
        Cymbale_Ride,
        Cymbale_Crash
    }

    private Sampler drumSampler;

    private void Awake()
    {
        drumSampler = GameObject.Find("Drum Sampler").GetComponent<Sampler>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(drumSampler)
        {
            //drumSampler.NoteOn(soundToPlay, 1.0f);
            drumSampler.NoteOn((int)drumElement, 1.0f);
            if (collision.gameObject.GetComponent<BallBehavior>().shouldBeDestroyedOnHit)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
