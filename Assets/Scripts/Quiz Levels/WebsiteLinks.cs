using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebsiteLinks : MonoBehaviour
{
	public Button WHO, CDC, SACovid19,NICD;


	void Start(){
		WHO.onClick.AddListener(delegate {openLink("https://www.who.int/emergencies/diseases/novel-coronavirus-2019/question-and-answers-hub"); });
		CDC.onClick.AddListener(delegate {openLink("https://www.cdc.gov/coronavirus/2019-ncov/index.html"); });
		SACovid19.onClick.AddListener(delegate {openLink("https://www.gov.za/coronavirus/faq"); });
		NICD.onClick.AddListener(delegate {openLink("https://www.nicd.ac.za/diseases-a-z-index/covid-19/frequently-asked-questions/"); });
	}


    public void openLink(string link){
            Application.OpenURL(link);
    	}
    	
        	
    
}

