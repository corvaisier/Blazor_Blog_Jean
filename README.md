# Blazor_Blog_Jean
docker build -t *nom souhaité image* blazor_blog_jean
docker run -d -p 8080:80 blazor_blog_jean
docker ps -a pour avoir la liste des images
docker exec -it *nom img ou id* /bin/bash

Profiter d'avoir le bash pour dl le fichier .db ? 
Sinon essayer de trouver les lignes de commande dotnet pour remplacer ef et ou générer la db