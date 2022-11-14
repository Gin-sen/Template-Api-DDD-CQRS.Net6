# My.DDD.CQRS.Temp6.Api

# Installation de la template

Pr�requis : .Net SDK

Cloner le d�pot de la solution.
Dans un terminal, � la racine du d�pot, entrer la commande :
`dotnet new install .`
Cela rendra la template disponible dans Visual Studio (nouveau projet) et avec la commande :
`dotnet new my-ddd-api -n VOTRE.NOUVEAU.MICROSERVICE`

2 cas de figure:
1. Cloner un nouveau d�pot vide puis dans ce d�pot, lancer :
`dotnet new my-ddd-api -n VOTRE.NOUVEAU.MICROSERVICE -o .`
2. Cr�er la solution avec la commande suivante puis initialiser votre d�pot � partir du nouveau dossier de solution
`dotnet new my-ddd-api -n VOTRE.NOUVEAU.MICROSERVICE`

Note:
Si vous utilisez l'option de template `-in false` ou `--includeTest false`, il faudra supprimer les projets de tests de votre solution.

Pour lister les templates install�es :
`dotnet new --list`

Pour d�sinstaller la template, dans un terminal, � la racine du d�pot, entrez la commande :
`dotnet new uninstall .`