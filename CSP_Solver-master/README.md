CSP Solver 

Bonjour à tous, 

Pour exécuter le programme, vous devez avoir installé python 3.4 ou version ultérieure, les fichiers search.py, original.py et utils.py ont été extraits du code original d'AIMA (https://github.com/aimacode/aima-python) par Peter Norvig comme solveur de base pour csp général.

- original.py, utils.py et search.py ne sont pas nécessaires pour exécuter main.py ou test.py, ceux-ci ont été ajoutés juste pour montrer ses performances sur docs / original_results.txt

- La classe sudokuCSP crée les objets nécessaires pour le solveur csp général comme voisin, variables, domaine pour un jeu sudoku comme problème de satisfaction de contrainte

- Le fichier csp.py contient du code de original.py (fichier csp.py du code AIMA) légèrement modifié, il n'utilise pas de fonctions rares d'autres fichiers (comme ultis.py), les méthodes qui ont été modifiées sont étiquetées avec le commentaire "@modifié"

- Le fichier csp.py contient des algorithmes pour résoudre csp, comme le retour en arrière avec les 3 méthodes différentes pour l'inférence, mrv et quelques autres méthodes.

- La classe dans gui.py contient du code pour créer une interface utilisateur graphique pour le jeu, permettant à l'utilisateur de choisir un niveau (il y a 6 tableaux différents) et une méthode infernet pour le retour en arrière

- Le fichier test.py contient du code pour exécuter des tests pour chaque algorithme d'inférence sur une carte sudoku (il est possible de choisir quelle carte)

- Le fichier Main.py contient une méthode principale pour exécuter le programme gui

Deux fichiers ont été ajoutés montrant la différence entre le fichier csp.py d'origine du code AIMA et celui-ci modifié. (vérifiez modified_results.txt et original_results.txt)


N'hésitez pas à lire les documentations pour plus d'informations ou à en envoyer un message à Danush, Axel, Célia ou moi-même Laura. 

Bonne lecture à tous 
