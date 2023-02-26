using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.Services;

namespace DEMO_GSB_V
{
    /// <summary>
    /// Description résumée de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

            [WebMethod]
            /// <summary>
            /// Insère une inscription à une activité pour un utilisateur
            /// </summary>
            /// <param name="idActivite">Id de l'activité</param>
            /// <param name="nomUser">Nom de l'utilisateur</param>
            /// <param name="prenomUser">Prénom de l'utilisateur</param>
            /// <param name="mailUser">Mail de l'utilisateur</param>
            public void insertActivite(String nomUser, String prenomUser, String mailUser, int idActivite)
            {
                string connString = "Server=127.0.0.1; Database=gsbmvc;Uid=root; Password=; sslmode=none";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "INSERT INTO utilisateurs (nomUser, prenomUser, mailUser) VALUES (@nomUser, @prenomUser, @mailUser);";
                command1.Parameters.AddWithValue("@nomUser", nomUser);
                command1.Parameters.AddWithValue("@prenomUser", prenomUser);
                command1.Parameters.AddWithValue("@mailUser", mailUser);
                command1.Parameters.AddWithValue("@idActivites", idActivite);

                command1.ExecuteNonQuery();

                MySqlCommand command2 = conn.CreateCommand();
                command2.CommandText = "INSERT INTO inscription (idActivites, idUser) VALUES (@idActivites, (SELECT idUser FROM utilisateurs WHERE mailUser = @mailUser))";

                command2.Parameters.AddWithValue("@nomUser", nomUser);
                command2.Parameters.AddWithValue("@prenomUser", prenomUser);
                command2.Parameters.AddWithValue("@mailUser", mailUser);
                command2.Parameters.AddWithValue("@idActivites", idActivite);

                command2.ExecuteNonQuery();

                conn.Close();
            }

            [WebMethod]
            /// <summary>
            /// Récupère les médicaments
            /// </summary>
            public String[] selectMedicaments()
            {
                string connString = "Server=127.0.0.1; Database=gsbmvc;Uid=root; Password=; sslmode=none";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "SELECT COUNT(*) AS nbMedicaments FROM medicaments";
                MySqlDataReader dataReader = command1.ExecuteReader();
                int nbMedicaments = 0;
                while (dataReader.Read())
                {
                    nbMedicaments = Convert.ToInt16(dataReader["nbMedicaments"]);
                }
                int i = 0;
                String[] medicaments = new String[nbMedicaments];

                dataReader.Close();
                MySqlCommand command2 = conn.CreateCommand();
                command2.CommandText = "SELECT * FROM medicaments";
                MySqlDataReader dataReader2 = command2.ExecuteReader();

                while (dataReader2.Read())
                {
                    medicaments[i] = dataReader2["idMedicament"] + ";" + dataReader2["nomMedicament"] + ";" + dataReader2["descriptionMedicament"] + ";";
                    i++;
                }
                
                dataReader2.Close();
                conn.Close();
                return medicaments;
            }

            [WebMethod]
            /// <summary>
            /// Récupère toutes les activités
            /// </summary>
            public String[] selectActivitesAnimateurs()
            {
                string connString = "Server=127.0.0.1; Database=gsbmvc;Uid=root; Password=; sslmode=none";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "SELECT COUNT(*) AS nbActivites FROM activites";
                MySqlDataReader dataReader = command1.ExecuteReader();
                int nbActivites = 0;
                while (dataReader.Read())
                {
                    nbActivites = Convert.ToInt16(dataReader["nbActivites"]);
                }
                int i = 0;
                String[] activites = new String[nbActivites];

                dataReader.Close();

                MySqlCommand command2 = conn.CreateCommand();
                command2.CommandText = "SELECT * FROM animateur JOIN activites ON activites.idAnimateur = animateur.idAnimateur GROUP BY activites.idActivites";
                MySqlDataReader dataReader2 = command2.ExecuteReader();
                while (dataReader2.Read())
                {
                    activites[i] = dataReader2["idActivites"] + ";" + dataReader2["nomActivite"] + ";" + dataReader2["descriptionActivite"] + ";" + dataReader2["dateActivite"] + ";" + dataReader2["idAnimateur"] + ";" + dataReader2["nomAnimateur"] + ";" + dataReader2["prenomAnimateur"] + ";" + dataReader2["contactAnimateur"] + ";";
                    i++;
                }
                conn.Close();
                return activites;
            }

