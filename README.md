# COLORS HUNTERS By Dalton's Team

Aquest projecte té com a objectiu desenvolupar un joc innovador per facilitar la **detecció del daltonisme** en nens, joves i adults (de 10 a 30 anys). Aquesta eina ajudarà a professionals de la visió a diagnosticar de manera més simple.

## 🚀 Característiques principals

- **Diagnòstic lúdic**: Un joc interactiu per detectar possibles alteracions visuals relacionades amb el daltonisme.
- **Dades útils per a investigació**: Els resultats del joc es poden utilitzar per a estudis de la societat.
- **Agilització**: Facilita molt el procés de diagnostic amb el pacient.
- **Intuïtiu**: Joc sense gaire complicacions de control, basicament consisteix en realitzar clics sobre la pantalla.

## 🛠️ Tecnologies utilitzades

- **Draw.io**: Per crear el Wireframe de les diferents pantalles del nostre joc, hem decidit utilitzar draw.io, fàcil i simple.

- **Genially**: Com a equip, hem decidit utilitzar Genially per crear el prototip interactiu en lloc d’altres plataformes com Figma, perquè és amb el que més còmode ens sentim, ja que coneixem bé l’eina. 

- **Unity**: Com a equip, hem decidit tira endavant aquest projecte amb el motor de Unity perquè és el que estem estudiant tots a classe i amb el que més familiaritzat estem, per tant, no hi havia una millor opció.

- **Git/GitHub**: Utilitzem Git i GitHub per treballar el projecte en un repositori remot i tenir el control de les versions, per facilitar el treball en equip i la gestió de conflictes en els codis. El motiu principal de fer servir GitHub és el mateix que el de Unity, perquè estem més familiaritzats.

- **MySQL**: Hem decidit utilitzar MySQL perquè després de diverses proves de compatibilitat amb Unity, MySQL és l’opció que menys problemes de dependències i compatibilitat ens ha donat, per tant, hem optat per ell.
  
- **Aiven**: Després d’investigar diferents empreses que ens deixi crear la base de dades en els seus servidors cloud, hem trobat a Aiven, la decisió ha estat senzilla perquè només tenim dos requisits, que sigui gratuït i compatible amb MySQL.

- **DataGrip**: L’entorn que hem utilitzat per treballar amb la base de dades és el DataGrip, perquè disposa d’un entorn intuïtiu i compatibilitat amb diversos tipus de base de dades.

## 🎮 Instruccions del joc

- **Objectiu**:
El joc consisteix a descobrir una ubicació específica en una fotografia on hi haurà un element que destaqui per sobre de la resta. La diferència entre poder distingir aquest element o no, depen en la capacitat visual del jugador, és a dir, si té alguna deficiència visual en els rangs de colors. A través d’unes pistes que es mostren al jugador en un menú del joc, podrà tenir una idea clara de l’element distintiu que ha d’escollir dins de la fotografia.

- **Pasos**:
1. Iniciar sessión amb un document d'identitat, si és la primera vegada que es connecta, se li demanara unes dades, en canvi, si ja s'ha connectat una vegada al joc, accedira directament al menu principal.
2. Clicar a sobre de les ranures de l'album per veure la pista de la imatge que pertany en aquell espai.
3. Accedir al "Mapa mundial" per veure totes les fotografies disponibles i fotografiar la qual creiem que pot encaixar amb la pista de l'album.
4. En la camara, seleccionar l'espai especific de la imatge on esta situat l'element destacat, també pots seleccionar les fotografies que has seleccionat anteriorment.
5. Si la selecció del espai és el correcte, la imatge quedarà reflectida a l'album enlloc de la pista.
6. Una vegada que el jugador hagi completat tot l'album, tindrà a la seva disposició el botò de finalització. En el moment en que es premi, s'enviara el resultat a la base de dades, on més tard, la clinica podra veure totes aquestes dades.

- **Explicació pantalla**:

1. Pantalla de l'album: Aquí el jugador podrà visualitzar les pistes dels elements destacat de cada fotografia. Podrà accedir al "Mapa Mundial", a la "Càmera" i finalitzar el joc.
2. Pantalla del Mapa Mundial: Aquí el jugador podrà visualitzar les imatges disponibles, clicant damunt d'un pin del mapa. Podrà accedir a "l'album" i a la "Càmera".
3. Pantalla de Càmera: Aquí el jugador podra seleccionar l'espai de la fotografia on creu que es troba l'element destacat, també podrà seleccionar els diferents imatges que ha fotografiat. En el cas de que el jugador no pugui descubir l'espai de l'element, tindrà la opció de rendir-se. Podrà accedir al "Mapa Mundial" i a "l'album".
