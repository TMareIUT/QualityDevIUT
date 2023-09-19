//MAIN

using TD1_Projet;

Library bibliotheque = new Library();


Livre livre1 = new Livre("Le Seigneur des Anneaux", 101, 5, "J.R.R. Tolkien");
Livre livre2 = new Livre("La Horde du Contrevent", 102, 4, "Alain Damasio");
Livre livre3 = new Livre("Le Cycle de Fondation T1 : Fondation", 102, 6, "Isaac Asimov");
DVD dvd1 = new DVD("Inception", 201, 3, 148);
CD cd1 = new CD("Abbey Road", 301, 2, "The Beatles");

// Ajout de media à la bibliothèque en utilisant la surcharge de la classe Library
bibliotheque += livre1;
bibliotheque += livre2;
bibliotheque += livre3;

// Retirer un livre de la bibliothèque grâce à la même surcharge
bibliotheque -= livre2;

// Sauvegarder la bibliothèque dans un fichier
Library maBibliothèque = new Library();
maBibliothèque.SauvegarderBibliothèque("bibliotheque.json");

// Charger la bibliothèque à partir du fichier
Library nouvelleBibliothèque = Library.ChargerBibliothèque("bibliotheque.json");




bibliotheque.AfficherTousLesMedias();
bibliotheque.AfficherStatistiques();

