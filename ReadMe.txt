https://www.youtube.com/watch?v=EmV_IBYIlyo&list=PL82C6-O4XrHdiS10BLh23x71ve9mQCln0&index=5
https://drive.google.com/file/d/1EbYYjY7ubkpVKgBVE3Dloa9tr-oqo58g/view
________________________________________tutorial api aspnet + diagram pokemon_______________________
https://www.youtube.com/watch?v=NYpOaPC6jrg
________________explicacion de [fromquery]/[frombody etc]_________

----------------->EN LA CLASS POKEMON HAY EXPLICACIONES EN EL POKEOMON todos los files.<-----------------

Models,clases normals amb les seves relacions de 1 to 1 or 1 to many
Y si es Many to Many creas la clase Join que es la de Many to Many y 
Ejemplo:PokemnOwner.cs and PokemonCategory.cs
Dentro la clase de Pokemon pongo(como atributos) ambas y dentro de la clase
Owner Pongo PokemonOwner (como atributo"Sino mejor ver las clases")
En la clase Category pongo la clase Join de PokemonCategory(as atribute)

setps:::::::::::::::::::::::::::::::::::::::::

·CREO LOS MODELS, EL DATACONTEXT..

·DB: Creo una DB con el SSMS...
1-Clickderecho en databsases dentro del servidor SSMS y Crear nueva database
(el paso 2 no hace falta pq ya estoy conectado a este servidor)
2-Accedemos al ssms copiamos el nombre del servidor(DESKTOP-14D02GT\SQLEXPRESS01)
y en Explorador de ServerObject en VisualStudio creamos un nuevo server con este mismo nombre y nos conectamos
a la db creada anteriormente. (en mi caso ya estoy conectado al server por otros proyectos)
3-Vamos a las propiedades dela database desde SQLVisualstudio y la cedana de la db la copiamos y lo ponemos
en el conecctionsetting (defaultconnedction) del apsettings.json.
4-configuramos en el program.cs que se conecte al defaultconnection(que hemos establecido)
5-Usamos la consola nugget:
//Comandos para inicializar la Migracion una vez se ha creado o modificado las clases y por lo tanto
        //Se habran modificado las tablas: Comando:::
        //EntityFrameworkCore\Add-Migration (Migration'sName)
        //Después de esto el comando para actualizar la Database es:
        //EntityFrameworkCore\Update-DataBase
(paso3)Ejemplo cadena conexion a la db:
Accedo a las properties de la DB creada y copio la cadena de conexion.(Data Source=DESKTOP-14D02GT\SQLEXPRESS01;Initial Catalog=pokemonreview;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False)
En el appsettings.json Hemos puesto la cadena de conexion.

RECORDAR: instalar el EntityFrameworkCore, SQLServer, Design, Tools.  +Automapper, quizas
tambien el automapper dependency injeccion.

·CREO LAS INTERFACES, RESPOSITORY, DTO, HELPER..


PROBLEMAS:
-OWNER POST ((ya no es problema))
 Para crearlo no debo tocar el id porque se crea solo, y debo poner el idCountry antes
 pq se necesita poner de qué Country es el nuevo Owner.

-Poner validaciones, por ejemplo si el pokemon post, si lo intento crear con un ownerid no 
existente o un categoyId no existente no deja i rebienta al save();