            [WebMethod]
            /// <summary>
            /// Récupère un médicament
            /// </summary>
            /// <param name="idMedicament">Id du médicament</param>
            public String selectMedicament(int idMedicament)
            {
                String medicament = null;
                string connString = "Server=127.0.0.1; Database=gsbmvc;Uid=root; Password=; sslmode=none";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                /*MySqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "SELECT * FROM medicaments WHERE idMedicament = @idMedicament";
                command1.Parameters.AddWithValue("@idMedicament", idMedicament);
                MySqlDataReader dataReader = command1.ExecuteReader();
                while (dataReader.Read())
                {
                    medicament = dataReader["idMedicament"] + ";" + dataReader["nomMedicament"] + ";" + dataReader["descriptionMedicament"];
                }
                conn.Close();*/
                try
                {
                    MySqlCommand command1 = new MySqlCommand("get_Medicament_Info", conn);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.Add("@idMedic", (MySqlDbType)SqlDbType.Int).Value = idMedicament;

                    command1.Parameters.Add(new MySqlParameter("@nomMedic", MySqlDbType.VarChar, 50));
                    command1.Parameters.Add(new MySqlParameter("@descMedic", MySqlDbType.VarChar, 256));

                    command1.Parameters["@nomMedic"].Direction = ParameterDirection.Output;
                    command1.Parameters["@descMedic"].Direction = ParameterDirection.Output;

                    command1.ExecuteNonQuery();

                    medicament = Convert.ToString(idMedicament) + ";" + command1.Parameters["@nomMedic"].Value.ToString() + ";" + command1.Parameters["@descMedic"].Value.ToString();

                }catch
                {

                }finally
                {
                    conn.Close();
                    conn.Dispose();
                }

                return medicament;

        }

            [WebMethod]
            /// <summary>
            /// Récupère les effets thérapeutiques d'un médicament
            /// </summary>
            /// <param name="idMedicament">Id du médicament</param>
            public String[] selectEffetsTherapeutiques(int idMedicament)
            {
                string connString = "Server=127.0.0.1; Database=gsbmvc;Uid=root; Password=; sslmode=none";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "SELECT COUNT(*) as nbEffetsTherapeutiques FROM effetstherapeutiques JOIN avoireffettherapeutique ON avoireffettherapeutique.idEffetTherapeutique = effetstherapeutiques.idEffetTherapeutique WHERE avoireffettherapeutique.idMedicament = @idMedicament";
                command1.Parameters.AddWithValue("@idMedicament", idMedicament);
                MySqlDataReader dataReader = command1.ExecuteReader();
                int nbEffetsTherapeutiques = 0;
                while (dataReader.Read())
                {
                    nbEffetsTherapeutiques = Convert.ToInt16(dataReader["nbEffetsTherapeutiques"]);
                }
                int i = 0;

                if(nbEffetsTherapeutiques <= 0)
                {
                    nbEffetsTherapeutiques = 1;
                }

                String[] effetsTherapeutiques = new String[nbEffetsTherapeutiques];

                effetsTherapeutiques[0] = "999;Veuillez vous référer à la notice du médicament pour plus de détails.";
              
                dataReader.Close();

                MySqlCommand command2 = conn.CreateCommand();
                command2.CommandText = "SELECT effetstherapeutiques.idEffetTherapeutique, effetstherapeutiques.nomEffetTherapeutique, effetstherapeutiques.descriptionEffetTherapeutique FROM effetstherapeutiques JOIN avoireffettherapeutique ON avoireffettherapeutique.idEffetTherapeutique = effetstherapeutiques.idEffetTherapeutique WHERE avoireffettherapeutique.idMedicament = @idMedicament";
                command2.Parameters.AddWithValue("@idMedicament", idMedicament);
                MySqlDataReader dataReader2 = command2.ExecuteReader();

                while (dataReader2.Read())
                {
                    effetsTherapeutiques[i] = dataReader2["idEffetTherapeutique"] + ";" + dataReader2["nomEffetTherapeutique"] + ";" + dataReader2["descriptionEffetTherapeutique"];
                    i++;
                }

                conn.Close();
                return effetsTherapeutiques;
            }

