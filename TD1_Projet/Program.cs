//MAIN

using TD1_Projet;

Library bibliotheque = new Library();

Livre livre1 = new Livre("Le Seigneur des Anneaux", 101, 5, "J.R.R. Tolkien");
Livre livre2 = new Livre("La Horde du Contrevent", 102, 4, "Alain Damasio");
Livre livre3 = new Livre("Le Cycle de Fondation T1 : Fondation", 102, 6, "Isaac Asimov");

bibliotheque.AjouterMedia(livre1);

// Ajouter un livre à la bibliothèque
bibliotheque += livre2;
bibliotheque += livre3;

// Retirer un livre de la bibliothèque
bibliotheque -= livre2;


bibliotheque.AfficherTousLesMedias();
bibliotheque.AfficherStatistiques();