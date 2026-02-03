Modélisation des Entraînements : * Créer une classe Workout (Séance) qui contient une liste de Exercise.

    -Chaque Exercise doit avoir : Nom, Séries, Répétitions, Poids.

    -Challenge Algo : Créer une méthode pour calculer le Volume Total d'une séance (Séries × Répétitions × Poids). C'est ce qu'on voit sur ton tableau de bord (ex: "12k kg total").


Système de Progression (PR) :

    -Logique pour comparer une nouvelle séance avec les anciennes et détecter si l'utilisateur a battu un record (le petit badge "PR" sur la maquette).




Gestion du Calendrier/Streak :

    -Calculer le nombre de jours consécutifs d'entraînement (la "Série" de 7 jours sur ta maquette).

Base de données :

    SQLite est parfait : c'est juste un fichier, pas besoin d'installer un serveur lourd.

    Table Users, Table Exercises, Table Logs.
 ## Partie Algo (NixOS)
- [ ] Créer les classes de base : `User`, `Workout`, `Exercise`, `Set`.
- [ ] Algo : Calcul du volume total d'une séance.
- [ ] Algo : Détection de record personnel (PR) sur un exercice.
- [ ] Database : Setup SQLite pour stocker les séances en local.
- [ ] Database : Table de référence des exercices (interdire l'ajout d'exos hors liste).
- [ ] Serveur (Optionnel) : Simuler une API pour récupérer les feeds des "amis" (Sophie Martin).

## Partie Interface (Windows / WPF)
- [ ] Layout : Créer la barre de navigation basse (TabControl custom).
- [ ] Dashboard : Créer le composant "Statistique" avec le dégradé.
- [ ] Feed : Créer le template de carte pour une séance réalisée.
- [ ] Routine : Créer la vue "Mes routines" avec les boutons "Démarrer vide" et "IA Coach".




github test commit