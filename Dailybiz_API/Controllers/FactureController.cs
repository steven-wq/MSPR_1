using Dailybiz_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Dailybiz_API.Controllers
{
    public class FactureController : Controller
    {
        // GET v1/factures/{codeclient}
        public string GetFacture(string CodeClient)
        {
            Facture facture = new Facture { };

            String session = "";
            session = API.idev.authentification1("mathiasapi", "mathias.hue@hotmail.com", "Lenny27");
            API.idev.SessionIDHeaderValue = new com.dailybiz.exe.SessionIDHeader();
            API.idev.SessionIDHeaderValue.SessionID = session;
            string reponse = API.idev.LireTable("FA_FACTURE", "CodeFournisseur=" + CodeClient + "", "", "0", "0", "0");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(reponse);
            XmlNodeList elem = doc.GetElementsByTagName("FICHE");

            for (int i = 0; i < elem.Count; i++)
            {
                facture = new Facture
                {
                    RefClient = elem[i]["REFCLIENT"].InnerText,
                    CodeClient = elem[i]["CODECLIENT"].InnerText,
                    RaisonSociale = elem[i]["NOM"].InnerText,
                    Adresse1 = elem[i]["ADRESSE1"].InnerText,
                    Adresse2 = elem[i]["ADRESSE2"].InnerText,
                    Adresse3 = elem[i]["ADRESSE3"].InnerText,
                    Ville = elem[i]["VILLE"].InnerText,
                    CP = elem[i]["CP"].InnerText,
                    Pays = elem[i]["PAYS"].InnerText,
                    Tel = elem[i]["TEL"].InnerText,
                    Email = elem[i]["EMAIL"].InnerText,
                    CodeAPE = elem[i]["CODEAPE"].InnerText,
                    Web = elem[i]["WEB"].InnerText,
                    CompteComptable = elem[i]["COMP_COMPTABLE"].InnerText
                };

            }

            //client.Contacts = ListeContacts(client);
            string json = JsonConvert.SerializeObject(facture, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

    }
}