            [WebMethod]
            /// <summary>
            /// Récupère les effets secondaires d'un médicament
            /// </summary>
            /// <param name="idMedicament">Id du médicament</param>
            public String[] selectEffetsSecondaires(int idMedicament)
            {
                string connString = "Server=127.0.0.1; Database=gsbmvc;Uid=root; Password=; sslmode=none";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "SELECT COUNT(*) AS nbEffetsSecondaires FROM effetssecondaires JOIN avoireffetsecondaire ON avoireffetsecondaire.idEffetSecondaire = effetssecondaires.idEffetSecondaire WHERE avoireffetsecondaire.idMedicament = @idMedicament";
                command1.Parameters.AddWithValue("@idMedicament", idMedicament);
                MySqlDataReader dataReader = command1.ExecuteReader();
                int nbEffetsSecondaires = 0;
                while (dataReader.Read())
                {
                    nbEffetsSecondaires = Convert.ToInt16(dataReader["nbEffetsSecondaires"]);
                }
                int i = 0;

                if (nbEffetsSecondaires <= 0)
                {
                    nbEffetsSecondaires = 1;
                }

                String[] effetsSecondaires = new String[nbEffetsSecondaires];

                effetsSecondaires[0] = "999;Veuillez vous référer à la notice du médicament pour plus de détails.";

                dataReader.Close();

                MySqlCommand command2 = conn.CreateCommand();
                command2.CommandText = "SELECT effetssecondaires.idEffetSecondaire, effetssecondaires.nomEffetSecondaire, effetssecondaires.descriptionEffetSecondaire FROM effetssecondaires JOIN avoireffetsecondaire ON avoireffetsecondaire.idEffetSecondaire = effetssecondaires.idEffetSecondaire WHERE avoireffetsecondaire.idMedicament = @idMedicament";
                command2.Parameters.AddWithValue("@idMedicament", idMedicament);
                MySqlDataReader dataReader2 = command2.ExecuteReader();
                while (dataReader2.Read())
                {
                    effetsSecondaires[i] = dataReader2["idEffetSecondaire"] + ";" + dataReader2["nomEffetSecondaire"] + ";" + dataReader2["descriptionEffetSecondaire"];
                    i++;
                }
                conn.Close();
                return effetsSecondaires;
            }

