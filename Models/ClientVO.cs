using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMVC.Models
{
    class ClientVO
    {
        #region Variables et Objets de Cours
        /// <summary>
        /// Désigne le numéro du client.
        /// </summary>
        private int numeroClient;
        private string prenom;
        private string nom;
        private string adresse;
        private string ville;
        private string pays;
        private string codepostal;
        private string numtele;
        private string desc;
        private string dob;
        #endregion

        #region Constructeur de Cours
        /// <summary>
        /// Initializes a new instance of the <see cref="CoursVO"/> class.
        /// Constructeur de CoursVO créant un objet ayant les attributs 
        /// passé en paramètres provenant de CoursDAO - qui accède la base de donnée.
        /// </summary>
        public ClientVO()
        {
        }
        #endregion

        #region Accesseurs et Mutateurs pour Cours
        /// <summary>
        /// Gets or sets pour numeroClient.
        /// </summary>
        public int NumeroClient
        {
            get { return this.numeroClient; }
            set { this.numeroClient = value; }
        }

        /// <summary>
        /// Gets or sets pour nom.
        /// </summary>
        public string NomClient
        {
            get { return this.nom; }
            set { this.nom = value; }
        }

        /// <summary>
        /// Gets or sets pour prenom.
        /// </summary>
        public string PrenomClient
        {
            get { return this.prenom; }
            set { this.prenom = value; }
        }

        /// <summary>
        /// Gets or sets pour prenom.
        /// </summary>
        public string AddresseClient 
        {
            get { return this.adresse; }
            set { this.adresse = value; }
        }

        /// <summary>
        /// Gets or sets pour ville.
        /// </summary>
        public string VilleClient 
        {
            get { return this.ville; }
            set { this.ville = value; }
        }

        /// <summary>
        /// Gets or sets pour pays.
        /// </summary>
        public string PaysClient 
        {
            get { return this.pays; }
            set { this.pays = value; }
        }

        /// <summary>
        /// Gets or sets pour codepostal.
        /// </summary>
        public string PostalcodeClient 
        {
            get { return this.codepostal; }
            set { this.codepostal = value; }
        }

        /// <summary>
        /// Gets or sets pour numtele.
        /// </summary>
        public string NumteleClient
        {
            get { return this.numtele; }
            set { this.numtele = value; }
        }

        /// <summary>
        /// Gets or sets pour desc.
        /// </summary>
        public string ProductDescriptionClient
        {
            get { return this.desc; }
            set { this.desc = value; }
        }

        public string DateNaissanceClient
        {
            get { return this.dob; }
            set { this.dob = value; }
        }
        #endregion
    }
}
