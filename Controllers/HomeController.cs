using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabMVC.Models;

namespace LabMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Acceuil()
        {
            return View("Acceuil");
        }

        public ActionResult Commander()
        {
            return View("Commander");
        }

        public ActionResult Confirmation
            (string TxtNom, string idClient, string txtPrenom,
             string Adresse, string Ville, string Pays, 
             string telephone, string Desc, string bDay)
        {
            ClientVO clientVO = new ClientVO();
            ClientDAO clientDAO = new ClientDAO();
            
            // Storage des informations de la commande
            clientVO.NumeroClient = Int32.Parse(idClient);
            clientVO.PrenomClient = txtPrenom;
            clientVO.NomClient = TxtNom;
            clientVO.AddresseClient = Adresse;
            clientVO.VilleClient = Ville;
            clientVO.PaysClient = Pays;
            clientVO.NumteleClient = telephone;
            clientVO.ProductDescriptionClient = Desc;
            clientVO.DateNaissanceClient = bDay;

            Object[] infos = clientDAO.sauvegardeClient(clientVO);

/*
            Il est possible d'aller chercher les informations de les inputs directement 
            mais j'utilise la methode afin de démontrer que les informations vient directement
            de la base de données 
*/
/*
            ===========================
            | AVEC LES INPUTS DU FORM |
            ===========================

            ViewData["numeroconfirmation"] = infos["orderid"];
            ViewData["memberID"] = idClient;
            ViewData["prenom"] = txtPrenom;
            ViewData["nom"] = TxtNom;
            ViewData["dob"] = bDay;
            ViewData["tele"] = telephone;
            ViewData["product"] = Desc;
            ViewData["adresse"] = infos["address"];
            ViewData["dateachat"] = infos["dateOfPurchase"];
*/
            ViewData["numeroconfirmation"]  = infos[0].ToString();
            ViewData["memberID"]            = infos[1].ToString();
            ViewData["prenom"]              = infos[2].ToString();
            ViewData["nom"]                 = infos[3].ToString();
            ViewData["dob"]                 = infos[4].ToString();
            ViewData["tele"]                = infos[5].ToString();
            ViewData["product"]             = infos[6].ToString();
            ViewData["adresse"]             = infos[7].ToString();
            ViewData["dateachat"]           = infos[8].ToString();

            return View("Confirmation");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}