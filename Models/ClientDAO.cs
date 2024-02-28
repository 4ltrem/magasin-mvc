using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace LabMVC.Models
{
    class ClientDAO
    {
        #region Variables de connexion
        /// <summary>
        /// Chaine de connexion.
        /// </summary>
        private string dp = "System.Data.SqlClient";

        /// <summary>
        /// Chaine de connexion.
        /// </summary>
        //private string cnStr = "Data Source=(local)\\MOB-C01203;Initial Catalog=Client;Integrated Security=True";
        private string cnStr = @"Data Source=ALEX-GAMING-PC\SQLEXPRESS;Initial Catalog=munchdb;Integrated Security=True";

        /// <summary>
        /// Objet de factory.
        /// </summary>
        private DbProviderFactory df;

        /// <summary>
        /// Objet de connexion.
        /// </summary>
        private DbConnection cn;

        /// <summary>
        /// Création de commande de dp.
        /// </summary>
        private DbCommand cmdCommand;
        #endregion
        public ClientDAO()
        {
            // Objet du factory provider et Objet de connexion.
            this.df = DbProviderFactories.GetFactory(this.dp);
            this.cn = this.df.CreateConnection();

            try
            {
                // Ouvrir la connection avec la base de données.
                this.cn.ConnectionString = this.cnStr;
                this.cn.Open();

                // Création de commande.
                this.cmdCommand = this.df.CreateCommand();
                this.cmdCommand.Connection = this.cn;
            }
            catch (SqlException e)
            {
                // Attrapper les cas ou il n'y a pas de connexion.
                Console.WriteLine("Erreur de connexion, exception: " + e.StackTrace.ToString());
            }
        }
        #region Accesseurs et Mutateurs
        /// <summary>
        /// Gets or sets String dp.
        /// </summary>
        protected string Dp
        {
            get { return this.dp; }
            set { this.dp = value; }
        }

        /// <summary>
        /// Gets or sets String CnStr (de connexion).
        /// </summary>
        protected string CnStr
        {
            get { return this.cnStr; }
            set { this.cnStr = value; }
        }

        /// <summary>
        /// Gets or sets the Database ProviderFactory.
        /// </summary>
        protected DbProviderFactory Df
        {
            get { return this.df; }
            set { this.df = value; }
        }

        /// <summary>
        /// Gets or sets the Database Connection.
        /// </summary>
        protected DbConnection Cn
        {
            get { return this.cn; }
            set { this.cn = value; }
        }

        /// <summary>
        /// Gets or sets DbCommand cmdCommand.
        /// </summary>
        protected DbCommand CmdCommand
        {
            get { return this.cmdCommand; }
            set { this.cmdCommand = value; }
        }
        #endregion
        public Object[] sauvegardeClient(ClientVO clientvo)
        {
            /*
                                    === BESOIN ===
                            le prénom, 
                            le nom, 
                            la date de naissance,
                            le numéro de téléphone, 
                            la description  
                                                          
                            userid INT NOT NULL,            *
                            prenom VARCHAR(50),             *
                            nom VARCHAR(50),                *
                            birthday DATE NOT NULL,         *
                            numtele VARCHAR(12) NOT NULL,   *
                            descCmd TEXT NOT NULL,          *
                            address VARCHAR(50) NOT NULL,   X
            */
            //Requête SQL qui insère tout l'information reçu en paramètre.
            cmdCommand.CommandText =
                "Insert Into commandes(userid, prenom, nom, birthday, numtele, descCmd, address) " +
                "Values('"
                + clientvo.NumeroClient +"' , '"
                + clientvo.PrenomClient + "' , '"
                + clientvo.NomClient + "' , '"
                + clientvo.DateNaissanceClient + "' , '"
                + clientvo.NumteleClient + "' , '"
                + clientvo.ProductDescriptionClient + "' , '"
                + clientvo.AddresseClient + ", " + clientvo.VilleClient + ", " + clientvo.PaysClient
                + "');";
            cmdCommand.ExecuteNonQuery();

            Object[] resultat = new Object[9];

            //Retrouver les informations du client
            cmdCommand.CommandText = "SELECT TOP 1 * FROM commandes ORDER BY orderid DESC";
            using (DbDataReader dr = cmdCommand.ExecuteReader())
            {
                // Lecture de tous les résultats.
                while (dr.Read())
                {
                  dr.GetValues(resultat);
                }
            }
            return resultat;
        }
        //public string getDOP(ClientVO clientvo) {
        //    //Retrouver la date d'achat de la commande
        //    string result = ""; ;
        //    cmdCommand.CommandText = "SELECT TOP 1 * FROM commandes ORDER BY orderid DESC";
        //    using (DbDataReader dr = cmdCommand.ExecuteReader())
        //    {
        //        // Lecture de tous les résultats.
        //        while (dr.Read())
        //        {
        //            result = dr["dateOfPurchase"].ToString();
        //        }
        //    }
        //    return result;
        //}
    }
}
