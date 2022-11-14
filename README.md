# My.DDD.CQRS.Temp6.Api

# Installation de la template

Prérequis : .Net SDK

Cloner le dépot de la solution.
Dans un terminal, à la racine du dépot, entrer la commande :
`dotnet new install .`
Cela rendra la template disponible dans Visual Studio (nouveau projet) et avec la commande :
`dotnet new my-ddd-api -n VOTRE.NOUVEAU.MICROSERVICE`

2 cas de figure:
1. Cloner un nouveau dépot vide puis dans ce dépot, lancer :
`dotnet new my-ddd-api -n VOTRE.NOUVEAU.MICROSERVICE -o .`
2. Créer la solution avec la commande suivante puis initialiser votre dépot à partir du nouveau dossier de solution
`dotnet new my-ddd-api -n VOTRE.NOUVEAU.MICROSERVICE`

Note:
Si vous utilisez l'option de template `-in false` ou `--includeTest false`, il faudra supprimer les projets de tests de votre solution.

Pour lister les templates installées :
`dotnet new --list`

Pour désinstaller la template, dans un terminal, à la racine du dépot, entrez la commande :
`dotnet new uninstall .`