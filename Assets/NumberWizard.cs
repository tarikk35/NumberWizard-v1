using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {
    int max, min,oncekiTahmin,tahmin,tahminSayisi;
    enum oyunDurumu
    {
        Baslamadi,
        Basladi,
        Hileci
    };
    oyunDurumu durum = oyunDurumu.Baslamadi;

	// Use this for initialization
	void Start () {

        max = 1000;
        min = 1;
        tahmin = 500;
        tahminSayisi = 0;
        
        Debug.Log("Sayi sihirbazina hosgeldin .");
        Debug.Log("Aklından bir sayı tut , ama bana söyleme .");
        Debug.Log("Tuttuğun sayı "+min+" ile "+max+" arasında olsun .");
        Debug.Log("Hazır olduğunda klavyenden ENTER tuşuna bas. ");
	}
	void SonrakiTahmin()
    {
        tahmin = (max + min) / 2;
        Debug.Log("Tuttuğun sayı " + tahmin + "den büyükse YUKARI OK, küçükse AŞAĞI OK tuşuna bas. Tahminim doğruysa ENTER tuşuna bas .");
        tahminSayisi++;
    }

	// Update is called once per frame
	void Update () {
        
        if (durum == oyunDurumu.Basladi&&Input.anyKeyDown)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                oncekiTahmin = tahmin;
                min = tahmin;
                SonrakiTahmin();
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                oncekiTahmin = tahmin;
                max = tahmin;
                SonrakiTahmin();
            }
            else if(Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Tuttuğun sayıyı bildim !");
                UnityEditor.EditorApplication.isPlaying = false;
            }
            if (oncekiTahmin == (min + max) / 2)
                durum=oyunDurumu.Hileci;              
        }
        else if (durum == oyunDurumu.Hileci)
        {
            Debug.Log("HİLECİ !");
        }
        else if (Input.GetKeyDown(KeyCode.Return) && durum==oyunDurumu.Baslamadi)
        {
            Debug.Log("Demek hazırsın . ");
            SonrakiTahmin();
            durum = oyunDurumu.Basladi;
        }
            

	}
}
