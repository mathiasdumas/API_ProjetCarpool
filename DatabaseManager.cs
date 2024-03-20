using System;
using System.Text;
using MySqlConnector;

namespace ConnectionString
{
    public class DatabaseManager
    {
        public static void CreateDB()
        {
            string query = "DROP DATABASE IF EXISTS DatabaseTest; CREATE DATABASE DatabaseTest";
            using (MySqlCommand command = new MySqlCommand(query, Connection.GetInstance()))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Database créée avec succès");
            }

        }

        public static void SeedDB()
        {
            string query = @"USE DatabaseTest;

                CREATE TABLE Type_utilisateur(
                Id_TypeConducteur SMALLINT,
                Nom_type_de_conducteur VARCHAR(50),
                PRIMARY KEY(Id_TypeConducteur)
                );

                CREATE TABLE Statut(
                   Id_Statut SMALLINT,
                   Type_de_statut VARCHAR(50),
                   PRIMARY KEY(Id_Statut)
                );

                CREATE TABLE Ecole(
                   Id_Ecole SMALLINT,
                   Nom_école VARCHAR(50),
                   PRIMARY KEY(Id_Ecole)
                );

                CREATE TABLE Notification(
                   Id_Notifications SMALLINT,
                   Type_de_notifications VARCHAR(50),
                   PRIMARY KEY(Id_Notifications)
                );

                CREATE TABLE Preference_voyage(
                   Id_Préférences SMALLINT,
                   Type_de_préférences VARCHAR(50),
                   PRIMARY KEY(Id_Préférences)
                );

                CREATE TABLE Recompense(
                   Id_Récompense SMALLINT,
                   Nom_de_récompense VARCHAR(50),
                   Image_récompense VARCHAR(255),
                   PRIMARY KEY(Id_Récompense)
                );

                CREATE TABLE Carburant(
                   Id_Carburant SMALLINT,
                   Type_de_carburant VARCHAR(25) NOT NULL,
                   PRIMARY KEY(Id_Carburant)
                );

                CREATE TABLE Activation_trajet(
                   Id_ActivationTrajet SMALLINT,
                   Jour_activation VARCHAR(15) NOT NULL,
                   PRIMARY KEY(Id_ActivationTrajet)
                );

                CREATE TABLE Adresse(
                   Id_Adresse INT,
                   Adresse VARCHAR(50) NOT NULL,
                   Ville VARCHAR(50) NOT NULL,
                   Code_postal INT NOT NULL,
                   Id_Ecole SMALLINT NOT NULL,
                   PRIMARY KEY(Id_Adresse),
                   FOREIGN KEY(Id_Ecole) REFERENCES Ecole(Id_Ecole)
                );

                CREATE TABLE Filtre(
                   Id_Filtres SMALLINT,
                   Filtre_trajet VARCHAR(50),
                   PRIMARY KEY(Id_Filtres)
                );

                CREATE TABLE Classe(
                   Id_Classe SMALLINT,
                   Nom_de_promotion VARCHAR(50) NOT NULL,
                   Id_Ecole SMALLINT NOT NULL,
                   PRIMARY KEY(Id_Classe),
                   FOREIGN KEY(Id_Ecole) REFERENCES Ecole(Id_Ecole)
                );

                CREATE TABLE Utilisateur(
                   Id_Utilisateur SMALLINT,
                   Nom VARCHAR(50) NOT NULL,
                   Prénom VARCHAR(30) NOT NULL,
                   Photo_de_profil VARCHAR(255),
                   Adresse_mail VARCHAR(255),
                   Numéro_de_téléphone VARCHAR(25) NOT NULL,
                   Mot_de_passe VARCHAR(255) NOT NULL,
                   Id_TypeConducteur SMALLINT NOT NULL,
                   Id_Classe SMALLINT NOT NULL,
                   Id_Statut SMALLINT NOT NULL,
                   PRIMARY KEY(Id_Utilisateur),
                   UNIQUE(Adresse_mail),
                   UNIQUE(Numéro_de_téléphone),
                   FOREIGN KEY(Id_TypeConducteur) REFERENCES Type_utilisateur(Id_TypeConducteur),
                   FOREIGN KEY(Id_Classe) REFERENCES Classe(Id_Classe),
                   FOREIGN KEY(Id_Statut) REFERENCES Statut(Id_Statut)
                );

                CREATE TABLE Message(
                   Id_Message SMALLINT,
                   Photos_message VARCHAR(255),
                   Contenu TEXT,
                   date_envoi DATETIME,
                   date_reception VARCHAR(50),
                   Id_Utilisateur SMALLINT NOT NULL,
                   Id_Utilisateur_1 SMALLINT NOT NULL,
                   PRIMARY KEY(Id_Message),
                   FOREIGN KEY(Id_Utilisateur) REFERENCES Utilisateur(Id_Utilisateur),
                   FOREIGN KEY(Id_Utilisateur_1) REFERENCES Utilisateur(Id_Utilisateur)
                );

                CREATE TABLE Trajet(
                   Id_Trajets SMALLINT,
                   Horaire_de_départ TIME NOT NULL,
                   Date_de_départ DATE NOT NULL,
                   Nombres_de_places_disponibles INT NOT NULL,
                   Date_de_création DATETIME NOT NULL,
                   Id_Adresse INT NOT NULL,
                   Id_Adresse_1 INT NOT NULL,
                   Id_Utilisateur SMALLINT NOT NULL,
                   PRIMARY KEY(Id_Trajets),
                   FOREIGN KEY(Id_Adresse) REFERENCES Adresse(Id_Adresse),
                   FOREIGN KEY(Id_Adresse_1) REFERENCES Adresse(Id_Adresse),
                   FOREIGN KEY(Id_Utilisateur) REFERENCES Utilisateur(Id_Utilisateur)
                );

                CREATE TABLE Voiture(
                   Id_Voiture SMALLINT,
                   Marque VARCHAR(25) NOT NULL,
                   Modèle VARCHAR(25) NOT NULL,
                   Couleur VARCHAR(25) NOT NULL,
                   Immatriculation VARCHAR(15) NOT NULL,
                   Photo_voiture VARCHAR(255),
                   Id_Carburant SMALLINT NOT NULL,
                   Id_Utilisateur SMALLINT NOT NULL,
                   PRIMARY KEY(Id_Voiture),
                   UNIQUE(Id_Utilisateur),
                   FOREIGN KEY(Id_Carburant) REFERENCES Carburant(Id_Carburant),
                   FOREIGN KEY(Id_Utilisateur) REFERENCES Utilisateur(Id_Utilisateur)
                );

                CREATE TABLE Avis_utilisateur(
                   Id_Avis SMALLINT,
                   Notes INT NOT NULL,
                   Commentaires TEXT,
                   Id_Utilisateur SMALLINT NOT NULL,
                   Id_Utilisateur_1 SMALLINT NOT NULL,
                   PRIMARY KEY(Id_Avis),
                   FOREIGN KEY(Id_Utilisateur) REFERENCES Utilisateur(Id_Utilisateur),
                   FOREIGN KEY(Id_Utilisateur_1) REFERENCES Utilisateur(Id_Utilisateur)
                );

                CREATE TABLE Utilisateur_X_Preference_voyage(
                   Id_Utilisateur SMALLINT,
                   Id_Préférences SMALLINT,
                   PRIMARY KEY(Id_Utilisateur, Id_Préférences),
                   FOREIGN KEY(Id_Utilisateur) REFERENCES Utilisateur(Id_Utilisateur),
                   FOREIGN KEY(Id_Préférences) REFERENCES Preference_voyage(Id_Préférences)
                );

                CREATE TABLE Utilisateur_X_Notification(
                   Id_Utilisateur SMALLINT,
                   Id_Notifications SMALLINT,
                   PRIMARY KEY(Id_Utilisateur, Id_Notifications),
                   FOREIGN KEY(Id_Utilisateur) REFERENCES Utilisateur(Id_Utilisateur),
                   FOREIGN KEY(Id_Notifications) REFERENCES Notification(Id_Notifications)
                );

                CREATE TABLE Utilisateur_X_Recompense(
                   Id_Utilisateur SMALLINT,
                   Id_Récompense SMALLINT,
                   date_obtention DATETIME,
                   PRIMARY KEY(Id_Utilisateur, Id_Récompense),
                   FOREIGN KEY(Id_Utilisateur) REFERENCES Utilisateur(Id_Utilisateur),
                   FOREIGN KEY(Id_Récompense) REFERENCES Recompense(Id_Récompense)
                );

                CREATE TABLE Trajet_X_Activation_trajet(
                   Id_Trajets SMALLINT,
                   Id_ActivationTrajet SMALLINT,
                   PRIMARY KEY(Id_Trajets, Id_ActivationTrajet),
                   FOREIGN KEY(Id_Trajets) REFERENCES Trajet(Id_Trajets),
                   FOREIGN KEY(Id_ActivationTrajet) REFERENCES Activation_trajet(Id_ActivationTrajet)
                );

                CREATE TABLE Trajet_X_Filtre(
                   Id_Trajets SMALLINT,
                   Id_Filtres SMALLINT,
                   PRIMARY KEY(Id_Trajets, Id_Filtres),
                   FOREIGN KEY(Id_Trajets) REFERENCES Trajet(Id_Trajets),
                   FOREIGN KEY(Id_Filtres) REFERENCES Filtre(Id_Filtres)
                );

                CREATE TABLE Trajet_X_Adresse(
                   Id_Trajets SMALLINT,
                   Id_Adresse INT,
                   PRIMARY KEY(Id_Trajets, Id_Adresse),
                   FOREIGN KEY(Id_Trajets) REFERENCES Trajet(Id_Trajets),
                   FOREIGN KEY(Id_Adresse) REFERENCES Adresse(Id_Adresse)
                );

                CREATE TABLE Utilisateur_X_Trajet(
                   Id_Utilisateur SMALLINT,
                   Id_Trajets SMALLINT,
                   date_reservation VARCHAR(50),
                   date_réponse DATETIME,
                   accord BOOL,
                   PRIMARY KEY(Id_Utilisateur, Id_Trajets),
                   FOREIGN KEY(Id_Utilisateur) REFERENCES Utilisateur(Id_Utilisateur),
                   FOREIGN KEY(Id_Trajets) REFERENCES Trajets(Id_Trajets)
                );";

            using (MySqlCommand command = new MySqlCommand(query, Connection.GetInstance()))
            {
                try
                {
                    Console.WriteLine("Database seedéest avec succès");
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Erreur : {ex.Message}");
                }
                

            }
        }
        
    }
}

