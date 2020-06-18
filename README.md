# Le jeu de la vie

Une implémentation simple du jeu de la vie de John Conway réalisé en C#

---

L'objet GameOfLife s'occupe de gérer le jeu et l'affichage.
Lors de l'initialisation de l'objet, il est possible de préciser si le plateau doit être rempli aléatoirement ou non.

 - La méthode Draw() affiche le plateau sur la sortie standard (la 
 console)
 - La méthode NextGeneration() calcule la prochaine génération, il convient d'utiliser la méthode Draw() à nouveau après afin d'afficher les changements.
 