using System;
using System.Collections.Generic;
using System.IO;
using Data.Code.Medias;
using Newtonsoft.Json;
using LibraryData.Code;
using System.Collections;

namespace Data.Code.Tools
{
    /// <summary>
    /// Classe permetant de gérer les données de la bibliothèques
    /// SAuvegare et chargement des données
    /// </summary>
    public class DataManager
    {
        private readonly Constantes m_constantes = new Constantes();

        /// <summary>
        /// Méthode pour sauvegarder l'état de la bibliothèque dans un fichier JSON
        /// </summary>
        /// <param name="p_medias">Liste des médias</param>
        /// <param name="p_emprunts">Liste des emprunts</param>
        public void SauvegarderBibliothèque(List<Media> p_medias, List<Emprunt> p_emprunts)
        {
            List<Media> v_medias = new List<Media>();
            List<Livre> v_livres = new List<Livre>();
            List<Dvd> v_dvds = new List<Dvd>();
            List<Cd> v_cds = new List<Cd>();

            foreach (Media media in p_medias)
            {
                if (media.GetType() == typeof(Livre))
                {
                    v_livres.Add((Livre)media);
                }
                else if(media.GetType() == typeof(Dvd))
                {
                    v_dvds.Add((Dvd)media);
                }
                else if (media.GetType() == typeof(Cd))
                {
                    v_cds.Add((Cd)media);
                }
                else
                {
                    v_medias.Add(media);
                }
            }
            Dictionary<string, string> collection = new Dictionary<string, string>();
            collection.Add(m_constantes.KEY_MEDIAS, JsonConvert.SerializeObject(v_medias));
            collection.Add(m_constantes.KEY_LIVRE, JsonConvert.SerializeObject(v_livres));
            collection.Add(m_constantes.KEY_DVD, JsonConvert.SerializeObject(v_dvds));
            collection.Add(m_constantes.KEY_CD, JsonConvert.SerializeObject(v_cds));
            collection.Add(m_constantes.KEY_EMPRUNTS, JsonConvert.SerializeObject(p_emprunts));

            // Sérialisez la bibliothèque et les emprunts en JSON
            string json = JsonConvert.SerializeObject(collection);
            // Écrivez le JSON dans un fichier
            File.WriteAllText($"{m_constantes.NOM_FICHIER}.json", json);
        }

        /// <summary>
        /// Méthode pour charger la bibliothèque à partir d'un fichier JSON
        /// </summary>
        /// <param name="Medias">Liste des médias</param>
        /// <param name="Emprunts">Liste des emprunts</param>
        public void ChargerBibliothèque(out List<Media> Medias, out List<Emprunt> Emprunts)
        {
            Medias = new List<Media>();
            Emprunts = new List<Emprunt>();

            if (File.Exists($"{m_constantes.NOM_FICHIER}.json"))
            {
                // Lisez le contenu du fichier JSON
                string json = File.ReadAllText($"{m_constantes.NOM_FICHIER}.json");

                try
                {
                    // Désérialisez la bibliothèque et les emprunts à partir du JSON
                    Dictionary<string, string> collection = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                                       
                    Console.WriteLine($"Médias chargées : {json}");
                    // Remplacez les données actuelles par les données désérialisées
                    if(collection.Count > 0)
                    {
                        //JsonConvert.
                        if (collection.ContainsKey(m_constantes.KEY_MEDIAS))
                        {
                            List<Media> JsonMedias = JsonConvert.DeserializeObject<List<Media>>(collection[m_constantes.KEY_MEDIAS]);
                            Medias.AddRange(JsonMedias);
                        }                        
                        if (collection.ContainsKey(m_constantes.KEY_LIVRE))
                        {
                            List<Livre> JsonMedias = JsonConvert.DeserializeObject<List<Livre>>(collection[m_constantes.KEY_LIVRE]);
                            Medias.AddRange(JsonMedias);
                        }
                        if (collection.ContainsKey(m_constantes.KEY_DVD))
                        {
                            List<Dvd> JsonMedias = JsonConvert.DeserializeObject<List<Dvd>>(collection[m_constantes.KEY_DVD]);
                            Medias.AddRange(JsonMedias);
                        }
                        if (collection.ContainsKey(m_constantes.KEY_CD))
                        {
                            List<Cd> JsonMedias = JsonConvert.DeserializeObject<List<Cd>>(collection[m_constantes.KEY_CD]);
                            Medias.AddRange(JsonMedias);
                        }
                        if (collection.ContainsKey(m_constantes.KEY_EMPRUNTS))
                        {
                            Emprunts = JsonConvert.DeserializeObject<List<Emprunt>>(collection[m_constantes.KEY_EMPRUNTS]);
                        }
                    }                    
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine("Le fichier de sauvegarde des médias est invalide ou corrompu.");
                }                
            }            
            else
            {
                Console.WriteLine("Le fichier de sauvegarde n'existe pas.");
            }
        }
    }
}