            [WebMethod]
            /// <summary>
            /// Récupère les informations d'une activité
            /// </summary>
            /// <param name="idActivite">Id de l'activité</param>
            public String selectActiviteAnimateur(int idActivite)
            {
                String activite = null;
                string connString = "Server=127.0.0.1; Database=gsbmvc;Uid=root; Password=; sslmode=none";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                /*MySqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "SELECT * FROM activites JOIN animateur ON activites.idAnimateur = animateur.idAnimateur WHERE activites.idActivites = @idActivite";
                command1.Parameters.AddWithValue("@idActivite", idActivite);
                MySqlDataReader dataReader = command1.ExecuteReader();
                while (dataReader.Read())
                {
                    activite = dataReader["idActivites"] + ";" + dataReader["nomActivite"] + ";" + dataReader["descriptionActivite"] + ";" + dataReader["dateActivite"] + ";" + dataReader["idAnimateur"] + ";" + dataReader["nomAnimateur"] + ";" + dataReader["prenomAnimateur"] + ";" + dataReader["contactAnimateur"] + ";";
                }
                conn.Close();*/
                try
                {
                    MySqlCommand command1 = new MySqlCommand("get_Activite_Info", conn);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.Add("@idAct", (MySqlDbType)SqlDbType.Int).Value = idActivite;

                    command1.Parameters.Add(new MySqlParameter("@nomAct", MySqlDbType.VarChar, 50));
                    command1.Parameters.Add(new MySqlParameter("@descAct", MySqlDbType.VarChar, 256));
                    command1.Parameters.Add(new MySqlParameter("@dateAct", MySqlDbType.Date));
                    command1.Parameters.Add(new MySqlParameter("@idAnim", MySqlDbType.Int32));
                    command1.Parameters.Add(new MySqlParameter("@nomAnim", MySqlDbType.VarChar, 50));
                    command1.Parameters.Add(new MySqlParameter("@prenomAnim", MySqlDbType.VarChar, 50));
                    command1.Parameters.Add(new MySqlParameter("@contactAnim", MySqlDbType.VarChar, 50));

                    command1.Parameters["@nomAct"].Direction = ParameterDirection.Output;
                    command1.Parameters["@descAct"].Direction = ParameterDirection.Output;
                    command1.Parameters["@dateAct"].Direction = ParameterDirection.Output;
                    command1.Parameters["@idAnim"].Direction = ParameterDirection.Output;
                    command1.Parameters["@nomAnim"].Direction = ParameterDirection.Output;
                    command1.Parameters["@prenomAnim"].Direction = ParameterDirection.Output;
                    command1.Parameters["@contactAnim"].Direction = ParameterDirection.Output;

                    command1.ExecuteNonQuery();

                    activite = Convert.ToString(idActivite) + ";" + command1.Parameters["@nomAct"].Value.ToString() + ";" + command1.Parameters["@descAct"].Value.ToString() + ";" + command1.Parameters["@dateAct"].Value.ToString() + ";" + command1.Parameters["@idAnim"].Value.ToString() + ";" + command1.Parameters["@nomAnim"].Value.ToString() + ";" + command1.Parameters["@prenomAnim"].Value.ToString() + ";" + command1.Parameters["@contactAnim"].Value.ToString();

                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
                return activite;
            }

            [WebMethod]
            /// <summary>
            /// Récupère les inscrits à une activité
            /// </summary>
            /// <param name="idActivite">Id de l'activité</param>
            public String[] selectUtilisateursActivite(int idActivite)
            {
                string connString = "Server=127.0.0.1; Database=gsbmvc;Uid=root; Password=; sslmode=none";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "SELECT COUNT(*) AS nbUtilisateurs FROM utilisateurs JOIN inscription ON inscription.idUser = utilisateurs.idUser WHERE inscription.idActivites = @idActivite";
                command1.Parameters.AddWithValue("@idActivite", idActivite);
                MySqlDataReader dataReader = command1.ExecuteReader();
                int nbUtilisateurs = 0;
                while (dataReader.Read())
                {
                    nbUtilisateurs = Convert.ToInt16(dataReader["nbUtilisateurs"]);
                }
                int i = 0;

                if (nbUtilisateurs <= 0)
                {
                    nbUtilisateurs = 1;
                }
                String[] utilisateurs = new String[nbUtilisateurs];

                utilisateurs[0] = "999;Aucun inscrit recensé.";

                dataReader.Close();

                MySqlCommand command2 = conn.CreateCommand();
                command2.CommandText = "SELECT * FROM utilisateurs JOIN inscription ON inscription.idUser = utilisateurs.idUser WHERE inscription.idActivites = @idActivite";
                command2.Parameters.AddWithValue("@idActivite", idActivite);
                MySqlDataReader dataReader2 = command2.ExecuteReader();
                while (dataReader2.Read())
                {
                    utilisateurs[i] = dataReader2["idUser"] + ";" + dataReader2["nomUser"] + ";" + dataReader2["prenomUser"] + ";" + dataReader2["mailUser"];
                    i++;
                }
                conn.Close();
                return utilisateurs;
            }

            [WebMethod]
            /// <summary>
            /// Récupère les relations d'un médicament avec les autres
            /// </summary>
            /// <param name="idMedicament">Id du médicament</param>
            public String[] selectRelationMedicaments(int idMedicament)
            {
                string connString = "Server=127.0.0.1; Database=gsbmvc;Uid=root; Password=; sslmode=none";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "SELECT COUNT(*) AS nbRelations FROM medicaments WHERE idMedicament IN (SELECT interactionmedicament.idMedicament FROM medicaments JOIN interactionmedicament ON medicaments.idMedicament = interactionmedicament.idMedicament WHERE interactionmedicament.idMedicament = @idMedicament OR interactionmedicament.idMedicament_1 = @idMedicament UNION SELECT interactionmedicament.idMedicament_1 FROM medicaments JOIN interactionmedicament ON medicaments.idMedicament = interactionmedicament.idMedicament WHERE interactionmedicament.idMedicament = @idMedicament OR interactionmedicament.idMedicament_1 = @idMedicament) AND idMedicament <> @idMedicament";
                command1.Parameters.AddWithValue("@idMedicament", idMedicament);
                MySqlDataReader dataReader = command1.ExecuteReader();
                int nbRelations = 0;
                while (dataReader.Read())
                {
                    nbRelations = Convert.ToInt16(dataReader["nbRelations"]);
                }

                if(nbRelations <= 0)
                {
                    nbRelations = 1;
                }

                int i = 0;
                String[] medicamentsRelation = new String[nbRelations];

                medicamentsRelation[0] = "999;Aucune interaction recensée.";

                dataReader.Close();

                MySqlCommand command2 = conn.CreateCommand();
                command2.CommandText = "SELECT * FROM medicaments WHERE idMedicament IN (SELECT interactionmedicament.idMedicament FROM medicaments JOIN interactionmedicament ON medicaments.idMedicament = interactionmedicament.idMedicament WHERE interactionmedicament.idMedicament = @idMedicament OR interactionmedicament.idMedicament_1 = @idMedicament UNION SELECT interactionmedicament.idMedicament_1 FROM medicaments JOIN interactionmedicament ON medicaments.idMedicament = interactionmedicament.idMedicament WHERE interactionmedicament.idMedicament = @idMedicament OR interactionmedicament.idMedicament_1 = @idMedicament) AND idMedicament <> @idMedicament";
                command2.Parameters.AddWithValue("@idMedicament", idMedicament);
                MySqlDataReader dataReader2 = command2.ExecuteReader();
                while (dataReader2.Read())
                {
                    medicamentsRelation[i] = dataReader2["idMedicament"] + ";" + dataReader2["nomMedicament"] + ";" + dataReader2["descriptionMedicament"];
                    i++;
                }

                conn.Close();
                return medicamentsRelation;
            }
        }
    }
